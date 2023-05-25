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


    public static async Task Interface()
    {
        Exception? exception = null;
        try
        {
            BlazorConsole.CursorVisible = false;
            Initialize(); // suzdava mapa
            await OpeningScreen(); // izliza teksta za nachalo
            while (gameRunning)
            {
                await UpdateCharacter(); // prawi animaciqta na geroq sprqmo towa koe se natiska
                HandleMapUserInput();
                if (gameRunning)
                {
                    await RenderWorldMapView();
                    await SleepAfterRender();
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
            await BlazorConsole.Clear();
            await Dungeon.Print("Back to the dungeons!");
            BlazorConsole.CursorVisible = true;
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

    static async Task OpeningScreen()
    {
        await TownInteraction.OpeningScreenRun();
    }

    static async Task UpdateCharacter()
    {
        if (Character.MapAnimation == Sprites.RunUp && Character.MapAnimationFrame is 2 or 4 or 6) Character.J--;
        if (Character.MapAnimation == Sprites.RunDown && Character.MapAnimationFrame is 2 or 4 or 6) Character.J++;
        if (Character.MapAnimation == Sprites.RunLeft) Character.I--;
        if (Character.MapAnimation == Sprites.RunRight) Character.I++;
        Character.MapAnimationFrame++;

        if (Character.Moved)
        {
            await HandleCharacterMoved();
            Character.Moved = false;
        }
    }

    static async Task HandleCharacterMoved()
    {
        switch (Map[Character.TileJ][Character.TileI])
        {
            case 'i': await SleepAtInn(); break;
            case 'N': await TalkToNoter(); break;
            case 'J': await StartJhinPuzzles(); break;
            case 's': await ShopAtStore(); break;
            case 'z': await PlayAtCasino(); break;
            case 'C': await ChurchInteract(); break;
            case 'c': await OpenChest(); break;
            case '0': TransitionMapToTown(); break;
            case '1': TransitionMapToField(); break;
            case '7': BackToDungeons(); break;
            case 'l': await TalkToLady(); break;
            case 'G': await TalkToGuard(); break;
            case 'g': await TalkToOldGuy(); break;
            case 'I': await TalkToMermaid(); break;
        }
    }

    public static async Task PressEnterToContiue()
    {
    GetInput:// izpolzva me go za da izlezem ot loopa kato se natisne "pravilniq" buton
        ConsoleKey key = (await BlazorConsole.ReadKey(true)).Key;
        switch (key)
        {
            case ConsoleKey.Enter:
                return;
            default:
                goto GetInput;// vrushta programata obratno gore, kudeto programata stoi i chkama da izleze ot loopa shtom butona e natisnat
        }
    }

    static async Task OpenChest()
    {
        await TownInteraction.OpenChestRun();
    }

    static async Task TalkToNoter()
    {
        await TownInteraction.TalkToNoterRun();
    }

    static async Task TalkToOldGuy()
    {
        await TownInteraction.TalkToOldGuyRun();
    }

    static async Task TalkToLady()
    {
        await TownInteraction.TalkToLadyRun();
    }

    static async Task SleepAtInn()
    {
        await TownInteraction.SleepAtInnRun();
    }

    static async Task TalkToMermaid()
    {
        await TownInteraction.TalkToMermaidRun();
    }

    static async Task TalkToGuard()

    {
        await TownInteraction.TalkToGuardRun();

    }

    public static async Task PrintSleeping(string text, int speed = 300)
    {
        foreach (char c in text)
        {
            await BlazorConsole.Write(c);
            await BlazorConsole.RefreshAndDelay(TimeSpan.FromMilliseconds(speed));
            //System.Threading.Thread.Sleep(speed);

        }
        await BlazorConsole.WriteLine();
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

    static async Task ShopAtStore()
    {
        await BlazorConsole.Clear();
        await Market.LoadShop(Dungeon.currentPlayer);
    }

    static async Task StartJhinPuzzles()
    {
        Random rand = new Random();
        switch (rand.Next(0, 2))
        {
            case 0:
                await Puzzles.Puzzle2();
                break;
            case 1:
                await Puzzles.Puzzle1();
                break;
        }
    }
    static async Task ChurchInteract()
    {
        await BlazorConsole.Clear();
        await Church.LoadChurch();
    }

    static async Task PlayAtCasino()
    {
        await BlazorConsole.Clear();
        await Casino.LoadCasino();
    }

    static void HandleMapUserInput()
    {
        while (BlazorConsole.KeyAvailableNoRefresh())
        {
            ConsoleKey key = (BlazorConsole.ReadKeyNoRefresh(true)).Key;
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

    static async Task SleepAfterRender()
    {
        // frame rate control
        DateTime now = DateTime.Now;
        TimeSpan sleep = TimeSpan.FromMilliseconds(33) - (now - previoiusRender);
        if (sleep > TimeSpan.Zero)
        {
            await BlazorConsole.RefreshAndDelay(sleep);
            //Thread.Sleep(sleep);
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

    static async Task RenderWorldMapView()
    {
        BlazorConsole.CursorVisible = false;

        var (width, height) = await GetWidthAndHeight();
        int heightCutOff = (int)(height * .80);
        int midWidth = width / 2;
        int midHeight = heightCutOff / 2;

        StringBuilder sb = new(width * height);
        for (int j = 0; j < height; j++)
        {
            //if (OperatingSystem.IsWindows() && j == height - 1)
            //{
            //    break;
            //}

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
            //if (!OperatingSystem.IsWindows() && j < height - 1)
            //{
            //    sb.AppendLine();
            //}
            sb.AppendLine();
        }
        await BlazorConsole.SetCursorPosition(0, 0);
        await BlazorConsole.Write(sb);
    }

    static async Task<(int Width, int Height)> GetWidthAndHeight()
    {
    RestartRender:
        int width = BlazorConsole.WindowWidth;
        int height = BlazorConsole.WindowHeight;
        //if (OperatingSystem.IsWindows())
        {
            try
            {
                if (BlazorConsole.BufferHeight != height) BlazorConsole.BufferHeight = height;
                if (BlazorConsole.BufferWidth != width) BlazorConsole.BufferWidth = width;
            }
            catch (Exception)
            {
                await BlazorConsole.Clear();
                goto RestartRender;
            }
        }
        return (width, height);
    }
}