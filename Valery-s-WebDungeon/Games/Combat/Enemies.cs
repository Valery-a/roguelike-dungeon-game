//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System.Collections.Concurrent;
using Valery_s_Dungeon.Combat;

namespace Valery_s_Dungeon
{

    public class Enemies
    {
        static Random rand = new Random();



        public static void tutorialEnemy()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Dungeon.Print("In an instant, the fortification crumbles, and before thee stands a curious creature.");
            Dungeon.Print("Swiftly, thou extend thy finger and prod the beast, seeking to capture its attention.");
            Dungeon.Print("Then, the creature glances down and lo, it beholds thee....");
            Console.ResetColor();
            Console.ReadKey();
            Combat(false, "FatMan", 1, 10);
        }

        public static void RandomEnemy()
        {


            switch (rand.Next(0, 2))
            {
                case 0:
                    BasicFightCounter();
                    break;
                case 1:
                    FatSlayerEnemies.FatWizardEnemy();
                    break;
                    //case 2:
                    //    Puzzles.Puzzle2();
                    //    break;
                    //case 3:
                    //    Puzzles.Puzzle1();
                    //    break;
            }
        }




        public static void BasicFightCounter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You keep walking just as you turn around the corner you see another " +
                "very similliar to the first creature.");
            Console.ResetColor();
            Console.ReadKey();

            Combat(true, "", 0, 0);

        }

        public static void BossFight()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You've been through a lot of battles recently. Time to spice it up (:");
            Console.ResetColor();
            Console.ReadKey();

            Combat(false, "", 5, 20);

        }






        //trqbwa da naprawq combat sistemata universalna za wseki vid enemyta v budeshte

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            ConcurrentQueue<Message> messages = new ConcurrentQueue<Message>();


            if (random)
            {
                // towa e specifichno kam fatslayerite. Trqbwa da go fixna i da go naprawq kum vsichki
                n = FatSlayerEnemies.GetNameFatSlayers();
                p = Dungeon.currentPlayer.GetPower();
                h = Dungeon.currentPlayer.GetTougher();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Message? message;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(n);
                Message msg = new Message();
                msg.parts.Add(new Message.MessagePart("Power = ", ConsoleColor.Magenta));
                msg.parts.Add(new Message.MessagePart($"{p}", ConsoleColor.DarkMagenta));
                msg.parts.Add(new Message.MessagePart(" / ", ConsoleColor.Green));
                msg.parts.Add(new Message.MessagePart("Health = ", ConsoleColor.DarkRed));
                msg.parts.Add(new Message.MessagePart($"{h}", ConsoleColor.Red));
                messages.Enqueue(msg);
                messages.TryDequeue(out message);
                message?.Render();
                Console.ResetColor();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("========================================================================");
                Message msg1 = new Message();
                msg1.parts.Add(new Message.MessagePart("||", ConsoleColor.DarkCyan));
                msg1.parts.Add(new Message.MessagePart("(1)Attack", ConsoleColor.Blue));
                msg1.parts.Add(new Message.MessagePart("   ", ConsoleColor.White));
                msg1.parts.Add(new Message.MessagePart("(3)Defend", ConsoleColor.Blue));
                msg1.parts.Add(new Message.MessagePart("||", ConsoleColor.DarkCyan));
                messages.Enqueue(msg1);
                messages.TryDequeue(out message);
                message?.Render();
                Console.WriteLine(" ");
                Message msg2 = new Message();
                msg2.parts.Add(new Message.MessagePart("||", ConsoleColor.DarkCyan));
                msg2.parts.Add(new Message.MessagePart("(2)Run", ConsoleColor.Blue));
                msg2.parts.Add(new Message.MessagePart("   ", ConsoleColor.White));
                msg2.parts.Add(new Message.MessagePart("     (4)Heal", ConsoleColor.Blue));
                msg2.parts.Add(new Message.MessagePart("||", ConsoleColor.DarkCyan));
                messages.Enqueue(msg2);
                messages.TryDequeue(out message);
                message?.Render();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("========================================================================");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Potions:" + Dungeon.currentPlayer.potions + "  Health: " + Dungeon.currentPlayer.health);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string action = Console.ReadLine()!;

                if (action.ToLower() == "1" || action.ToLower() == "attack")
                {


                    //attack
                    int damage = p - Dungeon.currentPlayer.armorV;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    //tuk prowerqwa dal ise berserk i ako si berserk ti dobawq medju 0 i 2 damage otgore na twa koeto imash 
                    int attack = rand.Next(0, Dungeon.currentPlayer.weaponV) + rand.Next(1, 4) +
                        ((Dungeon.currentPlayer.currentClass == Player.PlayerClass.Berserk) ? 2 : 0);

                    TalkLines.RandomAttackFatSlayerText(n);

                    Console.WriteLine("You loose " + damage + " health and deal " + attack + " damage");
                    Dungeon.currentPlayer.health -= damage;
                    h -= attack;
                }

                else if (action.ToLower() == "4" || action.ToLower() == "heal")
                {


                    //Heal

                    if (Dungeon.currentPlayer.potions == 0)
                    {
                        Console.WriteLine("You try to reach out for something to heal yourself with from the backpack " +
                            ", but there is nothing that can help you.");
                        Dungeon.currentPlayer.health--;
                        int damage = Math.Max(p - Dungeon.currentPlayer.armorV, 0);

                        Console.WriteLine("The " + n + " punishes you with his fatness for your cluelessnes " +
                            "and you lose " + damage + " health");
                    }
                    else
                    {
                        Console.WriteLine("You reach out in your backpack and to " +
                            "your surprise you find a red bottle with the mark HEAL written on it. You drink it.");
                        //suzdawam if ako klasa na playera e healer da m uwidgne heala
                        int hpV = 5 + ((Dungeon.currentPlayer.currentClass == Player.PlayerClass.Healer) ? +3 : 0);

                        Console.WriteLine("You gain " + hpV + " health");

                        Dungeon.currentPlayer.health += hpV;
                        Dungeon.currentPlayer.potions--;

                        Console.WriteLine("But while you were busy healing the " + n + " farted so bad that your nose started to bleed.");
                        int damage = Math.Max((p / 2) - Dungeon.currentPlayer.armorV, 0);
                        Dungeon.currentPlayer.health -= damage;

                        Console.WriteLine("You lost " + damage + " health.");
                    }


                    //Console.ReadKey();
                }

                else if (action.ToLower() == "2" || action.ToLower() == "run")
                {

                    //Run
                    //tuk programata prowerqwa dali klasa e archer purwo i ako ne e sh se sluchi purwoto
                    //a ako proweri iwidi che e archer direktno kam wtoroto
                    if (Dungeon.currentPlayer.currentClass != Player.PlayerClass.Acrobat && rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you try to run away from the " + n + ", he throws a big mac at you that manages " +
                            "to hit you in the back and sends you into the wall.");
                        int damage = p - Dungeon.currentPlayer.armorV;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You loose " + damage + " health.");
                        Dungeon.currentPlayer.health -= damage;

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You start running as fast as you can from the " + n + " and after 5 minutes of " +
                            "running you realise that he is no longer following you.");
                        Console.WriteLine("You navigate trough the hallway and manage to reach a place that looks like a... shop?");
                        Console.ReadKey();
                        //Market.LoadShop(Program.currentPlayer);
                        ProgramInterface.Interface();
                    }

                }


                else if (action.ToLower() == "3" || action.ToLower() == "defend")
                {

                    //Defend
                    int damage = (p / 4) - Dungeon.currentPlayer.armorV;
                    if (damage > 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(0, Dungeon.currentPlayer.weaponV) / 2;

                    TalkLines.RandomDefendFatSlayerText();

                    Console.WriteLine("You loose " + damage + " health and deal " + attack + " damage");
                    Dungeon.currentPlayer.health -= damage;
                    h -= attack;
                }
                // player death
                if (Dungeon.currentPlayer.health <= 0)
                {
                    Console.Clear();
                    Dungeon.Print("As the " + n + " stands unphased and menacingly, he strikes you with all his might.");
                    Dungeon.Print("You have been killed by " + n);
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            Console.Clear();
            int c = Dungeon.currentPlayer.GetCoins();
            int x = Dungeon.currentPlayer.GetXP();
            Console.WriteLine("You managed to kill the " + n + "... CONGRATULATIONS!!!");
            Console.WriteLine("You find a bag next to his bigmacless body, you open it and find " + c + " coins inside of it!");
            Console.WriteLine("You have gained " + x + "XP from this encounter!");
            Dungeon.currentPlayer.coins += c;
            Dungeon.currentPlayer.xp += x;

            if (Dungeon.currentPlayer.CanlevelUP())
            {
                Dungeon.currentPlayer.LevelUP();
            }

            Console.ReadKey();



        }




    }
}

