﻿using System;
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
            bool endTurn = false;

            //Draw.Kolorki(); //20:54

            Console.BufferHeight = screenSize.y;

            Console.Clear();

            Vector2 frameSize = new Vector2(124,62);
            Draw.Frame(Vector2.zero, frameSize);

            Log.Setup(new Vector2(150, 0));

            SpiritMech player = new SpiritMech(20, new Vector2(5, 5));
            player.icon = '@';
            player.Update(true);

            Draw.SMStats(new Vector2(125, 0));
            player.DisplayStats(new Vector2(125, 0));

            int vara = 0;            

            //Console.Clear();

            //string[] words = Item.LoadFromFile(1).First().Split(';');
            //Console.Write("\n\n\n" + (2 + Convert.ToInt16(words[2])) + "\n" + words[2] + "\n\n\n");

            //QoL.Blockade();
            //Console.Write("  weight  " + player.weight);

            while (!gameover)
            {
                endTurn = false;
                ConsoleKeyInfo key = Console.ReadKey(true);

                vara++;
                //Console.WriteLine("It's me!" + vara + "  ");
                //player.MoveTo(new Vector2(player.position.x, player.position.y));
                //Console.Write(Console.CursorTop + " done A Thing " + key.KeyChar);
                while (!endTurn)
                {
                    switch (key.KeyChar) ///Turn of Player
                    {
                        case 'w':
                            {
                                player.MoveTo(new Vector2(Vector2.SumUp(player.position, new Vector2(0, -2))));
                                break;
                            }
                        case 's':
                            {
                                player.MoveTo(new Vector2(Vector2.SumUp(player.position, new Vector2(0, 1))));
                                break;
                            }
                        case 'a':
                            {
                                player.MoveTo(new Vector2(Vector2.SumUp(player.position, new Vector2(-1, 0))));
                                break;
                            }
                        case 'd':
                            {
                                player.MoveTo(new Vector2(Vector2.SumUp(player.position, new Vector2(1, 0))));
                                break;
                            }
                        case 'o':
                            {
                                player.ReceiveDmg(10, 6, 5);
                                player.Update(false);
                                player.DisplayStats(new Vector2(125, 0));
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Ain't done a shit");
                                break;
                            }
                    }
                    endTurn = true;
                }
                
            }
            QoL.Blockade();
        }
    }    
}
