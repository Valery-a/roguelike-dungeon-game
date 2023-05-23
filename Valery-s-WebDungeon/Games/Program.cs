//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Media;
using Valery_s_Dungeon;

public class Dungeon
{
    public static Random rand = new Random();
    public static Player currentPlayer = new Player();
    public static bool mainloop = true;

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        currentPlayer = Load(out bool newP);
        if (newP)
        {
            Enemies.tutorialEnemy();
        }

        while (mainloop)
        {
            Enemies.RandomEnemy();
        }
    }

    static Player NewStart(int i)
    {
        Console.Clear();
        Player p = new Player();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(MainSprites.Logo);
        Console.ResetColor();
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Print("Slayer, tell me, what shall your name be?");
        Console.ResetColor();
        p.name = Console.ReadLine();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Dungeon.Print("Pray, thou must now select a class.");
        Dungeon.Print("Choose wisely, for thy choice shall determine the path that lies before thee.");
        Dungeon.Print("Classes: Healer, Acrobat and Berserk");
        Console.ResetColor();
        bool flag = (false);
        while (flag == false)
        {
            flag = true;
            string input = Console.ReadLine()!.ToLower();

            switch (input)
            {
                case "healer":
                    p.currentClass = Player.PlayerClass.Healer;
                    break;
                case "acrobat":
                    p.currentClass = Player.PlayerClass.Acrobat;
                    break;
                case "berserk":
                    p.currentClass = Player.PlayerClass.Berserk;
                    break;

                default:
                    Console.WriteLine("To proceed, thou art required to select a class from the list provided.");
                    flag = false;
                    break;
            }
        }

        p.id = i;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Print("As you awaken, the dimly lit room surrounds you, its stone walls emanating a musty smell.");
        Print(
            "Your mind is a blank slate, devoid of any memories of your past. You search for any clue that could shed light on your situation, but your efforts prove futile. The only certainty is that you are trapped in this dimly lit room with no clear way out.");

        if (p.name == "")
            Print(
                "Lost in a haze of confusion and disorientation, you struggle to recall your name, but alas, thy memory doth fail thee.");
        else
            Print("Lost in a haze of confusion and disorientation, you struggle to recall your name... " + p.name);
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Print(
            "As your eyes adjust to the dimness of the chamber, you cautiously crawl forward, feeling your way along the rough stone floor. Suddenly, your hand brushes against something leathery. You eagerly reach out and grasp it, realizing that it's a backpack. As you fumble with the straps, your fingers brush against a smooth, metallic surface. You pull out a lighter, and a faint glimmer of hope kindles within you.");
        Print("Bewildered and lost, you scour the chamber for any hint of your arrival, but uncover nothing.");
        Print(
            "As you rummage through the contents of the backpack, your eyes are drawn to the strange and cryptic writings etched into the rough stone walls. The characters seem to dance in the dim light, and you can feel their ancient power coursing through your veins. As you read them aloud, the room begins to vibrate with an otherworldly energy, and you sense that these words hold the key to your escape.");
        Print("The writings say:");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (var j = 0; j < MainSprites.GodVsEvil.Length; j++)
        {
            var ch = MainSprites.GodVsEvil[j];

            if (ch == 'h')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                j++;
            }

            if (ch == 'j')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                j++;
            }

            Console.Write(MainSprites.GodVsEvil[j]);
        }

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(" ");
        Print(
            "In a time long forgotten, when the land was shrouded in darkness and chaos, a divine being descended from the heavens to vanquish the malevolent forces that ravaged the earth.");
        Print(
            "For centuries, the god fought tirelessly, his sword gleaming in the darkness as he battled hordes of demons and devils.");
        Print("But finally, after countless battles, the god emerged victorious, having restored peace to the land.");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(MainSprites.HavenGodGrave);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Print(
            "Before the god breathed his last breath, he channeled his immense powers into a mighty sword, imbuing it with the strength to vanquish any evil that dared to rise again.");
        Print(
            "Knowing that the sword must not fall into the wrong hands, the god concealed it from the people, entrusting its discovery only to the one destined to be the hero of the land.");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(MainSprites.Devil1);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Print("For years, the sword remained hidden, and the world knew peace.");
        Print(
            "But with the passing of the god, the demonic forces grew bolder, sensing the weakening of the barriers that kept them at bay.");
        Print("They surged forth once more, determined to reclaim the earth that had been taken from them.");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(MainSprites.Angle1);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Print(
            "It was said that the last remaining angel who knew of the sword's location had become reclusive, wary of the mortal world and its dangers.");
        Print("To have any hope of finding the sword, one would have to seek out the angel and earn their trust.");
        Print("Only then could the hero hope to stand a chance against the demons and restore peace to the world.");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(MainSprites.SkeletonAndZombie);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Print(
            "Amidst the pervasive corruption and unbridled savagery, the very fabric of myth and legend stirred, awakening creatures long-forgotten by humanity.");
        Print(
            "Once relegated to the realm of bedtime stories, these beings were now overlooked by mortals, despite their striking resemblance to the human form.");
        Print(
            "Yet, their minds were not akin to that of their fleshy counterparts, bearing a complexity beyond the comprehension of mere mortals.");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        return p;
    }

    public static Player Load(out bool newP)
    {
        newP = false;
        Console.Clear();
        var dir = new DirectoryInfo("saves");

        if (!dir.Exists)
            dir.Create();

        string[] paths = Directory.GetFiles("saves");
        List<Player> players = new List<Player>();
        int IDcount = 0;
        BinaryFormatter binForm = new BinaryFormatter();
        Console.WriteLine(string.Join(" ", paths));

        foreach (string p in paths)
        {
            FileStream file = File.Open(p, FileMode.Open);
            try
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                Player player = (Player)binForm.Deserialize(file);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                file.Close();
                players.Add(player);
            }
            catch
            {
                continue;
            }
        }


        IDcount = players.Count;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(MainSprites.WelcomeTxT);
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "⟶⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟵");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(MainSprites.Value1);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "⟶⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟵");
            Console.ResetColor();

            foreach (Player p in players)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(p.id + " / " + p.name);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "⟶⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟵");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You need to input a charachter ID or the name for your charachter to start.  ");
            Console.WriteLine("Additionaly if you type 'create' it will start a new save.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "⟶⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟵");
            Console.ResetColor();

            string[] data = Console.ReadLine()!.Split(':');

            try
            {
                if (data[0] == "id")
                {
                    if (int.TryParse(data[1], out int id))
                    {
                        foreach (Player player in players)
                        {
                            if (player.id == id)
                            {
                                return player;
                            }
                        }

                        Console.WriteLine("There is no such player with that id, try another one!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Your ID must be a number!");
                        Console.WriteLine("Press any key to try again.");
                        Console.ReadKey();
                    }
                }

                else if (data[0] == "create")
                {
                    Player newPlayer = NewStart(IDcount);
                    newP = true;
                    return newPlayer;
                }
                else
                {
                    foreach (Player player in players)
                    {
                        if (player.name == data[0])
                        {
                            return player;
                        }
                    }

                    Console.WriteLine("There is no such player with that id, try another one!");
                    Console.ReadKey();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Your ID must be a number!");
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey();
            }
        }
    }

    public static void QUIT()
    {
        Save();
        Environment.Exit(0);
    }


    public static void Save()
    {
        BinaryFormatter binForm = new BinaryFormatter();
        string path = "saves/" + currentPlayer.id.ToString() + ".level";
        FileStream file = File.Open(path, FileMode.OpenOrCreate);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
        binForm.Serialize(file, currentPlayer);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

        file.Close();
    }

    public static void Print(string text, int speed = 40)
    {
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            SoundPlayer soundPlayer = new SoundPlayer("sound/voice1.wav");
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
            soundPlayer.PlayLooping();
#pragma warning restore CA1416 // Validate platform compatibility
            Task.Run(() =>
            {
                ConsoleKey keyinfo;
                do
                {
                    keyinfo = Console.ReadKey(true).Key;
                    if (keyinfo == ConsoleKey.Enter || keyinfo == ConsoleKey.Spacebar)
                    {
                        speed = 0;
                        break;
                    }
                } while (true);
            });
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
#pragma warning disable CA1416 // Validate platform compatibility
            soundPlayer.Stop();
#pragma warning restore CA1416 // Validate platform compatibility
            Console.WriteLine();
        }
        else
        {
            Task.Run(() =>
            {
                ConsoleKey keyinfo;
                do
                {
                    keyinfo = Console.ReadKey(true).Key;
                    if (keyinfo == ConsoleKey.Enter || keyinfo == ConsoleKey.Spacebar)
                    {
                        speed = 0;
                        break;
                    }
                } while (true);
            });
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }
    }
    public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
    {
        int diff = (int)(value * size);
        for (int i = 0; i < size; i++)
        {
            if (i < diff)
            {
                Console.Write("☒");
            }
            else
            {
                Console.Write("☐");
            }
        }
    }
}