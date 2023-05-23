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
        public static void BadEnding1()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(MainSprites.OldManHouseEnding);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            TownInteraction.PrintEnding("After you gave the note to the demon, you went to visit the old man in his house.");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(MainSprites.OldGuyTransformed);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            TownInteraction.PrintEnding("");
            TownInteraction.PrintEnding("The demon realized who the old man was from the note and transformed him into a monster.");
            TownInteraction.PrintEnding("You started to yell at him to not kill you and that you are a friend, but to not avail. He kills you!");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TownInteraction.PrintEnding("GAME OVER!");
            Console.ResetColor();
            Console.ReadKey();
            System.Environment.Exit(0);
        }

        public static void BadEnding()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(MainSprites.Castle);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            TownInteraction.PrintEnding("After you reported the demon to the guards, the villagers tought that it will be safe, for them to rebuild!");
            TownInteraction.PrintEnding("In 4 months they managed to build a whole castle from the ruins of the old ones and kill a ton of the undead creatures lurking!");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(MainSprites.CastleBurning);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            TownInteraction.PrintEnding("Unfortunately the same night they moved all the remaining humans to the new castle that they will be calling home.");
            TownInteraction.PrintEnding("The demons striked!");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TownInteraction.PrintEnding("GAME OVER!");
            Console.ResetColor();
            Console.ReadKey();
            System.Environment.Exit(0);
        }
    }
}

