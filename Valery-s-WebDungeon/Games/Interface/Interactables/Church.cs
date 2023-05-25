//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
namespace Valery_s_Dungeon;
public class Church
{
    public static async Task LoadChurch()
    {
        if (Dungeon.currentPlayer.level < 1)
        {
            await ChurchRun();
        }
        else
            await EvilChurchRun();
    }

    public static async Task ChurchRun()
    {
        while (true)
        {
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkGray;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Green;
            await BlazorConsole.WriteLine(MainSprites.Priest);
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkGray;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkGreen;
            await BlazorConsole.WriteLine("As you approach the church, a sense of eeriness washes over you. The creaky wooden door hangs off its hinges, inviting you to enter.");
            await BlazorConsole.WriteLine("Inside, you see evidence of neglect and decay. Cobwebs hang from the rafters, and the pews are covered in a thick layer of dust. ");
            await BlazorConsole.WriteLine("The stained glass windows are cracked and faded, barely letting in any light. It's clear that this once-thriving place of worship has been long abandoned.");
            await BlazorConsole.WriteLine("But as you stand there, taking in the scene, you can't help but wonder what led to its downfall. Why is the priest icon in the middle left untouched?");
            await BlazorConsole.WriteLine("And why this church? Was it simply because it was in the middle of nowhere, forgotten and ignored by the outside world?");
            await BlazorConsole.WriteLine("Or was there something more sinister at play?");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkGray;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Blue;
            await BlazorConsole.WriteLine("                                          PRESS E TO EXIT");
            BlazorConsole.ForegroundColor = ConsoleColor.DarkGray;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();

            string input = (await BlazorConsole.ReadLine()!).ToLower();

            if (input == "e" || input == "E" || input == "exit" || input == "EXIT")
            {
                break;
            }

        }

    }
    public static async Task EvilChurchRun()
    {
        while (true)
        {
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Red;
            await BlazorConsole.WriteLine(MainSprites.Angle2);
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkGreen;
            await BlazorConsole.WriteLine("hi");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Blue;
            await BlazorConsole.WriteLine("                                          PRESS E TO EXIT");
            BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            Dungeon.currentPlayer.demonInteract = true;

            string input = (await BlazorConsole.ReadLine()!).ToLower();

            if (input == "e" || input == "E" || input == "exit" || input == "EXIT")
            {
                break;
            }

        }
    }
}

