//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
namespace Valery_s_Dungeon;

public class Casino
{
    static Random rand = new Random();
    public static async Task LoadCasino()
    {
        await CasinoRun();

    }

    public static async Task CasinoRun()
    {
        while (true)
        {
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.Red;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Green;
            await BlazorConsole.WriteLine(@"
                                                    
    .------..------..------..------..------..------.
    |C.--. ||A.--. ||S.--. ||I.--. ||N.--. ||O.--. |
    | :/\: || (\/) || :/\: || (\/) || :(): || :/\: |
    | :\/: || :\/: || :\/: || :\/: || ()() || :\/: |
    | '--'C|| '--'A|| '--'S|| '--'I|| '--'N|| '--'O|
    `------'`------'`------'`------'`------'`------'                                                   
                                                    
                ");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Red;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkGreen;
            await BlazorConsole.WriteLine("             (1)Jester's Gambit of 21");
            await BlazorConsole.WriteLine("             (2)Race");
            await BlazorConsole.WriteLine("             (3)Hang");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Red;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Blue;
            await BlazorConsole.WriteLine("             PRESS E TO EXIT");
            BlazorConsole.ForegroundColor = ConsoleColor.Red;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();


            string input = (await BlazorConsole.ReadLine()!).ToLower();

            if (input == "1" || input == "blackjack")
            {
                if (Dungeon.currentPlayer.coins > 25)
                    await BlackJack.Play();
                else
                    await BlazorConsole.WriteLine("You need atleast 25 coins to play!");
                await BlazorConsole.ReadKey();
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

