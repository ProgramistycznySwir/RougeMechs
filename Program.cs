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
            Console.SetWindowSize(227, 63); //max: 240;84
            Console.CursorVisible = false;
            Console.Title = "Sky Commander 0.1.4 (let's talk 'bout power display)";
            //Console.ForegroundColor = ConsoleColor.White;

            //Console.BackgroundColor = ConsoleColor.Red; //Sets console background to red
            //Console.WriteLine("I'm Alive!");
            //Console.WriteLine("+---+---+---+---««««█▓▒░ ⌂⌂\n");

            Kolorki();
            
            ///stop shit from doin shit
            for (; ; )
            {
                Console.ReadKey();
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
                

        public static void GotoXY(int x, int y) ///Quality of Life Feature
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
