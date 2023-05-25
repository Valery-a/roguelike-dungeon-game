//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
namespace Valery_s_Dungeon.Interface
{
    public class TownInteraction : ProgramInterface
    {
        public static async Task TalkToLadyRun()
        {
            await TalkToLady1();
        }

        public static async Task OpeningScreenRun()
        {
            await OpeningScreen1();
        }
        public static async Task TalkToNoterRun()
        {
            await TalkToNoter1();
        }
        static async Task TalkToNoter1()
        {
            while (true)
            {
                await BlazorConsole.Clear();
                BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ForegroundColor = ConsoleColor.Red;
                await BlazorConsole.WriteLine("                 Hello, dear fellow!");
                await BlazorConsole.WriteLine(" ");
                await BlazorConsole.WriteLine("     Have you seen a note somewhere around here?");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ForegroundColor = ConsoleColor.Green;
                await BlazorConsole.WriteLine("                    (1) DEMON!");
                await BlazorConsole.WriteLine("        (2)Why are you looking for a note?");
                if (Dungeon.currentPlayer.demonInteractNote == true)
                {
                    await BlazorConsole.WriteLine("               (3)Give him the note.");
                }
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();


                string input = (await BlazorConsole.ReadLine()!).ToLower();
                if (input == "1")
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Red;
                    await BlazorConsole.WriteLine("Calm down, I won't eat you. This is not even a real weapon!");
                    await BlazorConsole.WriteLine("Its made out of a cardboard, xaxa (^:");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                    break;
                }
                else if (input == "2")
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Red;
                    await BlazorConsole.WriteLine("One mermaid stole it from me a long time ago.");
                    await BlazorConsole.WriteLine("But I know that she is hiding somewhere here.");
                    await BlazorConsole.WriteLine("If you get that note, please give it back to me, its very special to me. ):");
                    await BlazorConsole.WriteLine("In the note was written the last words of my now dead mother, I  really miss her.");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                    break;
                }
                else if (input == "3" && Dungeon.currentPlayer.demonInteractNote == true)
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Red;
                    await BlazorConsole.WriteLine("Thank you for the note!");
                    BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
                    await PrintSleeping("F O O L");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                    await Endings.BadEnding1();
                    break;
                }
            }
        }
        static async Task OpeningScreen1()
        {
            ProgramInterface.gameRunning = true;
            await BlazorConsole.SetCursorPosition(0, 0);
            await BlazorConsole.Clear();
            await BlazorConsole.WriteLine();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
            await BlazorConsole.WriteLine("Then suddenly... Everything goes blank!");
            BlazorConsole.ResetColor();
            await BlazorConsole.WriteLine();
            BlazorConsole.ForegroundColor = ConsoleColor.Blue;
            await BlazorConsole.Write(" Press [enter] to wakeup...");
            BlazorConsole.ResetColor();
            await ProgramInterface.PressEnterToContiue();
            BlazorConsole.ForegroundColor = ConsoleColor.Gray; // game color
        }

        public static async Task OpenChestRun()
        {
            await OpenChest1();
        }
        static async Task OpenChest1()
        {
            Map[ProgramInterface.Character.TileJ][ProgramInterface.Character.TileI] = 'e';
            int gold = 2;
            await BlazorConsole.Clear();
            BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
            await BlazorConsole.WriteLine(" ");
            await BlazorConsole.WriteLine(MainSprites.Chest);
            await BlazorConsole.WriteLine(" ");
            BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
            await BlazorConsole.WriteLine(" You found a chest! You open it and find some gold. :)");
            await BlazorConsole.WriteLine(" ");
            await BlazorConsole.WriteLine(" You gained " + gold + " gold");
            Dungeon.currentPlayer.coins += gold;
            await BlazorConsole.WriteLine();
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Blue;
            await BlazorConsole.Write(" Press [enter] to continiue...");
            BlazorConsole.ResetColor();
            await PressEnterToContiue();
        }

        public static async Task TalkToGuardRun()
        {
            await TalkToGuard1();
        }
        static async Task TalkToGuard1()
        {
            while (true)
            {
                await BlazorConsole.Clear();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.WriteLine("                  Hello citizen!");
                await BlazorConsole.WriteLine(" ");
                await BlazorConsole.WriteLine("   Please immidiately report any demonic activity!");
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ForegroundColor = ConsoleColor.Green;
                await BlazorConsole.WriteLine("                    (1) Okay!");
                if (Dungeon.currentPlayer.demonInteract == true)
                {
                    await BlazorConsole.WriteLine(" ");
                    await BlazorConsole.WriteLine("     (2) I saw a demon in the abandoned church!");
                }
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();


                string input = (await BlazorConsole.ReadLine()!).ToLower();
                if (input == "1")
                {
                    break;
                }
                else if (input == "2" && Dungeon.currentPlayer.demonInteract == true)
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await PrintEnding("Thank you for your report!");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                    await Endings.BadEnding();
                    break;
                }
            }


        }

        public static async Task PrintEnding(string text, int speed = 50)
        {
            foreach (char c in text)
            {
                await BlazorConsole.Write(c);
                await BlazorConsole.RefreshAndDelay(TimeSpan.FromMilliseconds(speed));
                //System.Threading.Thread.Sleep(speed);

            }
            await BlazorConsole.WriteLine();
        }

        public static async Task SleepAtInnRun()
        {
            await SleepAtInn1();
        }
        static async Task SleepAtInn1()
        {
            await BlazorConsole.Clear();
            await BlazorConsole.WriteLine();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
            await BlazorConsole.WriteLine(" You enter the inn and stay the night...");
            BlazorConsole.ResetColor();
            await BlazorConsole.WriteLine();
            BlazorConsole.ForegroundColor = ConsoleColor.Green;
            await PrintSleeping(" ZzZ ZzZ ZzZ ZzZ");
            await PrintSleeping(" zZz zZz zZz zZz");
            await BlazorConsole.WriteLine();
            BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
            await BlazorConsole.WriteLine(" Your health has been increased by 1!");
            await BlazorConsole.WriteLine();
            BlazorConsole.ForegroundColor = ConsoleColor.Blue;
            await BlazorConsole.Write(" Press [enter] to continiue...");
            BlazorConsole.ResetColor();
            Dungeon.currentPlayer.health += 1;
            await PressEnterToContiue();
        }

        public static async Task TalkToLady1()
        {
            while (true)
            {
                await BlazorConsole.Clear();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.WriteLine("                 Hello!");
                await BlazorConsole.WriteLine("       How can I help you, Stranger?");
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Green;
                await BlazorConsole.WriteLine(" ");
                await BlazorConsole.WriteLine("                  (1)Where am I?)");
                await BlazorConsole.WriteLine("                  (2)Who are you?)");
                await BlazorConsole.WriteLine("          (3)What are the guards guarding?)");
                if (Dungeon.currentPlayer.potions == 0)
                {
                    await BlazorConsole.WriteLine(" ");
                    await BlazorConsole.WriteLine("              (4)Can I have some potions?");
                }
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ForegroundColor = ConsoleColor.Blue;
                await BlazorConsole.WriteLine("          Type 'e' and hit enter to escape!)");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();


                string input = (await BlazorConsole.ReadLine()!).ToLower();
                if (input == "1")
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine("You are in one of the last remaining villages, hidden deep in the forest!");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                }
                else if (input == "2")
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine("I am just an ordinary lady! (:");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                }
                else if (input == "3")
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine("They are guarding the village from the monsters!");
                    await BlazorConsole.WriteLine("You can go and talk to them!");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                }
                else if (input == "4" && Dungeon.currentPlayer.potions == 0)
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await PrintEnding("Yeah, sure! Take this one. (:");
                    BlazorConsole.ResetColor();
                    Dungeon.currentPlayer.potions += 1;
                    await BlazorConsole.ReadKey();
                    break;
                }

                else if (input == "e" || input == "E" || input == "exit" || input == "EXIT")
                {
                    break;
                }
            }
        }

        public static async Task TalkToOldGuyRun()
        {
            await TalkToOldGuy1();
        }

        public static async Task TalkToOldGuy1()
        {
            while (true)
            {
                await BlazorConsole.Clear();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                await BlazorConsole.WriteLine("                 Hello!?");
                await BlazorConsole.WriteLine("           How did you find me?");
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Green;
                await BlazorConsole.WriteLine(" ");
                await BlazorConsole.WriteLine("               (1)Who are you?)");
                await BlazorConsole.WriteLine("    (2)Why are you living so far from the village?)");
                if (Dungeon.currentPlayer.oldmanstoryInteract == true)
                {
                    await BlazorConsole.WriteLine("             (3)Give him the note.");
                }
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ForegroundColor = ConsoleColor.Blue;
                await BlazorConsole.WriteLine("          Type 'e' and hit enter to escape!)");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();


                string input = (await BlazorConsole.ReadLine()!).ToLower();
                if (input == "1")
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine("I am just an old man living his lonely life.");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                }
                else if (input == "2")
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine("I used to sail the sea long time ago, but when these filthy demons striked...");
                    await BlazorConsole.WriteLine("It was all over, I remember it as a clear day.");
                    await BlazorConsole.ReadKey();
                    await BlazorConsole.Clear();
                    await BlazorConsole.WriteLine("Long ago I met a very special girl. It was all perfect.");
                    await BlazorConsole.WriteLine("We had a boat, dreams and hopes for the future.");
                    await BlazorConsole.ReadKey();
                    await BlazorConsole.Clear();
                    await BlazorConsole.WriteLine("Then one night as I was sleeping the demons attacked our boat!");
                    await BlazorConsole.WriteLine("I was fighting fearlessly, but in the end they took her..");
                    await BlazorConsole.ReadKey();
                    await BlazorConsole.Clear();
                    await BlazorConsole.WriteLine("I never saw her again, but I can still hear her voice near the sea.");
                    BlazorConsole.ResetColor();
                    Dungeon.currentPlayer.mermaidInteract = true;
                    await BlazorConsole.ReadKey();
                }
                else if (input == "3" && Dungeon.currentPlayer.oldmanstoryInteract == true)
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine("Thank you so much for finding my long lost love!");
                    await BlazorConsole.WriteLine("So if what is written here is true... the demons will very soon conquer the world!");
                    await BlazorConsole.WriteLine("I can't be useful to you in any way since I am too old.... but I do know who can.");
                    await BlazorConsole.WriteLine("First must fight the monsters to gain some combat experience.");
                    await BlazorConsole.WriteLine("Then you will be ready to talk to the 'priest'");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                    break;
                }
                else if (input == "e" || input == "E")
                {
                    break;
                }
            }
        }

        public static async Task TalkToMermaidRun()
        {
            await TalkToMermaid1();
        }

        public static async Task TalkToMermaid1()
        {
            while (true)
            {
                await BlazorConsole.Clear();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.WriteLine(MainSprites.Mermaid);
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Green;
                await BlazorConsole.WriteLine(" ");
                await BlazorConsole.WriteLine("               (1)What are you?)");
                await BlazorConsole.WriteLine("               (2)Are you a demon?)");
                if (Dungeon.currentPlayer.mermaidInteract == true)
                {
                    await BlazorConsole.WriteLine("               (3)Are you Jessica?");
                }
                await BlazorConsole.WriteLine(" ");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ForegroundColor = ConsoleColor.Blue;
                await BlazorConsole.WriteLine("          Type 'e' and hit enter to escape!)");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();


                string input = (await BlazorConsole.ReadLine()!).ToLower();
                if (input == "1")
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine("Whatever you want me to be!");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                }
                else if (input == "2")
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine("Depends on my mood.");
                    BlazorConsole.ResetColor();
                    await BlazorConsole.ReadKey();
                }
                else if (input == "3" && Dungeon.currentPlayer.mermaidInteract == true)
                {
                    await BlazorConsole.Clear();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await PrintEnding("You know my name?!");
                    await BlazorConsole.ReadKey();
                    await BlazorConsole.Clear();
                    await BlazorConsole.WriteLine("The only person left alive that knows it is David.");
                    await BlazorConsole.WriteLine("If you find him, please give him this note.");
                    BlazorConsole.ResetColor();
                    Dungeon.currentPlayer.oldmanstoryInteract = true;
                    Dungeon.currentPlayer.demonInteractNote = true;
                    await BlazorConsole.ReadKey();
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

