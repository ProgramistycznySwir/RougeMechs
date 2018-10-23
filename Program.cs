using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RougeMechs
{
    class Program
    {
        public static void Kolorki() ///Do sprawdzania kolorów (tak paleta)
        {
            Console.Write(Console.ForegroundColor);
            Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("Black");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Blue");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("Cyan");
            Console.ForegroundColor = ConsoleColor.DarkBlue; Console.WriteLine("DarkBlue");
            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine("DarkCyan");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("DarkGray");
            Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("DarkGreen");
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("DarkMagenta");
            Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("DarkRed");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("DarkYellow");
            Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("Gray");
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Green");
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("Magenta");
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Red");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("White");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Yellow");
        }


        static void Main(string[] args)
        {
            Console.SetWindowSize(237, 84); //max: 240;84
            Console.CursorVisible = false;
            Console.Title = "Sky Commander 0.1.4 (let's talk 'bout power display)";
            //Console.ForegroundColor = ConsoleColor.White;

            //Console.BackgroundColor = ConsoleColor.Red; //Sets console background to red
            Console.WriteLine("I'm Alive!");
            Console.WriteLine("+---+---+---+---««««█▓▒░ ⌂⌂\n");
            PercentSimple(5, 23, true);
            int winx = (240 - 73) - 3;
            int winy = (84 - 34) - 2;
            Ship ship = new Ship();

            Draw.VerticalLine(118);

            Draw.UI(winx, winy);

            ship.WriteShipInfo(Draw.winx_ShipInfo, Draw.winy_ShipInfo);

            ship.WriteRepirPriority(Draw.winx_Diag, Draw.winy_Diag);

            ship.WriteShipPDSSettings(Draw.winx_PDSSettings, Draw.winy_PDSSettings);

            ship.Diagnostics(Draw.winx_Diag, Draw.winy_Diag);

            ship.WritePowerDistrubuted(Draw.winx_Diag, Draw.winy_Diag);

            Draw.YodaArt(229, 71);
            Draw.R2D2Art(228, 77);
            Draw.DarthVaderArt(10, 10);
            ///stop shit from doin shit
            for (; ; )
            {
                Console.ReadKey();
            }

        }
        public class Ship ///SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   SHIP CLASS   
        {
            public string[] name = new string[3]; //nazwa, klasa, model (napis)
            public int shipclass;              //klasa okretu
            public int FleetID;                //ID w flocie

            public double[] poss = new double[4];  //positionX, positionY, azimuth, speed
            public double[] accel = new double[3]; //current, max posible, factory

            public bool[,] moduleExist = new bool[5, 10]; //Jak nizej, ta tablica sprawdza czy modul wgle jest
            public int[,,] moduleHP = new int[5, 10, 2]; //POW, PDS, LOG, OXG, ENG, THR, MAN, SHD, DEF, WEP ; CurrentHP, MaxHP
            public bool[,] statusExist = new bool[5, 6];
            public int[,,] status = new int[5, 6, 2]; //FIR, INT, OXG ,HP,  SHD, REF ; Current, Max

            public int[] RT = new int[2]; //current Repair Tokens production, fabric Repair Tokens production
            public int[] repairPriority = new int[17]; //Section: N,L,C,R,S, POW, PDS, LOG, OXG, ENG, TRH, MAN, SHD, DEF, WEP, FIR, INT

            public int[] energy = new int[3]; //current energy stored, current energy storage, factory energy storage
            public int[] reactor = new int[3]; //current reactors power, fabric reactors power, balance
            public int[] PDSSetting = new int[9]; //PDS, LOG, OXG, ENG, THR, MAN, SHD, DEF, WEP
            public int[,] modulePower = new int[9, 2]; //PDS, LOG, OXG, ENG, THR, MAN, SHD, DEF, WEP; supply, demand

            public int[,] winSize = new int[1, 2]; //drugi wymiar to x i y; Diagnostics (jest to wymiar dla kursora)

            public Ship() ///Constructor - Narazie tylko defaultuje wartosci
            {
                Console.WriteLine("Also does shit, but with class");
                for (int a = 0; a < 17; a++) { repairPriority[a] = 3; }
                for (int a = 0; a < 5; a++)
                {
                    for (int b = 0; b < 10; b++)
                    {
                        moduleExist[a, b] = true;
                    }
                    for (int b = 0; b < 6; b++)
                    {
                        statusExist[a, b] = true;
                    }
                }
                for (int a = 0; a < 5; a++)
                {
                    for (int b = 0; b < 10; b++)
                    {
                        moduleHP[a, b, 0] = 100;
                        moduleHP[a, b, 1] = 100;
                    }
                    for (int b = 0; b < 6; b++)
                    {
                        status[a, b, 0] = 100;
                        status[a, b, 1] = 100;
                    }
                    for (int b = 0; b < 9; b++)
                    {
                        modulePower[b, 0] = 100;
                        modulePower[b, 1] = 100;
                    }
                }

                winSize[0, 0] = 5;
                winSize[0, 1] = 16;
                name[0] = "Rocinante";
                moduleHP[2, 5, 0] = 5;
            }
            public void Diagnostics(int x, int y) ///Diagnostics - pisze w tabelce stan okrętu
            {
                int a1 = 0;
                for (int a = 0; a < 20; a += 4)
                {
                    int b1 = 0;
                    for (int b = 0; b < 32; b += 2)
                    {
                        GotoXY(x + 7 + a, y + 3 + b);
                        if (b < 20 && moduleExist[a1, b1] == true)
                        {
                            PercentSimple(moduleHP[a1, b1, 0], moduleHP[a1, b1, 1], true);
                            b1++;
                        }

                        /*else if (b < 20 && moduleExist[a1, b1] == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("NAN");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            b1++;
                        } */
                        else if (statusExist[a1, b1 - 10] == true) { PercentSimple(status[a1, b1 - 10, 0], status[a1, b1 - 10, 1], true); }
                        /*else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("NAN");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            b1++;
                        }*/
                    }
                    a1++;
                }
            }
            public void WriteRepirPriority(int x, int y)
            {
                int b = 0;
                for (int a = 0; a < 20; a += 4)
                {
                    GotoXY(x + 9 + a, y + 1); Console.Write(repairPriority[b]);
                    b++;
                }
                for (int a = 2; a < 26; a += 2)
                {
                    GotoXY(x + 5, y + 1 + a); Console.Write(repairPriority[b]);
                    b++;
                }
            }
            public void WriteShipInfo(int x, int y)
            {
                GotoXY(x + 13, y + 2); Console.Write(name[0]);
                GotoXY(x + 13, y + 3); Console.Write(name[1]);
                GotoXY(x + 13, y + 4); Console.Write(name[2]);
                GotoXY(x + 13, y + 5); Console.Write(FleetID);
                GotoXY(x + 12, y + 7); Console.Write(poss[0]);
                GotoXY(x + 12, y + 8); Console.Write(poss[1]);
                GotoXY(x + 12, y + 9); Console.Write(poss[2]);
                GotoXY(x + 12, y + 10); Console.Write(poss[3]);
                GotoXY(x + 12, y + 11); Console.Write(accel[0]);
                GotoXY(x + 20, y + 11); Console.Write(accel[1]);
                GotoXY(x + 16, y + 13); Console.Write(energy[0]);
                GotoXY(x + 24, y + 13); Console.Write(energy[1]);
                GotoXY(x + 16, y + 14); Console.Write(reactor[0]);
                GotoXY(x + 23, y + 14); Console.Write(reactor[2]);
                GotoXY(x + 16, y + 15); Console.Write(RT[0]);

            }
            public void WriteShipPDSSettings(int x, int y)
            {
                int a1 = 0;
                for (int a = 0; a < 18; a += 2)
                {
                    GotoXY(x + 1, y + 3 + a); Console.Write(PDSSetting[a1]);
                    a1++;
                }
            }
            public void WritePowerDistrubuted(int x, int y)
            {
                int a1 = 0;
                for (int a = 0; a < 18; a += 2)
                {
                    GotoXY(x + 33, y + a + 5); PercentSimple(modulePower[a1, 0], modulePower[a1, 1], true);
                    a1++;
                }
            }

        }

        ///FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS

        public static class Draw ///Class with drawing methods
        {
            public static int winx_Diag;
            public static int winy_Diag;

            public static int winx_ShipInfo;
            public static int winy_ShipInfo;

            public static int winx_PDSSettings;
            public static int winy_PDSSettings;

            public static void Title(int x, int y) //Size: 82 ; 6
            {
                //Website: http://www.kammerl.de/ascii/AsciiSignature.php
                //nice styles: italic, rounded, big, thin, doom
                //curr style: ogre (82;6)
                Console.ForegroundColor = ConsoleColor.DarkGray;
                GotoXY(x, y); Console.Write(" __ _             ___                                          _");
                GotoXY(x, y + 1); Console.Write("/ _\\ | ___   _   / __\\___  _ __ ___  _ __ ___   __ _ _ __   __| | ___ _ __");
                Console.ForegroundColor = ConsoleColor.Gray;
                GotoXY(x, y + 2); Console.Write("\\ \\| |/ / | | | / /  / _ \\| '_ ` _ \\| '_ ` _ \\ / _` | '_ \\ / _` |/ _ \\ '__|");
                GotoXY(x, y + 3); Console.Write("_\\ \\   <| |_| |/ /__| (_) | | | | | | | | | | | (_| | | | | (_| |  __/ |");
                Console.ForegroundColor = ConsoleColor.White;
                GotoXY(x, y + 4); Console.Write("\\__/_|\\_\\__,  |\\____/\\___/|_| |_| |_|_| |_| |_|\\__,_|_| |_|\\__,_|\\___|_|");
                GotoXY(x, y + 5); Console.Write("         |___/");
                Console.ForegroundColor = ConsoleColor.Gray;

            }
            ///Rysuje tabelke na diagnostyke (mozna regolowac jej polozenie za pomoca x i y)
            public static void DiagTable(int x, int y) //Size: 41 ; 34
            {
                GotoXY(x, y); Console.Write("╔═════════════════════════════╦═════╦═══╗");
                GotoXY(x, y + 1); Console.Write("║     │N  │L  │C  │R  │S  │SUM║ │PWR║EFF║");
                GotoXY(x, y + 2); Console.Write("╠═════════════════════════════╬═════╬═══╣");
                int vary = 0;
                for (int a = 0; a < 18; a += 2)
                {
                    GotoXY(x, y + a + 3); Console.Write("║     │   │   │   │   │   │   ║ │   ║   ║");
                    GotoXY(x, y + a + 4); Console.Write("║─────┼───┼───┼───┼───┼───┼───║─┼───║───║");
                    vary = a;
                }
                GotoXY(x, y + vary + 5); Console.Write("║     │   │   │   │   │   │   ║ │   ║   ║");
                GotoXY(x, y + vary + 6); Console.Write("╠═════════════════════════════╬═════╩═══╝");

                GotoXY(x, y + vary + 7); Console.Write("║     │   │   │   │   │   │   ║");
                GotoXY(x, y + vary + 8); Console.Write("║─────┼───┼───┼───┼───┼───┼───║");
                GotoXY(x, y + vary + 9); Console.Write("║     │   │   │   │   │   │   ║");
                GotoXY(x, y + vary + 10); Console.Write("╠═════════════════════════════╣");

                GotoXY(x, y + vary + 11); Console.Write("║     │   │   │   │   │   │   ║");
                GotoXY(x, y + vary + 12); Console.Write("║─────┼───┼───┼───┼───┼───┼───║");
                GotoXY(x, y + vary + 13); Console.Write("║     │   │   │   │   │   │   ║");
                GotoXY(x, y + vary + 14); Console.Write("║─────┼───┼───┼───┼───┼───┼───║");
                GotoXY(x, y + vary + 15); Console.Write("║     │   │   │   │   │   │   ║");
                GotoXY(x, y + vary + 16); Console.Write("║─────┼───┼───┼───┼───┼───┼───║");
                GotoXY(x, y + vary + 17); Console.Write("║     │   │   │   │   │   │   ║");
                GotoXY(x, y + vary + 18); Console.Write("╚═════════════════════════════╝");

                GotoXY(x + 1, y + 3); Console.Write("POW");
                GotoXY(x + 1, y + 5); Console.Write("PDS");
                GotoXY(x + 1, y + 7); Console.Write("LOG");
                GotoXY(x + 1, y + 9); Console.Write("OXG");
                GotoXY(x + 1, y + 11); Console.Write("ENG");
                GotoXY(x + 1, y + 13); Console.Write("THR");
                GotoXY(x + 1, y + 15); Console.Write("MAN");
                GotoXY(x + 1, y + 17); Console.Write("SHD");
                GotoXY(x + 1, y + 19); Console.Write("DEF");
                GotoXY(x + 1, y + 21); Console.Write("WEP");
                GotoXY(x + 1, y + 23); Console.Write("FIR");
                GotoXY(x + 1, y + 25); Console.Write("INT");
                GotoXY(x + 1, y + 27); Console.Write(" OXG");
                GotoXY(x + 1, y + 29); Console.Write(" HP");
                GotoXY(x + 1, y + 31); Console.Write(" DEF");
                GotoXY(x + 1, y + 33); Console.Write(" SHD");

                GotoXY(x + 31, y + 3); Console.Write("█████");
            }
            public static void ShipStatus(int x, int y) //Size: 32 ; 15
            {
                GotoXY(x, y); Console.Write("╔══════════════════════════════╗");
                GotoXY(x, y + 1); Console.Write("║        Current Ship:         ║");//miejsce: 18 znaków (wraz z odstepem od dwukropka)
                GotoXY(x, y + 2); Console.Write("║      Name:                   ║");
                GotoXY(x, y + 3); Console.Write("║     Class:                   ║");
                GotoXY(x, y + 4); Console.Write("║     Model:                   ║");
                GotoXY(x, y + 5); Console.Write("║Id in fleet                   ║");
                GotoXY(x, y + 6); Console.Write("║──────────────────────────────║");//miejsce: 19 znaków
                GotoXY(x, y + 7); Console.Write("║PositionX:         (         )║");
                GotoXY(x, y + 8); Console.Write("║PositionY:         (         )║");
                GotoXY(x, y + 9); Console.Write("║  Azimuth:         (         )║");
                GotoXY(x, y + 10); Console.Write("║    Speed:         (         )║"); //w nawiasach jest podana wartosc ktora przyjmie wlasciwosc jesli minie tura i nic sie nie zmieni
                GotoXY(x, y + 11); Console.Write("║    Accel:        /           ║");
                GotoXY(x, y + 12); Console.Write("║──────────────────────────────║");//miejsce: 15 znaków
                GotoXY(x, y + 13); Console.Write("║       Energy:        /       ║"); //obecna nagromadzona energia, energia maksymalna
                GotoXY(x, y + 14); Console.Write("║Reactor Power:       (       )║"); //obecna moc reaktorów, bilans energetyczny
                GotoXY(x, y + 15); Console.Write("║Repair Tokens:                ║"); //ilosc generowanych tokenow napraw
                GotoXY(x, y + 16); Console.Write("╚══════════════════════════════╝");
            }
            public static void UI(int x, int y)
            {
                ShipStatus(x, y + 18);
                DiagTable(x + 32, y);

                winx_Diag = x + 32;
                winy_Diag = y;
                winx_ShipInfo = x;
                winy_ShipInfo = y + 18;

                winx_PDSSettings = x + 62;
                winy_PDSSettings = y + 2;
            }
            public static void VerticalLine(int x)
            {
                for (int a = 0; a < 83; a++)
                {
                    GotoXY(x, a); Console.Write("║");
                }
            }
            public static void YodaArt(int x, int y) //Size: 8 ; 5
            {
                //Credits:  Website: https://www.asciiart.eu/movies/star-wars, Artist: Shanaka Dias
                GotoXY(x, y); Console.Write("__.-._");
                GotoXY(x, y + 1); Console.Write("'-._\"7'");
                GotoXY(x, y + 2); Console.Write(" /'.-c");
                GotoXY(x, y + 3); Console.Write(" |  /T");
                GotoXY(x, y + 4); Console.Write("_)_/LI");
            }
            public static void R2D2Art(int x, int y) //Size: 7 ; 5
            {
                //Credits:  Website: https://www.asciiart.eu/movies/star-wars, Artist: Shanaka Dias
                GotoXY(x, y); Console.Write("  .=.");
                GotoXY(x, y + 1); Console.Write(" '==c|");
                GotoXY(x, y + 2); Console.Write(" [)-+|");
                GotoXY(x, y + 3); Console.Write(" //'_|");
                GotoXY(x, y + 4); Console.Write("/]==;\\");
            }
            public static void DarthVaderArt(int x, int y) //Size: 35 ; 29
            {
                //Credits:  Website: http://www.chris.com/ascii/index.php?art=movies/star%20wars, Artist: Lennert Stock
                GotoXY(x, y); Console.Write(" _________________________________");
                GotoXY(x, y + 1); Console.Write("|:::::::::::::;;::::::::::::::::::|");
                GotoXY(x, y + 2); Console.Write("|:::::::::::'~||~~~``:::::::::::::|");
                GotoXY(x, y + 3); Console.Write("|::::::::'   .':     o`:::::::::::|");
                GotoXY(x, y + 4); Console.Write("|:::::::' oo | |o  o    ::::::::::|");
                GotoXY(x, y + 5); Console.Write("|::::::: 8  .'.'    8 o  :::::::::|");
                GotoXY(x, y + 6); Console.Write("|::::::: 8  | |     8    :::::::::|");
                GotoXY(x, y + 7); Console.Write("|::::::: _._| |_,...8    :::::::::|");
                GotoXY(x, y + 8); Console.Write("|::::::'~--.   .--. `.   `::::::::|");
                GotoXY(x, y + 9); Console.Write("|:::::'     =8     ~  \\ o ::::::::|");
                GotoXY(x, y + 10); Console.Write("|::::'       8._ 88.   \\ o::::::::|");
                GotoXY(x, y + 11); Console.Write("|:::'   __. ,.ooo~~.    \\ o`::::::|");
                GotoXY(x, y + 12); Console.Write("|:::   . -. 88`78o/:     \\  `:::::|");
                GotoXY(x, y + 13); Console.Write("|::'     /. o o \\ ::      \\88`::::|");
                GotoXY(x, y + 14); Console.Write("|:;     o|| 8 8 |d.        `8 `:::|");
                GotoXY(x, y + 15); Console.Write("|:.       - ^ ^ -'           `-`::|");
                GotoXY(x, y + 16); Console.Write("|::.                          .:::|");
                GotoXY(x, y + 17); Console.Write("|:::::.....           ::'     ``::|");
                GotoXY(x, y + 18); Console.Write("|::::::::-'`-        88          `|");
                GotoXY(x, y + 19); Console.Write("|:::::-'.          -       ::     |");
                GotoXY(x, y + 20); Console.Write("|:-~. . .                   :     |");
                GotoXY(x, y + 21); Console.Write("| .. .   ..:   o:8      88o       |");
                GotoXY(x, y + 22); Console.Write("|. .     :::   8:P     d888. . .  |");
                GotoXY(x, y + 23); Console.Write("|.   .   :88   88      888'  . .  |");
                GotoXY(x, y + 24); Console.Write("|   o8  d88P . 88   ' d88P   ..   |");
                GotoXY(x, y + 25); Console.Write("|  88P  888   d8P   ' 888         |");
                GotoXY(x, y + 26); Console.Write("|   8  d88P.'d:8  .- dP~ o8       |");
                GotoXY(x, y + 27); Console.Write("|      888   888    d~ o888    LS |");
                GotoXY(x, y + 28); Console.Write("|_________________________________|");
            }
        }

        ///FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS   FUNCTIONS

        public static void PercentSimple(int a, int b, bool color) ///dzieli numer a przez numer b i podaje go jako procent, bez przecinka; 3 wartość determinuje czy funkcja ma sama go wyświetlić wraz z kolorem w skali
        {
            double numa = Convert.ToDouble(a);
            double numb = Convert.ToDouble(b);
            if (color == true)
            {
                double perc = (numa / numb) * 100;
                int perc1 = Convert.ToInt32(perc);
                if (perc1 > 90) { Console.ForegroundColor = ConsoleColor.Gray; }
                else if (perc1 <= 90 && perc1 > 75) { Console.ForegroundColor = ConsoleColor.Blue; }
                else if (perc1 <= 75 && perc1 > 50) { Console.ForegroundColor = ConsoleColor.Green; }
                else if (perc1 <= 50 && perc1 > 25) { Console.ForegroundColor = ConsoleColor.Yellow; }
                else if (perc1 <= 25 && perc1 >= 0) { Console.ForegroundColor = ConsoleColor.Red; }

                if (perc1 < 100) Console.Write(" ");
                if (perc1 < 10) Console.Write(" ");

                Console.Write(perc1);

                Console.ResetColor();
            }
        }

        public static void GotoXY(int x, int y) ///Quality of Life Feature
        {
            Console.SetCursorPosition(x, y);
        }
        /* 
         _________________________________
        |:::::::::::::;;::::::::::::::::::|
        |:::::::::::'~||~~~``:::::::::::::|
        |::::::::'   .':     o`:::::::::::|
        |:::::::' oo | |o  o    ::::::::::|
        |::::::: 8  .'.'    8 o  :::::::::|
        |::::::: 8  | |     8    :::::::::|
        |::::::: _._| |_,...8    :::::::::|
        |::::::'~--.   .--. `.   `::::::::|
        |:::::'     =8     ~  \ o ::::::::|
        |::::'       8._ 88.   \ o::::::::|
        |:::'   __. ,.ooo~~.    \ o`::::::|
        |:::   . -. 88`78o/:     \  `:::::|
        |::'     /. o o \ ::      \88`::::|
        |:;     o|| 8 8 |d.        `8 `:::|
        |:.       - ^ ^ -'           `-`::|
        |::.                          .:::|
        |:::::.....           ::'     ``::|
        |::::::::-'`-        88          `|
        |:::::-'.          -       ::     |
        |:-~. . .                   :     |
        | .. .   ..:   o:8      88o       |
        |. .     :::   8:P     d888. . .  |
        |.   .   :88   88      888'  . .  |
        |   o8  d88P . 88   ' d88P   ..   |
        |  88P  888   d8P   ' 888         |
        |   8  d88P.'d:8  .- dP~ o8       |
        |      888   888    d~ o888    LS |
        |_________________________________|

            Watches the progress...


                        MMMMMM=                                      
                   .MMMMMMMMMMMMMM                                   
                 MMMMMM         MMMM                                 
              MMMMM              MMMMM.                              
        MMMMMMMM                  ?MMMM.                             
     .MMMMMMMM7MM                  MMMMM                             
     MMMMMMMMM MM                   MMMM                             
     MMMMMMMMM .MM                   MMM                             
    .MMMMMMM.   MM.M.   =MMMMMMMM.   MMM                             
     MMMMMMMM.MMMMMM.  MMMMMMMM MMM  MMM                             
     MMMMMMMMMMMM     MMMMMMMMM  MMM MMM                             
    MMM    MMM:  MM   MMMMMMMMM  MMM MMM                             
   8MM.    MMMMMMMM=  MMMMMMMM.  .M ,MM7                             
  MMMMMMMM..          MMMMM.     M  MMM                              
 .MMMMMMMMMMMMMMM       MMMMMMMMM.  MMM                              
.MMM        MMMMMMMMMMM.           MMMM                              
MMM                .~MMMMMMM.      MMM.                              
MMM.                               MMMM                               
.MMM                                MMMM                               
MMM                                DMMM                                
MMM                                 MMMM                                
MMM                                .MMM                                 
MMM                      MM        .MMM                                  
MMM                     .MM  MM.   MMM~                                  
MMM                     MMM .MM.   MMM                         MMMMM     
MMM                     MM. MMM   MMM                        MMM   MMO   
MMM                     MM  MM   .MMM                      MMMM     MM   
MM~                    MM. MMM   MMM.                     MMM      IMM   
MM.                    MM  MM.  .MMM                    .MMM.      MM    
MM                     M  MMN   .MMM                   MMMM       MM.    
MM+                   MM MMM    .MM 7MMMMMMMMMMM      MMM.       MM      
MMM                  .M  MM      MMMMMM. .. MMMMMMM MMM.       MMM.      
MMM                  +M MMM      MM    .MM     .MMMMMM.      .MMM.       
?MM                  M  MM       .      MMM      ~MM.       MMMM         
.MM                 MM  MM            ,MMMMMMMMMMM         MMMM          
MMM              MM     MM          MMMMMMMMMMMMMMM     MMMMM           
MMM            .M     N  MM                  ..MMMMM.     MMMM          
.MM             MMMM MMMMMM                     .MMMMM        DMM       
MMM              MMMMM.MM.             ,M,       .MMM.        MM       
MMM               M.                  MMM         MMM.  .MMMM         
MMMM                                              MMM.    MM          
=MMM.                            MM.             MMM      MM         
  MMMM.                          MM              MMM       M         
    MMMM                                         MMMMM,. MMM         
.          MMMMMMM.                     MMM            MMM MMMMMM.          
MMMM      MMN  .MMMMM                               .MMMD                   
MM MMN  .MM    MM MMMMMMMM~ .              M.     .MMMM                     
MM   MM$MM   MMN      MMMMMMMMMM.          M.   .MMMM                       
M.   MMM   MM              MMMMM  MMMMMMMMM~MMMMMM                         
MM      .MMN          .. . +MM,  8MM .MMMMMMMM.                            
M?    NMM           MMMMMMMMM   MM                                        
.M  .MM7            MMM MMMM   MM                                         
MMMM              OMM       .MM                                         
.                 MMM      MM                                          
                .MMM    MM                                           
                 .MMD  MMM                                           
                   MMMMM?                                            
                    MMM.                                             

 */
    }
}
