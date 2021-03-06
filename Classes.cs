﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RougeMechs;

using RougeMechsStructures;
using static RougeMechsQol.QoL;
using RougeMechsGraphics;

namespace RougeMechsClasses
{
    public class SpiritMech : PrimitiveEntity
    {
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
        public new void Update(bool firstSetup)
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
        
        public void ChangeItem(int itemIndex, int newItemID)
        {

        }
    }
    public class PrimitiveEntity
    {
        public string name = "NONE";

        public RougeMechStats stats;
        public int armorValue; //summary value of armor from equipment
        public int weight;

        public Vector2 position;
        public Vector2 oldPosition;
        public char icon;

        public List<Attack> attacks = new List<Attack>();

        public void Update(bool firstSetup)
        {
            if (firstSetup)
            {
                stats.Setup();
                armorValue = 0;
                weight = 0;
            }

            stats.vit2 = stats.vit + stats.vit1;
            stats.cap2 = stats.cap + stats.cap1;
            stats.str2 = stats.str + stats.str1;
            int AGI = stats.agi + stats.agi1;
            stats.spi2 = stats.spi + stats.spi1;

            stats.agi2 = Convert.ToInt16(AGI * (1d - (Convert.ToDouble(weight) / (Convert.ToDouble(stats.str2) * 20d))));

            if (stats.agi2 < 0) { stats.agi2 = 0; }

            stats.maxHP = stats.vit2 * 15;
            stats.maxMP = stats.cap2 * 10;
            stats.maxShd = stats.cap2 * 3;

            stats.shieldRegeneration = Convert.ToInt16(stats.cap2 * 0.5 + stats.spi2 * 0.25);
            if (stats.HP > stats.maxHP)
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
            GotoXY(oldPosition); Console.Write(" ");
            GotoXY(position); Console.Write(".");
            GotoXY(newPosition); Console.Write(icon);

            Console.CursorVisible = false;

            oldPosition = position;
            position = newPosition;
        }
        public void ShowOnScreen()
        {
            GotoXY(position); Console.Write(icon);
        }
        public void DisplayStats(Vector2 ULCornerPosition)
        {
            GotoXY(ULCornerPosition + new Vector2(2, 1)); Space(24); Console.Write(name); // names of creatures cant be longer than 18
            Console.ForegroundColor = ConsoleColor.DarkRed;
            GotoXY(ULCornerPosition + new Vector2(9, 2)); Space(8); Console.Write(this.stats.HP);
            GotoXY(ULCornerPosition + new Vector2(18, 2)); Space(8); Console.Write(this.stats.maxHP);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            GotoXY(ULCornerPosition + new Vector2(9, 3)); Space(8); Console.Write(this.stats.MP);
            GotoXY(ULCornerPosition + new Vector2(18, 3)); Space(8); Console.Write(this.stats.maxMP);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            GotoXY(ULCornerPosition + new Vector2(9, 4)); Space(8); Console.Write(this.stats.shd);
            GotoXY(ULCornerPosition + new Vector2(18, 4)); Space(8); Console.Write(this.stats.maxShd);


            Console.ForegroundColor = ConsoleColor.DarkGray;
            GotoXY(ULCornerPosition + new Vector2(6, 6)); Space(8); Console.Write(this.armorValue);
            Console.ForegroundColor = ConsoleColor.Cyan;
            GotoXY(ULCornerPosition + new Vector2(15, 6)); Space(10); Console.Write("| " + stats.shieldRegeneration); //space is bigger couse there is "| "

            Console.ForegroundColor = ConsoleColor.Red;
            GotoXY(ULCornerPosition + new Vector2(6, 7)); Space(20); Console.Write(this.stats.vit + "<" + stats.vit1 + "> (" + stats.vit2 + ")");
            Console.ForegroundColor = ConsoleColor.Cyan;
            GotoXY(ULCornerPosition + new Vector2(6, 8)); Space(20); Console.Write(this.stats.cap + "<" + stats.cap1 + "> (" + stats.cap2 + ")");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            GotoXY(ULCornerPosition + new Vector2(6, 9)); Space(20); Console.Write(this.stats.str + "<" + stats.str1 + "> (" + stats.str2 + ")");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            GotoXY(ULCornerPosition + new Vector2(6, 10)); Space(20); Console.Write(this.stats.agi + "<" + stats.agi1 + "> (" + stats.agi2 + ")");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            GotoXY(ULCornerPosition + new Vector2(6, 11)); Space(20); Console.Write(this.stats.spi + "<" + stats.spi1 + "> (" + stats.spi2 + ")");

            Console.ResetColor();
        }
        public void ReceiveDmg(int dmg, int bluntDmg, int penetration)
        {
            int DMG, DMGb; //dmg after calculations
            if (penetration == 0) DMG = 0;
            else
                DMG = Convert.ToInt16(dmg * (1d - (Convert.ToDouble(armorValue) / Convert.ToDouble(penetration))));
            if (DMG > 0) { stats.HP -= DMG; }

            DMGb = Convert.ToInt16(bluntDmg - stats.str2 * 0.5d);
            if (DMGb > 0) { stats.HP -= DMGb; }
            Log.Write("BattleMaster", name + " Received: " + (DMG + DMGb) + " dmg (normal: " + DMG + " blunt: " + DMGb + ")");
        }
        public void Attack()
        {

        }

        
        public void LoadFromFile(int ID)
        {
            IEnumerable<string> statsLoaded = System.IO.File.ReadLines("Accessories.txt").Skip(ID*3).Take(3);//reads the enemy info from .txt
            string[][] stats = new string[][]
            {
                statsLoaded.First().Split(';'),
                statsLoaded.Skip(1).First().Split(';'),
                statsLoaded.Skip(2).First().Split(';')
            };

            this.name = stats[0][1];

            this.stats.vit = Convert.ToInt16(stats[1][0]);
            this.stats.cap = Convert.ToInt16(stats[1][1]);
            this.stats.str = Convert.ToInt16(stats[1][2]);
            this.stats.agi = Convert.ToInt16(stats[1][3]);
            this.stats.spi = Convert.ToInt16(stats[1][4]);
            this.armorValue = Convert.ToInt16(stats[1][5]);

            int numberOfAttacks = Convert.ToInt16(stats[2][0]);

            for (int a = 1 ;a <= numberOfAttacks; a++)
            {
                this.attacks.Add(new Attack(stats[]));
            }
        }
    }
    public class Enemy : SpiritMech
    {

    }

    public class GrandParent
    {
        public GrandParent()
        {
            Log.Write("GrandParent", "It's me");
        }
    }
    public class Parent : GrandParent
    {
        public Parent()
        {
            Log.Write("Parent", "It's me");
        }
        public Parent(bool a)
        {
            Log.Write("Parent", "It's me, called with bool");
        }
    }
    public class Child : Parent
    {
        public Child()
        {
            Log.Write("Child", "It's me");
        }
        //public Child(bool b)
        //{
        //    Log.Write("Child", "It's me, called with bool");
        //}
    }
}
