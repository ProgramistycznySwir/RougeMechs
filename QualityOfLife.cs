using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RougeMechs;
using RougeMechsStructures;

namespace RougeMechsQol
{
    public static class QoL
    {
        /// </summary>
        ///Sets cursor position to given coords, and checks if given position don't exceed screen size
        /// </summary>
        public static bool GotoXY(int x, int y) ///Quality of Life Feature
        {
            if (x >= 0 && x <= Program.screenSize.x && y >= 0 && y <= Program.screenSize.y)
            {
                Console.SetCursorPosition(x, y);
                return true;
            }
            return false;
        }
        /// </summary>
        ///Sets cursor position to given position (Vector2), and checks if given position don't exceed screen size
        /// </summary>   
        public static bool GotoXY(Vector2 position) ///same method but overloads with Vector2
        {
            if (position.x >= 0 && position.x <= Program.screenSize.x && position.y >= 0 && position.y <= Program.screenSize.y)
            {
                Console.SetCursorPosition(position.x, position.y);
                return true;
            }
            return false;
        }
    }
}
