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
        /// </summary>
        ///Prevents program from closing (you must close it manually to proceed)
        /// </summary> 
        public static void Blockade()
        {
            for (; ; )
            {
                Console.WriteLine("Program ended it's work, press alt + F4 to exit...");
                Console.ReadKey();
            }
        }
        /// </summary>
        ///Writes given amount of spaces, and then go to position start of created space
        /// </summary> 
        public static void Space(int amountOfSpaces)
        {
            Vector2 pos = new Vector2(Console.CursorLeft, Console.CursorTop);
            while (amountOfSpaces > 0)
            {
                Console.Write("o");
                amountOfSpaces--;
            }
            GotoXY(pos);
        }
        /// </summary>
        ///Writes given amount of phrases
        /// </summary> 
        public static void WriteThisMuch(string phraseToWrite,int amountOfPhrases)
        {
            while (amountOfPhrases > 0)
            {
                Console.Write(phraseToWrite);
                amountOfPhrases--;
            }
        }
    }
}
