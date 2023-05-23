//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
using Valery_s_Dungeon;

namespace Valery_sDungeon
{
    public class Market
    {
        public static void LoadShop(Player p)
        {
            MarketRun(p);

        }

        public static void MarketRun(Player p)
        {

            int potionP;
            int armorP;
            int weaponP;
            int diffP;


            while (true)
            {
                potionP = 30 + 10 * p.potions;
                armorP = 100 + (p.armorV + 1);
                weaponP = 100 + p.weaponV;
                diffP = 250 + 100 * p.diffmods;




                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"
                                                       
      .-')    ('-. .-.                _ (`-.  
     ( OO ). ( OO )  /               ( (OO  ) 
    (_)---\_),--. ,--. .-'),-----.  _.`     \ 
    /    _ | |  | |  |( OO'  .-.  '(__...--'' 
    \  :` `. |   .|  |/   |  | |  | |  /  | | 
     '..`''.)|       |\_) |  |\|  | |  |_.' | 
    .-._)   \|  .-.  |  \ |  | |  | |  .___.' 
    \       /|  | |  |   `'  '-'  ' |  |      
     `-----' `--' `--'     `-----'  `--'                                                 
                                                    
                ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                //Console.WriteLine("             (1)WEAPON     - " + weaponP);
                //Console.WriteLine("             (2)ARMOR      - " + armorP);
                //Console.WriteLine("             (3)DIFF MODS  - " + diffP);
                //Console.WriteLine("             (4)POTION    - " + potionP);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("             (1)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("WEAPON     - " + weaponP);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("             (2)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("ARMOR     - " + armorP);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("             (3)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("DIFF MODS     - " + diffP);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("             (4)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("POTION     - " + potionP);
                Console.WriteLine(" ");

                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                //Console.WriteLine("             PRESS E TO EXIT");
                //Console.WriteLine("             PRESS Q TO EXIT with style (;");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("             PRESS");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" E ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("TO EXIT");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("             PRESS");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Q ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("TO QUIT");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("            " + p.name + "'s STATS ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("             " + p.name);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("'s STATS ");
                Console.WriteLine(" ");
                Console.ResetColor();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                //Console.WriteLine("             coins - " + p.coins);
                //Console.WriteLine("             health - " + p.health);
                //Console.WriteLine("             weapon - " + p.weaponV);
                //Console.WriteLine("             armor - " + p.armorV);
                //Console.WriteLine("             potions - " + p.potions);
                //Console.WriteLine("             difficulty - " + p.diffmods);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("             coins - ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p.coins);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("             health - ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p.health);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("             weapon - ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p.weaponV);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("             armor - ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p.armorV);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("             potions - ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p.potions);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("             difficulty - ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p.diffmods);
                Console.WriteLine(" ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("             LEVEL: " + p.level);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("    -----> [ ");
                Console.ResetColor();
                Dungeon.ProgressBar("infront", "back", ((decimal)p.xp / (decimal)p.GetLevelUpV()), 25);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  ]<-----");
                Console.ResetColor();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();


                string input = Console.ReadLine()!.ToLower();
                if (input == "4" || input == "potion")
                {
                    TryToBuy("potion", potionP, p);
                }
                else if (input == "1" || input == "weapon")
                {
                    TryToBuy("weapon", weaponP, p);
                }
                else if (input == "2" || input == "armor")
                {
                    TryToBuy("armor", armorP, p);
                }
                else if (input == "3" || input == "diff" || input == "difficulty")
                {
                    TryToBuy("diff", diffP, p);
                }
                else if (input == "q" || input == "Q" || input == "quit" || input == "QUIT")
                {
                    Dungeon.QUIT();
                }
                else if (input == "e" || input == "E" || input == "exit" || input == "EXIT")

                {
                    break;
                }


            }

        }

        static void TryToBuy(string item, int cost, Player p)
        {
            if (p.coins >= cost)
            {
                if (item == "potion")
                {
                    p.potions++;

                }
                else if (item == "weapon")
                {
                    p.weaponV++;
                }
                else if (item == "armor")
                {
                    p.armorV++;
                }
                else if (item == "diff")
                {
                    p.diffmods++;
                }

                p.coins -= cost;
            }
            else
            {
                Console.WriteLine("You need more coins, go kill some foes");
                Console.ReadKey();
            }
        }
    }
}

