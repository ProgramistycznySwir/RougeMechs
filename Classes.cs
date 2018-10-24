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
    class Class1
    {
        
    }
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
            QoL.GotoXY(newPosition); Console.Write(icon);
            QoL.GotoXY(position); Console.Write("O");
            QoL.GotoXY(oldPosition); Console.Write(" ");
            oldPosition = position;
            position = newPosition;
        }
    }
}
