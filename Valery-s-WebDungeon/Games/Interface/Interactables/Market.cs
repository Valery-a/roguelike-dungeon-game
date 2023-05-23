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
        public static async Task LoadShop(Player p)
        {
            await MarketRun(p);

        }

        public static async Task MarketRun(Player p)
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




                await BlazorConsole.Clear();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.DarkCyan;
                await BlazorConsole.WriteLine(@"
                                                       
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
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Blue;
                //await BlazorConsole.WriteLine("             (1)WEAPON     - " + weaponP);
                //await BlazorConsole.WriteLine("             (2)ARMOR      - " + armorP);
                //await BlazorConsole.WriteLine("             (3)DIFF MODS  - " + diffP);
                //await BlazorConsole.WriteLine("             (4)POTION    - " + potionP);
                BlazorConsole.ForegroundColor = ConsoleColor.DarkMagenta;
                await BlazorConsole.Write("             (1)");
                BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                await BlazorConsole.Write("WEAPON     - " + weaponP);
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkMagenta;
                await BlazorConsole.Write("             (2)");
                BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                await BlazorConsole.Write("ARMOR     - " + armorP);
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkMagenta;
                await BlazorConsole.Write("             (3)");
                BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                await BlazorConsole.Write("DIFF MODS     - " + diffP);
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkMagenta;
                await BlazorConsole.Write("             (4)");
                BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                await BlazorConsole.Write("POTION     - " + potionP);
                await BlazorConsole.WriteLine(" ");

                BlazorConsole.ResetColor();

                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                //await BlazorConsole.WriteLine("             PRESS E TO EXIT");
                //await BlazorConsole.WriteLine("             PRESS Q TO EXIT with style (;");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("             PRESS");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.Write(" E ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("TO EXIT");
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("             PRESS");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.Write(" Q ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("TO QUIT");
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                //await BlazorConsole.ForegroundColor = ConsoleColor.Red;
                //await BlazorConsole.WriteLine("            " + p.name + "'s STATS ");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.Write("             " + p.name);
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("'s STATS ");
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ResetColor();
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkGreen;
                //await BlazorConsole.WriteLine("             coins - " + p.coins);
                //await BlazorConsole.WriteLine("             health - " + p.health);
                //await BlazorConsole.WriteLine("             weapon - " + p.weaponV);
                //await BlazorConsole.WriteLine("             armor - " + p.armorV);
                //await BlazorConsole.WriteLine("             potions - " + p.potions);
                //await BlazorConsole.WriteLine("             difficulty - " + p.diffmods);
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("             coins - ");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.Write(p.coins);
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("             health - ");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.Write(p.health);
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("             weapon - ");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.Write(p.weaponV);
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("             armor - ");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.Write(p.armorV);
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("             potions - ");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.Write(p.potions);
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("             difficulty - ");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.Write(p.diffmods);
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.Red;
                await BlazorConsole.WriteLine("             LEVEL: " + p.level);
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.Write("    -----> [ ");
                BlazorConsole.ResetColor();
                await Dungeon.ProgressBar("infront", "back", ((decimal)p.xp / (decimal)p.GetLevelUpV()), 25);
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.WriteLine("  ]<-----");
                BlazorConsole.ResetColor();
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();


                string input = (await BlazorConsole.ReadLine()!).ToLower();
                if (input == "4" || input == "potion")
                {
                    await TryToBuy("potion", potionP, p);
                }
                else if (input == "1" || input == "weapon")
                {
                    await TryToBuy("weapon", weaponP, p);
                }
                else if (input == "2" || input == "armor")
                {
                    await TryToBuy("armor", armorP, p);
                }
                else if (input == "3" || input == "diff" || input == "difficulty")
                {
                    await TryToBuy("diff", diffP, p);
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

        static async Task TryToBuy(string item, int cost, Player p)
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
                await BlazorConsole.WriteLine("You need more coins, go kill some foes");
                await BlazorConsole.ReadKey();
            }
        }
    }
}

