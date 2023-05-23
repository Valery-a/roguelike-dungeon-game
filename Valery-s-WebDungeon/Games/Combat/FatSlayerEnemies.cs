//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
namespace Valery_s_Dungeon
{
    public class FatSlayerEnemies
    {
        static Random rand = new Random();

        public static void FatWizardEnemy()
        {
            Console.Clear();
            Console.WriteLine("After many battles you reach a door. You proceed to open it and enter the dark room.");
            Console.WriteLine("You see a very similliar to the other creatures but this one has a long beard and a " +
                "funny looking hat.");
            Console.ReadKey();
            if (FatSlayerEnemies.IsChristmass())
            {
                Enemies.Combat(false, "FatWizard with a snowball", 6, 4);
            }
            else
            {
                Enemies.Combat(false, "FatWizard", 6, 4);
            }

        }

        public static string GetNameFatSlayers()
        {
            if (IsChristmass())
            {
                switch (rand.Next(0, 4))
                {
                    case 0:
                        return "FatMan with a christmass hat on his head";
                    case 1:
                        return "FatMaul with a candy in his hand";
                    case 2:
                        return "FatKnight with a booster cookie in his hand";
                    case 3:
                        return "FatKing with a milk in his hand";
                }
            }

            switch (rand.Next(0, 4))
            {
                case 0:
                    return "FatMan";
                case 1:
                    return "FatMaul";
                case 2:
                    return "FatKnight";
                case 3:
                    return "FatKing";
            }
            return "FatLing";
        }

        public static bool IsChristmass()
        {
            DateTime time = DateTime.Now;
            //Christmass event
            if (time.Month == 12 && time.Day > 20)
            {
                return true;
            }
            return false;
            //else preebawa rabotata shtoto go spira
        }
    }
}

