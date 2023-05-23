//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
namespace Valery_s_Dungeon.Interface
{
    public class TownInteraction : ProgramInterface
    {
        public static void TalkToLadyRun()
        {
            TalkToLady1();
        }

        public static void OpeningScreenRun()
        {
            OpeningScreen1();
        }
        public static void TalkToNoterRun()
        {
            TalkToNoter1();
        }
        static void TalkToNoter1()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                 Hello, dear fellow!");
                Console.WriteLine(" ");
                Console.WriteLine("     Have you seen a note somewhere around here?");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                    (1) DEMON!");
                Console.WriteLine("        (2)Why are you looking for a note?");
                if (Dungeon.currentPlayer.demonInteractNote == true)
                {
                    Console.WriteLine("               (3)Give him the note.");
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();


                string input = Console.ReadLine()!.ToLower();
                if (input == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Calm down, I won't eat you. This is not even a real weapon!");
                    Console.WriteLine("Its made out of a cardboard, xaxa (^:");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("One mermaid stole it from me a long time ago.");
                    Console.WriteLine("But I know that she is hiding somewhere here.");
                    Console.WriteLine("If you get that note, please give it back to me, its very special to me. ):");
                    Console.WriteLine("In the note was written the last words of my now dead mother, I  really miss her.");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
                else if (input == "3" && Dungeon.currentPlayer.demonInteractNote == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Thank you for the note!");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    PrintSleeping("F O O L");
                    Console.ResetColor();
                    Console.ReadKey();
                    Endings.BadEnding1();
                    break;
                }
            }
        }
        static void OpeningScreen1()
        {
            ProgramInterface.gameRunning = true;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Then suddenly... Everything goes blank!");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" Press [enter] to wakeup...");
            Console.ResetColor();
            ProgramInterface.PressEnterToContiue();
            Console.ForegroundColor = ConsoleColor.Gray; // game color
        }

        public static void OpenChestRun()
        {
            OpenChest1();
        }
        static void OpenChest1()
        {
            Map[ProgramInterface.Character.TileJ][ProgramInterface.Character.TileI] = 'e';
            int gold = 2;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ");
            Console.WriteLine(MainSprites.Chest);
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" You found a chest! You open it and find some gold. :)");
            Console.WriteLine(" ");
            Console.WriteLine(" You gained " + gold + " gold");
            Dungeon.currentPlayer.coins += gold;
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" Press [enter] to continiue...");
            Console.ResetColor();
            PressEnterToContiue();
        }

        public static void TalkToGuardRun()
        {
            TalkToGuard1();
        }
        static void TalkToGuard1()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                  Hello citizen!");
                Console.WriteLine(" ");
                Console.WriteLine("   Please immidiately report any demonic activity!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                    (1) Okay!");
                if (Dungeon.currentPlayer.demonInteract == true)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("     (2) I saw a demon in the abandoned church!");
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();


                string input = Console.ReadLine()!.ToLower();
                if (input == "1")
                {
                    break;
                }
                else if (input == "2" && Dungeon.currentPlayer.demonInteract == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    PrintEnding("Thank you for your report!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Endings.BadEnding();
                    break;
                }
            }


        }

        public static void PrintEnding(string text, int speed = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);

            }
            Console.WriteLine();
        }

        public static void SleepAtInnRun()
        {
            SleepAtInn1();
        }
        static void SleepAtInn1()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" You enter the inn and stay the night...");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            PrintSleeping(" ZzZ ZzZ ZzZ ZzZ");
            PrintSleeping(" zZz zZz zZz zZz");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Your health has been increased by 1!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" Press [enter] to continiue...");
            Console.ResetColor();
            Dungeon.currentPlayer.health += 1;
            PressEnterToContiue();
        }

        public static void TalkToLady1()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                 Hello!");
                Console.WriteLine("       How can I help you, Stranger?");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ");
                Console.WriteLine("                  (1)Where am I?)");
                Console.WriteLine("                  (2)Who are you?)");
                Console.WriteLine("          (3)What are the guards guarding?)");
                if (Dungeon.currentPlayer.potions == 0)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("              (4)Can I have some potions?");
                }
                Console.WriteLine(" ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("          Type 'e' and hit enter to escape!)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();


                string input = Console.ReadLine()!.ToLower();
                if (input == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You are in one of the last remaining villages, hidden deep in the forest!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("I am just an ordinary lady! (:");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (input == "3")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("They are guarding the village from the monsters!");
                    Console.WriteLine("You can go and talk to them!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (input == "4" && Dungeon.currentPlayer.potions == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    PrintEnding("Yeah, sure! Take this one. (:");
                    Console.ResetColor();
                    Dungeon.currentPlayer.potions += 1;
                    Console.ReadKey();
                    break;
                }

                else if (input == "e" || input == "E" || input == "exit" || input == "EXIT")
                {
                    break;
                }
            }
        }

        public static void TalkToOldGuyRun()
        {
            TalkToOldGuy1();
        }

        public static void TalkToOldGuy1()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                 Hello!?");
                Console.WriteLine("           How did you find me?");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ");
                Console.WriteLine("               (1)Who are you?)");
                Console.WriteLine("    (2)Why are you living so far from the village?)");
                if (Dungeon.currentPlayer.oldmanstoryInteract == true)
                {
                    Console.WriteLine("             (3)Give him the note.");
                }
                Console.WriteLine(" ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("          Type 'e' and hit enter to escape!)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();


                string input = Console.ReadLine()!.ToLower();
                if (input == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("I am just an old man living his lonely life.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("I used to sail the sea long time ago, but when these filthy demons striked...");
                    Console.WriteLine("It was all over, I remember it as a clear day.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Long ago I met a very special girl. It was all perfect.");
                    Console.WriteLine("We had a boat, dreams and hopes for the future.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Then one night as I was sleeping the demons attacked our boat!");
                    Console.WriteLine("I was fighting fearlessly, but in the end they took her..");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("I never saw her again, but I can still hear her voice near the sea.");
                    Console.ResetColor();
                    Dungeon.currentPlayer.mermaidInteract = true;
                    Console.ReadKey();
                }
                else if (input == "3" && Dungeon.currentPlayer.oldmanstoryInteract == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Thank you so much for finding my long lost love!");
                    Console.WriteLine("So if what is written here is true... the demons will very soon conquer the world!");
                    Console.WriteLine("I can't be useful to you in any way since I am too old.... but I do know who can.");
                    Console.WriteLine("First must fight the monsters to gain some combat experience.");
                    Console.WriteLine("Then you will be ready to talk to the 'priest'");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
                else if (input == "e" || input == "E")
                {
                    break;
                }
            }
        }

        public static void TalkToMermaidRun()
        {
            TalkToMermaid1();
        }

        public static void TalkToMermaid1()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(MainSprites.Mermaid);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ");
                Console.WriteLine("               (1)What are you?)");
                Console.WriteLine("               (2)Are you a demon?)");
                if (Dungeon.currentPlayer.mermaidInteract == true)
                {
                    Console.WriteLine("               (3)Are you Jessica?");
                }
                Console.WriteLine(" ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("          Type 'e' and hit enter to escape!)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();


                string input = Console.ReadLine()!.ToLower();
                if (input == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Whatever you want me to be!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Depends on my mood.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (input == "3" && Dungeon.currentPlayer.mermaidInteract == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    PrintEnding("You know my name?!");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("The only person left alive that knows it is David.");
                    Console.WriteLine("If you find him, please give him this note.");
                    Console.ResetColor();
                    Dungeon.currentPlayer.oldmanstoryInteract = true;
                    Dungeon.currentPlayer.demonInteractNote = true;
                    Console.ReadKey();
                    break;
                }
                else if (input == "e" || input == "E")
                {
                    break;
                }
            }
        }
    }
}

