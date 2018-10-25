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
        public int HP, maxHP;
        public int MP, maxMP;

        public int vit = 5, cap = 5, str = 5, agi = 5, spi = 5; //VITality, CAPacity (amount of MP), STRenght, AGIlity (ability to avoid and land attacks and more), SPIrit (strenght of used magic)
        public int lvl = 1;
        public int skillPoints;

        public Vector2 position;
        public Vector2 oldPosition;
        public char icon;

        protected SpiritMech() { }
        public SpiritMech(int maxHP, Vector2 position)
        {
            this.maxHP = maxHP;

            this.position = position;

        }
        public void Setup(bool firstSetup)
        {
            maxHP = vit * 15;
            maxMP = cap * 10;
            if (firstSetup)
            {
                HP = maxHP;
                MP = maxMP;
            }
        }
        public void MoveTo(Vector2 newPosition)
        {
            QoL.GotoXY(oldPosition); Console.Write(" ");
            QoL.GotoXY(position); Console.Write(".");
            QoL.GotoXY(newPosition); Console.Write(icon);

            oldPosition = position;
            position = newPosition;
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
