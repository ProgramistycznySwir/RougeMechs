﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RougeMechs;

using RougeMechsStructures;
using RougeMechsQol;

namespace RougeMechsClasses
{
    public class SpiritMech
    {
        public string name = "NONE";

        public RougeMechStats stats;
        public int armorValue; //summary value of armor from equipment
        public int weight;

        public Vector2 position;
        public Vector2 oldPosition;
        public char icon;

        Armor armor;
        Accessory[] accessory = new Accessory[2];


        protected SpiritMech() { }
        public SpiritMech(int maxHP, Vector2 position)
        {
            this.position = position;

            armor.LoadFromFile(5);
            accessory[0].LoadFromFile(6);

            Update(true);
        }
        public void Update(bool firstSetup)
        {
            if (firstSetup)
            {
                stats.Setup();
                armorValue = 0;
                weight = 0;
            }

            weight = armor.weight + accessory[0].weight;
            armorValue = armor.armor;

            stats.vit1 = armor.vit + accessory[0].vit;
            stats.cap1 = armor.cap + accessory[0].cap;
            stats.str1 = armor.str + accessory[0].str;
            stats.agi1 = armor.agi + accessory[0].agi;
            stats.spi1 = armor.spi + accessory[0].spi;            

            stats.vit2 = stats.vit + stats.vit1;
            stats.cap2 = stats.cap + stats.cap1;
            stats.str2 = stats.str + stats.str1;
            int AGI = stats.agi + stats.agi1;
            stats.spi2 = stats.spi + stats.spi1;            

            stats.agi2 = Convert.ToInt16(AGI * (1d - (Convert.ToDouble( weight)/ (Convert.ToDouble(stats.str2) * 20d))));

            if (stats.agi2 < 0) { stats.agi2 = 0; }

            stats.maxHP = stats.vit2 * 15;
            stats.maxMP = stats.cap2 * 10;
            stats.maxShd = stats.cap2 * 3;

            stats.shieldRegeneration = Convert.ToInt16(stats.cap2 * 0.5 + stats.spi2 * 0.25);
            if(stats.HP > stats.maxHP)
            {
                stats.HP = stats.maxHP;
            }

            if (firstSetup)
            {
                stats.HP = stats.maxHP;
                stats.MP = stats.maxMP;
            }
        }
        public void MoveTo(Vector2 newPosition)
        {
            QoL.GotoXY(oldPosition); Console.Write(" ");
            QoL.GotoXY(position); Console.Write(".");
            QoL.GotoXY(newPosition); Console.Write(icon);

            Console.CursorVisible = false;

            oldPosition = position;
            position = newPosition;
        }
        public void ShowOnScreen()
        {
            QoL.GotoXY(position); Console.Write(icon);
        }
        public void DisplayStats(Vector2 ULCornerPosition)
        {
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(2, 1))); Console.Write(name);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(9, 2))); Console.Write(this.stats.HP);
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(15, 2))); Console.Write(this.stats.maxHP);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(9, 3))); Console.Write(this.stats.MP);
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(15, 3))); Console.Write(this.stats.maxMP);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(9, 4))); Console.Write(this.stats.shd);
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(15, 4))); Console.Write(this.stats.maxShd);


            Console.ForegroundColor = ConsoleColor.DarkGray;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 6))); Console.Write(this.armorValue);
            Console.ForegroundColor = ConsoleColor.Cyan;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(12, 6))); Console.Write("| " + stats.shieldRegeneration);

            Console.ForegroundColor = ConsoleColor.Red;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 7))); Console.Write(this.stats.vit + "<" + stats.vit1 + "> (" + stats.vit2 + ")");
            Console.ForegroundColor = ConsoleColor.Cyan;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 8))); Console.Write(this.stats.cap + "<" + stats.cap1 + "> (" + stats.cap2 + ")");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 9))); Console.Write(this.stats.str + "<" + stats.str1 + "> (" + stats.str2 + ")");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 10))); Console.Write(this.stats.agi + "<" + stats.agi1 + "> (" + stats.agi2 + ")");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 11))); Console.Write(this.stats.spi + "<" + stats.spi1 + "> (" + stats.spi2 + ")");
        }
        public void ReceiveDmg(int dmg, int bluntDmg, int penetration)
        {
            int DMG;
            if (penetration == 0) DMG = 0;
            else
                DMG = Convert.ToInt16(dmg * (1d - (Convert.ToDouble(armorValue) / Convert.ToDouble(penetration))));
            if (DMG > 0) { stats.HP -= DMG; }

            DMG = bluntDmg - stats.str2;
            if (DMG > 0) { stats.HP -= DMG; }
        }
        public void ChangeItem(int itemIndex, int newItemID)
        {

        }
        public void Attack()
        {

        }
    }
    public class Enemy : SpiritMech
    {

    }    
}
