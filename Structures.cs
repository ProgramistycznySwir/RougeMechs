using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RougeMechsGraphics;
using RougeMechsQol;

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
}
