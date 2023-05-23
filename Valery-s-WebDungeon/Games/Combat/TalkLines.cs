//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
namespace Valery_s_Dungeon
{
    public class TalkLines
    {
        static Random rand = new Random();

        public static void RandomAttackFatSlayerText(string n)
        {
            switch (rand.Next(0, 2))
            {
                case 0:
                    Console.WriteLine("You grab dust from the floor and throw it at the " + n + " and while is blinded you hit him" +
                        " in his fat belly.");
                    Console.WriteLine("He throws up on you from the punch and hits you on the head.");
                    break;
                case 1:
                    Console.WriteLine("You try to slice his fat belly off with the knife you found " +
                         "in your pocket but the " + n + "'s belly is too big to be sliced that easily in one hit. ");
                    Console.WriteLine("He takes a big mac out of his pocket and he throws it at you!");
                    break;
            }
        }

        public static void RandomDefendFatSlayerText()
        {
            string n = FatSlayerEnemies.GetNameFatSlayers();
            switch (rand.Next(0, 2))
            {
                case 0:
                    Console.WriteLine("As the " + n + " prepares to slam you with all his duner might, you manage to " +
                        "find a salad next to the garbage bin that helps you defend from the " + n);
                    break;
                case 1:
                    Console.WriteLine("The " + n + " throws a big mash of food at you, but you manage to dodge it.");
                    break;

            }

        }


    }
}

