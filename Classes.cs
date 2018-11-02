using System;
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
        public RougeMechStats stats;

        public Vector2 position;
        public Vector2 oldPosition;
        public char icon;

        protected SpiritMech() { }
        public SpiritMech(int maxHP, Vector2 position)
        {
            this.stats.maxHP = maxHP;

            this.position = position;

            Setup(true);
        }
        public void Setup(bool firstSetup)
        {
            if (firstSetup)
            {
                stats.Setup();
            }

            stats.maxHP = stats.vit2 * 15;
            stats.maxMP = stats.cap2 * 10;
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
        public void DrawStats(Vector2 ULCornerPosition)
        {
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(9, 1))); Console.Write(this.stats.HP);
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(15, 1))); Console.Write(this.stats.maxHP);
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(9, 2))); Console.Write(this.stats.MP);
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(15, 2))); Console.Write(this.stats.maxMP);

            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 4))); Console.Write(this.stats.vit + " ");
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 5))); Console.Write(this.stats.cap);
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 6))); Console.Write(this.stats.str);
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 7))); Console.Write(this.stats.agi);
            QoL.GotoXY(Vector2.SumUp(ULCornerPosition, new Vector2(6, 8))); Console.Write(this.stats.spi);
        }
        public void Attack()
        {

        }
    }
    public class Enemy : SpiritMech
    {

    }    
}
