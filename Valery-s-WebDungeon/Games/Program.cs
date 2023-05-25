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
    public static Player currentPlayer;
    public static bool mainloop = true;

    public static async Task DungeonMain()
    {
        BlazorConsole.OutputEncoding = Encoding.UTF8;

        currentPlayer = await NewStart();
        await Enemies.tutorialEnemy();
        while (mainloop)
        {
            await Enemies.RandomEnemy();
        }
    }

    static async Task<Player> NewStart()
    {
        await BlazorConsole.Clear();
        Player p = new Player();
        BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
        await BlazorConsole.WriteLine(MainSprites.Logo);
        BlazorConsole.ResetColor();
        await BlazorConsole.ReadKey();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
        await Print("Slayer, tell me, what shall your name be?");
        BlazorConsole.ResetColor();
        p.name = await BlazorConsole.ReadLine();
        await BlazorConsole.Clear();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
        await Dungeon.Print("Pray, thou must now select a class.");
        await Dungeon.Print("Choose wisely, for thy choice shall determine the path that lies before thee.");
        await Dungeon.Print("Classes: Healer, Acrobat and Berserk");
        BlazorConsole.ResetColor();
        bool flag = (false);
        while (flag == false)
        {
            flag = true;
            string input = (await BlazorConsole.ReadLine()!).ToLower();

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
                case "debug":
                    await ProgramInterface.Interface();
                    break;

                default:
                    await BlazorConsole.WriteLine("To proceed, thou art required to select a class from the list provided.");
                    flag = false;
                    break;
            }
        }

        await BlazorConsole.Clear();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
        await Print("As you awaken, the dimly lit room surrounds you, its stone walls emanating a musty smell.");
        await Print(
            "Your mind is a blank slate, devoid of any memories of your past. You search for any clue that could shed light on your situation, but your efforts prove futile. The only certainty is that you are trapped in this dimly lit room with no clear way out.");

        if (p.name == "")
            await Print(
                "Lost in a haze of confusion and disorientation, you struggle to recall your name, but alas, thy memory doth fail thee.");
        else
            await Print("Lost in a haze of confusion and disorientation, you struggle to recall your name... " + p.name);
        BlazorConsole.ResetColor();
        await BlazorConsole.ReadKey();
        await BlazorConsole.Clear();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
        await Print(
            "As your eyes adjust to the dimness of the chamber, you cautiously crawl forward, feeling your way along the rough stone floor. Suddenly, your hand brushes against something leathery. You eagerly reach out and grasp it, realizing that it's a backpack. As you fumble with the straps, your fingers brush against a smooth, metallic surface. You pull out a lighter, and a faint glimmer of hope kindles within you.");
        await Print("Bewildered and lost, you scour the chamber for any hint of your arrival, but uncover nothing.");
        await Print(
            "As you rummage through the contents of the backpack, your eyes are drawn to the strange and cryptic writings etched into the rough stone walls. The characters seem to dance in the dim light, and you can feel their ancient power coursing through your veins. As you read them aloud, the room begins to vibrate with an otherworldly energy, and you sense that these words hold the key to your escape.");
        await Print("The writings say:");
        BlazorConsole.ResetColor();
        await BlazorConsole.ReadKey();
        await BlazorConsole.Clear();
        BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
        for (var j = 0; j < MainSprites.GodVsEvil.Length; j++)
        {
            var ch = MainSprites.GodVsEvil[j];

            if (ch == 'h')
            {
                BlazorConsole.ForegroundColor = ConsoleColor.Red;
                j++;
            }

            if (ch == 'j')
            {
                BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                j++;
            }

            await BlazorConsole.Write(MainSprites.GodVsEvil[j]);
        }

        BlazorConsole.ResetColor();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
        await BlazorConsole.WriteLine(" ");
        await Print(
            "In a time long forgotten, when the land was shrouded in darkness and chaos, a divine being descended from the heavens to vanquish the malevolent forces that ravaged the earth.");
        await Print(
            "For centuries, the god fought tirelessly, his sword gleaming in the darkness as he battled hordes of demons and devils.");
        await Print("But finally, after countless battles, the god emerged victorious, having restored peace to the land.");
        BlazorConsole.ResetColor();
        await BlazorConsole.ReadKey();
        await BlazorConsole.Clear();
        BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
        await BlazorConsole.WriteLine(MainSprites.HavenGodGrave);
        BlazorConsole.ResetColor();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
        await Print(
            "Before the god breathed his last breath, he channeled his immense powers into a mighty sword, imbuing it with the strength to vanquish any evil that dared to rise again.");
        await Print(
            "Knowing that the sword must not fall into the wrong hands, the god concealed it from the people, entrusting its discovery only to the one destined to be the hero of the land.");
        BlazorConsole.ResetColor();
        await BlazorConsole.ReadKey();
        await BlazorConsole.Clear();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
        await BlazorConsole.WriteLine(MainSprites.Devil1);
        BlazorConsole.ResetColor();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
        await Print("For years, the sword remained hidden, and the world knew peace.");
        await Print(
            "But with the passing of the god, the demonic forces grew bolder, sensing the weakening of the barriers that kept them at bay.");
        await Print("They surged forth once more, determined to reclaim the earth that had been taken from them.");
        BlazorConsole.ResetColor();
        await BlazorConsole.ReadKey();
        await BlazorConsole.Clear();
        BlazorConsole.ForegroundColor = ConsoleColor.White;
        await BlazorConsole.WriteLine(MainSprites.Angle1);
        BlazorConsole.ResetColor();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
        await Print(
            "It was said that the last remaining angel who knew of the sword's location had become reclusive, wary of the mortal world and its dangers.");
        await Print("To have any hope of finding the sword, one would have to seek out the angel and earn their trust.");
        await Print("Only then could the hero hope to stand a chance against the demons and restore peace to the world.");
        BlazorConsole.ResetColor();
        await BlazorConsole.ReadKey();
        await BlazorConsole.Clear();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
        await BlazorConsole.WriteLine(MainSprites.SkeletonAndZombie);
        BlazorConsole.ResetColor();
        BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
        await Print(
            "Amidst the pervasive corruption and unbridled savagery, the very fabric of myth and legend stirred, awakening creatures long-forgotten by humanity.");
        await Print(
            "Once relegated to the realm of bedtime stories, these beings were now overlooked by mortals, despite their striking resemblance to the human form.");
        await Print(
            "Yet, their minds were not akin to that of their fleshy counterparts, bearing a complexity beyond the comprehension of mere mortals.");
        BlazorConsole.ResetColor();
        await BlazorConsole.ReadKey();
        await BlazorConsole.Clear();
        return p;
    }

    public static void QUIT()
    {
        Environment.Exit(0);
    }

    public static async Task Print(string text, int speed = 40)
    {
        bool skipping = false;
        foreach (char c in text)
        {
            while (BlazorConsole.KeyAvailableNoRefresh())
            {
                if ((await BlazorConsole.ReadKey(true)).Key is ConsoleKey.Enter)
                {
                    skipping = true;
                }
            }
            await BlazorConsole.Write(c);
            if (!skipping)
            {
                await BlazorConsole.RefreshAndDelay(TimeSpan.FromMilliseconds(speed));
                //System.Threading.Thread.Sleep(speed);
            }
        }
        await BlazorConsole.WriteLine();
    }
    public static async Task ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
    {
        int diff = (int)(value * size);
        for (int i = 0; i < size; i++)
        {
            if (i < diff)
            {
                await BlazorConsole.Write("☒");
            }
            else
            {
                await BlazorConsole.Write("☐");
            }
        }
    }
}