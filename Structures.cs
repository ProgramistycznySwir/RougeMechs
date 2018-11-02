using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RougeMechsGraphics;
using RougeMechsQol;
using RougeMechsClasses;

namespace RougeMechsStructures
{
    public struct Vector2
    {
        public int x, y;
        /// <summary>
        /// Static variable set to 0; 0
        /// </summary>
        public static Vector2 zero = new Vector2(0, 0);

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(Vector2 vector2)
        {
            this = vector2;
        }
        /// <summary>
        /// Just sets Vector to 0; 0 :D (and that was my first XML comment, btw)
        /// </summary>
        public void Zero()
        {
            x = 0;
            y = 0;
        }
        /// <summary>
        /// Compares current vector to passed vector, and returns bool;
        /// </summary>
        public bool IsEqualTo(Vector2 vectorToCompare)
        {
            if (this.x != vectorToCompare.x || this.y != vectorToCompare.y)
            {
                return false;
            }
            else return true;
        }
        /// <summary>
        /// Returns distance between two given points in space
        /// </summary>
        public float DistanceTo(Vector2 vectorToCompare)
        {
            double x = Math.Abs(this.x - vectorToCompare.x);
            double y = Math.Abs(this.y - vectorToCompare.y);

            return Convert.ToSingle(Math.Pow(x + y, 2));
        }
        /// <summary>
        ///Returns Vector2 which is sum of 2 Vector2 structs
        /// </summary>
        public static Vector2 SumUp(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
    }
    public struct RougeMechStats
    {
        public int HP, maxHP;
        public int MP, maxMP;
        public int shd, maxShd;
        public int shieldRegeneration;

        public int vit, cap, str, agi, spi; //VITality, CAPacity (amount of MP), STRenght, AGIlity (ability to avoid and land attacks and more), SPIrit (strenght of used magic)
        public int vit1, cap1, str1, agi1, spi1; //from equipment
        public int vit2, cap2, str2, agi2, spi2; //wypadkowy po doliczeniu buffów i debuffów
        public int lvl;
        public int skillPoints;
        /// <summary>
        /// Method to make stats values not equal random values
        /// </summary>
        public void Setup()
        {
            vit = 5;
            cap = 5;
            str = 5;
            agi = 5;
            spi = 5;

            vit1 = 0;
            cap1 = 0;
            str1 = 0;
            agi1 = 0;
            spi1 = 0;

            vit2 = 5;
            cap2 = 5;
            str2 = 5;
            agi2 = 5;
            spi2 = 5;

            lvl = 1;
            skillPoints = 0;
        }
    }
    public struct Item
    {
        int price;
        int slot;        
    }
    public struct Weapon
    {
        public int bluntDamage, damage;
        public int penetration;
        public void DealDamage(SpiritMech target)
        {
            target.stats.HP -= bluntDamage;
            target.stats.HP -= Convert.ToInt16(damage * 1);
        }
    }
}
