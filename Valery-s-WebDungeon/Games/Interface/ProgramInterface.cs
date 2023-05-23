//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System.Text;
using Valery_sDungeon;
using Valery_s_Dungeon.Interface;
namespace Valery_s_Dungeon;

public partial class ProgramInterface
{

    static Character? _character;
    static char[][]? _map;
    static DateTime previoiusRender = DateTime.Now;
    public static bool gameRunning = true;

    public static Character Character
    {
        get => _character!;
        set => _character = value;
    }
    public static char[][] Map
    {
        get => _map!;
        set => _map = value;
    }
    private static readonly string[] maptext = new[]
    {
        ""
    };


    public static void Interface()
    {
        Exception? exception = null;
        try
        {
            Console.CursorVisible = false;
            Initialize(); // suzdava mapa
            OpeningScreen(); // izliza teksta za nachalo
            while (gameRunning)
            {
                UpdateCharacter(); // prawi animaciqta na geroq sprqmo towa koe se natiska
                HandleMapUserInput();
                if (gameRunning)
                {
                    RenderWorldMapView();
                    SleepAfterRender();
                }
            }
        }
        catch (Exception e)
        {
            exception = e;
            throw;
        }
        finally
        {
            Console.Clear();
            Dungeon.Print("Back to the dungeons!");
            Console.CursorVisible = true;
        }
    }

    static void Initialize()
    {
        Map = Maps.Town;
        Character = new();
        {
            var (i, j) = FindTileInMap(Map, 'X')!.Value;
            Character.I = i * 7;
            Character.J = j * 4;
        }
        Character.MapAnimation = Sprites.IdleRight;
    }

    static void OpeningScreen()
    {
        TownInteraction.OpeningScreenRun();
    }

    static void UpdateCharacter()
    {
        if (Character.MapAnimation == Sprites.RunUp && Character.MapAnimationFrame is 2 or 4 or 6) Character.J--;
        if (Character.MapAnimation == Sprites.RunDown && Character.MapAnimationFrame is 2 or 4 or 6) Character.J++;
        if (Character.MapAnimation == Sprites.RunLeft) Character.I--;
        if (Character.MapAnimation == Sprites.RunRight) Character.I++;
        Character.MapAnimationFrame++;

        if (Character.Moved)
        {
            HandleCharacterMoved();
            Character.Moved = false;
        }
    }

    static void HandleCharacterMoved()
    {
        switch (Map[Character.TileJ][Character.TileI])
        {
            case 'i': SleepAtInn(); break;
            case 'N': TalkToNoter(); break;
            case 'J': StartJhinPuzzles(); break;
            case 's': ShopAtStore(); break;
            case 'z': PlayAtCasino(); break;
            case 'C': ChurchInteract(); break;
            case 'c': OpenChest(); break;
            case '0': TransitionMapToTown(); break;
            case '1': TransitionMapToField(); break;
            case '7': BackToDungeons(); break;
            case 'l': TalkToLady(); break;
            case 'G': TalkToGuard(); break;
            case 'g': TalkToOldGuy(); break;
            case 'I': TalkToMermaid(); break;
        }
    }

    public static void PressEnterToContiue()
    {
    GetInput:// izpolzva me go za da izlezem ot loopa kato se natisne "pravilniq" buton
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.Enter:
                return;
            default:
                goto GetInput;// vrushta programata obratno gore, kudeto programata stoi i chkama da izleze ot loopa shtom butona e natisnat
        }
    }

    static void OpenChest()
    {
        TownInteraction.OpenChestRun();
    }

    static void TalkToNoter()
    {
        TownInteraction.TalkToNoterRun();
    }

    static void TalkToOldGuy()
    {
        TownInteraction.TalkToOldGuyRun();
    }

    static void TalkToLady()
    {
        TownInteraction.TalkToLadyRun();
    }

    static void SleepAtInn()
    {
        TownInteraction.SleepAtInnRun();
    }

    static void TalkToMermaid()
    {
        TownInteraction.TalkToMermaidRun();
    }

    static void TalkToGuard()

    {
        TownInteraction.TalkToGuardRun();

    }

    public static void PrintSleeping(string text, int speed = 300)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            System.Threading.Thread.Sleep(speed);

        }
        Console.WriteLine();
    }

    static void TransitionMapToTown()
    {
        Map = Maps.Town;
        var (i, j) = FindTileInMap(Map, '1')!.Value;
        Character.I = i * 7;
        Character.J = j * 4;
    }

    static void BackToDungeons()
    {
        gameRunning = false;
    }

    static void TransitionMapToField()
    {
        char c = Map == Maps.Town ? '0' : '2';
        Map = Maps.Field;
        var (i, j) = FindTileInMap(Map, c)!.Value;
        Character.I = i * 7;
        Character.J = j * 4;
    }

    static void ShopAtStore()
    {
        Console.Clear();
        Market.LoadShop(Dungeon.currentPlayer);
    }

    static void StartJhinPuzzles()
    {
        Random rand = new Random();
        switch (rand.Next(0, 2))
        {
            case 0:
                Puzzles.Puzzle2();
                break;
            case 1:
                Puzzles.Puzzle1();
                break;
        }
    }
    static void ChurchInteract()
    {
        Console.Clear();
        Church.LoadChurch();
    }

    static void PlayAtCasino()
    {
        Console.Clear();
        Casino.LoadCasino();
    }

    static void HandleMapUserInput()
    {
        while (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case
                    ConsoleKey.UpArrow or ConsoleKey.W or
                    ConsoleKey.DownArrow or ConsoleKey.S or
                    ConsoleKey.LeftArrow or ConsoleKey.A or
                    ConsoleKey.RightArrow or ConsoleKey.D:
                    if (Character.IsIdle)
                    {
                        var (tileI, tileJ) = key switch
                        {
                            ConsoleKey.UpArrow or ConsoleKey.W => (Character.TileI, Character.TileJ - 1),
                            ConsoleKey.DownArrow or ConsoleKey.S => (Character.TileI, Character.TileJ + 1),
                            ConsoleKey.LeftArrow or ConsoleKey.A => (Character.TileI - 1, Character.TileJ),
                            ConsoleKey.RightArrow or ConsoleKey.D => (Character.TileI + 1, Character.TileJ),
                            _ => throw new Exception("bug"),
                        };
                        if (Maps.IsValidCharacterMapTile(Map, tileI, tileJ))
                        {
                            switch (key)
                            {
                                case ConsoleKey.UpArrow or ConsoleKey.W:
                                    Character.J--;
                                    Character.MapAnimation = Sprites.RunUp;
                                    break;
                                case ConsoleKey.DownArrow or ConsoleKey.S:
                                    Character.J++;
                                    Character.MapAnimation = Sprites.RunDown;
                                    break;
                                case ConsoleKey.LeftArrow or ConsoleKey.A:
                                    Character.MapAnimation = Sprites.RunLeft;
                                    break;
                                case ConsoleKey.RightArrow or ConsoleKey.D:
                                    Character.MapAnimation = Sprites.RunRight;
                                    break;
                            }
                        }
                    }
                    break;
            }
        }
    }

    static void SleepAfterRender()
    {
        // frame rate control
        DateTime now = DateTime.Now;
        TimeSpan sleep = TimeSpan.FromMilliseconds(33) - (now - previoiusRender);
        if (sleep > TimeSpan.Zero)
        {
            Thread.Sleep(sleep);
        }
        previoiusRender = DateTime.Now;
    }

    static (int I, int J)? FindTileInMap(char[][] map, char c)
    {
        for (int j = 0; j < map.Length; j++)
        {
            for (int i = 0; i < map[j].Length; i++)
            {
                if (map[j][i] == c)
                {
                    return (i, j);
                }
            }
        }
        return null;
    }

    static void RenderWorldMapView()
    {
        Console.CursorVisible = false;

        var (width, height) = GetWidthAndHeight();
        int heightCutOff = (int)(height * .80);
        int midWidth = width / 2;
        int midHeight = heightCutOff / 2;

        StringBuilder sb = new(width * height);
        for (int j = 0; j < height; j++)
        {
            if (OperatingSystem.IsWindows() && j == height - 1)
            {
                break;
            }

            for (int i = 0; i < width; i++)
            {
                // console area (below map)
                if (j >= heightCutOff)
                {
                    int line = j - heightCutOff - 1;
                    int character = i - 1;
                    if (i < width - 1 && character >= 0 && line >= 0 && line < maptext.Length && character < maptext[line].Length)
                    {
                        char ch = maptext[line][character];
                        sb.Append(char.IsWhiteSpace(ch) ? ' ' : ch);
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                    continue;
                }

                // map outline
                if (i is 0 && j is 0)
                {
                    //sb.Append('╔');
                    sb.Append('☠');
                    continue;
                }
                if (i is 0 && j == heightCutOff - 1)
                {
                    //sb.Append('╚');
                    sb.Append('☠');
                    continue;
                }
                if (i == width - 1 && j is 0)
                {
                    //sb.Append('╗');
                    sb.Append('☠');
                    continue;
                }
                if (i == width - 1 && j == heightCutOff - 1)
                {
                    //sb.Append('╝');
                    sb.Append('☠');
                    continue;
                }
                if (i is 0 || i == width - 1)
                {
                    //sb.Append('║');
                    sb.Append('☠');
                    continue;
                }
                if (j is 0 || j == heightCutOff - 1)
                {
                    //sb.Append('═');
                    sb.Append('☠');
                    continue;
                }

                // character
                if (i > midWidth - 4 && i < midWidth + 4 && j > midHeight - 2 && j < midHeight + 3)
                {
                    int ci = i - (midWidth - 3);
                    int cj = j - (midHeight - 1);
                    string characterMapRender = Character.Render;
                    sb.Append(characterMapRender[cj * 8 + ci]);
                    continue;
                }

                // tiles

                // compute the map location that this screen pixel represents
                int mapI = i - midWidth + Character.I + 3;
                int mapJ = j - midHeight + Character.J + 1;

                // compute the coordinates of the tile
                int tileI = mapI < 0 ? (mapI - 6) / 7 : mapI / 7;
                int tileJ = mapJ < 0 ? (mapJ - 3) / 4 : mapJ / 4;

                // compute the coordinates of the pixel within the tile's sprite
                int pixelI = mapI < 0 ? 6 + ((mapI + 1) % 7) : (mapI % 7);
                int pixelJ = mapJ < 0 ? 3 + ((mapJ + 1) % 4) : (mapJ % 4);

                // render pixel from map tile
                string tileRender = Maps.GetMapTileRender(Map, tileI, tileJ);
                char c = tileRender[pixelJ * 8 + pixelI];
                sb.Append(char.IsWhiteSpace(c) ? ' ' : c);
            }
            if (!OperatingSystem.IsWindows() && j < height - 1)
            {
                sb.AppendLine();
            }
        }
        Console.SetCursorPosition(0, 0);
        Console.Write(sb);
    }

    static (int Width, int Height) GetWidthAndHeight()
    {
    RestartRender:
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        if (OperatingSystem.IsWindows())
        {
            try
            {
                if (Console.BufferHeight != height) Console.BufferHeight = height;
                if (Console.BufferWidth != width) Console.BufferWidth = width;
            }
            catch (Exception)
            {
                Console.Clear();
                goto RestartRender;
            }
        }
        return (width, height);
    }
}