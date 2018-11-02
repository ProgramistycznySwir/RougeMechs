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

            stats.maxHP = stats.vit * 15;
            stats.maxMP = stats.cap * 10;

            if (firstSetup)
            {
                stats.Setup();
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
        public void Attack()
        {

        }
    }
    public class Enemy : SpiritMech
    {

    }
    public class Parent
    {
        protected Parent()
        {
            Console.WriteLine("Parent");
        }
        protected Parent(int a)
        {
            Console.WriteLine("ParentINT");
        }
    }
    public class Child : Parent
    {
        public Child()
        {
            Console.WriteLine("Child");
        }
    }
}
