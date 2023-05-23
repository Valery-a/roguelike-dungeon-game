//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
namespace Valery_s_Dungeon;

public class Casino
{
    static Random rand = new Random();
    public static void LoadCasino()
    {
        CasinoRun();

    }

    public static void CasinoRun()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
                                                    
    .------..------..------..------..------..------.
    |C.--. ||A.--. ||S.--. ||I.--. ||N.--. ||O.--. |
    | :/\: || (\/) || :/\: || (\/) || :(): || :/\: |
    | :\/: || :\/: || :\/: || :\/: || ()() || :\/: |
    | '--'C|| '--'A|| '--'S|| '--'I|| '--'N|| '--'O|
    `------'`------'`------'`------'`------'`------'                                                   
                                                    
                ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("             (1)Jester's Gambit of 21");
            Console.WriteLine("             (2)Race");
            Console.WriteLine("             (3)Hang");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("             PRESS E TO EXIT");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.ResetColor();


            string input = Console.ReadLine()!.ToLower();

            if (input == "1" || input == "blackjack")
            {
                if (Dungeon.currentPlayer.coins > 25)
                    BlackJack.Play();
                else
                    Console.WriteLine("You need atleast 25 coins to play!");
                Console.ReadKey();
            }
            else if (input == "2" || input == "race")
            {
                //startira race-a
            }
            else if (input == "3" || input == "hang")
            {
                //za[pchva besenkata
            }
            else if (input == "e" || input == "E" || input == "exit" || input == "EXIT")

            {
                break;
            }


        }

    }
}

