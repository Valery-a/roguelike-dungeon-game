//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
using Valery_s_Dungeon.Interface;

namespace Valery_s_Dungeon
{
    public class Endings
    {
        public static async Task BadEnding1()
        {
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.Blue;
            await BlazorConsole.WriteLine(MainSprites.OldManHouseEnding);
            BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
            await TownInteraction.PrintEnding("After you gave the note to the demon, you went to visit the old man in his house.");
            await BlazorConsole.ReadKey();
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.Red;
            await BlazorConsole.WriteLine(MainSprites.OldGuyTransformed);
            BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
            await TownInteraction.PrintEnding("");
            await TownInteraction.PrintEnding("The demon realized who the old man was from the note and transformed him into a monster.");
            await TownInteraction.PrintEnding("You started to yell at him to not kill you and that you are a friend, but to not avail. He kills you!");
            await BlazorConsole.ReadKey();
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
            await TownInteraction.PrintEnding("GAME OVER!");
            BlazorConsole.ResetColor();
            await BlazorConsole.ReadKey();
            System.Environment.Exit(0);
        }

        public static async Task BadEnding()
        {
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.Blue;
            await BlazorConsole.WriteLine(MainSprites.Castle);
            BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
            await TownInteraction.PrintEnding("After you reported the demon to the guards, the villagers tought that it will be safe, for them to rebuild!");
            await TownInteraction.PrintEnding("In 4 months they managed to build a whole castle from the ruins of the old ones and kill a ton of the undead creatures lurking!");
            await BlazorConsole.ReadKey();
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.Red;
            await BlazorConsole.WriteLine(MainSprites.CastleBurning);
            BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
            await TownInteraction.PrintEnding("Unfortunately the same night they moved all the remaining humans to the new castle that they will be calling home.");
            await TownInteraction.PrintEnding("The demons striked!");
            await BlazorConsole.ReadKey();
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
            await TownInteraction.PrintEnding("GAME OVER!");
            BlazorConsole.ResetColor();
            await BlazorConsole.ReadKey();
            System.Environment.Exit(0);
        }
    }
}

