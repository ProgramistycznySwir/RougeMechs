using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RougeMechsClasses;
using RougeMechsStructures;
using RougeMechsGraphics;
using RougeMechsQol;

namespace RougeMechs
{
    class Program
    {
        

        public static Vector2 screenSize = new Vector2(237, 63);

        static void Main(string[] args)
        {
            
            
            Console.SetWindowSize(screenSize.x, screenSize.y); //max: 227;63
            Console.CursorVisible = false;
            Console.Title = "Rouge Mechs  (Finally! I was soo stupid i leaved old SC title for couple of versions)";
            //Console.ForegroundColor = ConsoleColor.White;
            

            //Console.BackgroundColor = ConsoleColor.Red; //Sets console background to red
            //Console.WriteLine("I'm Alive!");
            //Console.WriteLine("+---+---+---+---««««█▓▒░ ⌂⌂\n");
            
            bool gameover = false;

            Draw.Kolorki(); //20:48

            Console.BufferHeight = screenSize.y;

            Console.Clear();

            Vector2 frameSize = new Vector2(124,62);
            Draw.Frame(Vector2.zero, frameSize);
            

            SpiritMech player = new SpiritMech(20, new Vector2(5, 5));
            player.icon = 'X';

            Draw.SMStats(new Vector2(150, 5), player);

            

            while (!gameover)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                


                player.MoveTo(new Vector2(player.position.x, player.position.y));

                //Console.Write(Console.CursorTop + " done A Thing " + key.KeyChar);

                switch (key.KeyChar)
                {
                    case 'w':
                        {
                            Console.Write("SHIET!!!!");
                            break;
                        }
                }
            }

            ///stop shit from doin shit
            for (; ; )
            {
                Console.ReadKey();

            }
        }
    }    
}
