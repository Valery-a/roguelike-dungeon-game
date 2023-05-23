//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Valery_s_Dungeon;


namespace Valery_s_Dungeon;

public static class Sprites
{
    public const string Open =
        @"       " + "\n" +
        @"       " + "\n" +
        @"       " + "\n" +
        @"       ";
    public const string Spawn =
        @"       " + "\n" +
        @"       " + "\n" +
        @"       " + "\n" +
        @"... ...";
    public const string Town =
        @"--- ---" + "\n" +
        @"       " + "\n" +
        @"       " + "\n" +
        @"       ";
    public const string DungeonEnterance =
        @"       " + "\n" +
        @"       " + "\n" +
        @"       " + "\n" +
        @"___ ___";
    public const string Building =
        @" /^^^\ " + "\n" +
        @"/>---<\" + "\n" +
        @"|     |" + "\n" +
        @"|  █  |";
    public const string Inn =
        @" /^^^\ " + "\n" +
        @"/>Inn<\" + "\n" +
        @"|     |" + "\n" +
        @"|__█__|";
    public const string Casino1 =
       @" /-----" + "\n" +
       @"/-The-H" + "\n" +
       @"|      " + "\n" +
       @"|______";
    public const string Casino2 =
       @"-------" + "\n" +
       @"all-Of-" + "\n" +
       @"       " + "\n" +
       @"___█___";
    public const string Casino3 =
       @"-----\ " + "\n" +
       @"Chance\" + "\n" +
       @"      |" + "\n" +
       @"______|";
    public const string OldHouse =
       @"       " + "\n" +
       @"  ,_m_ " + "\n" +
       @" /\___\" + "\n" +
       @" |_|__|""";
    public const string Church =
      @"   /_\ " + "\n" +
      @" __|O| " + "\n" +
      @"/_____\" + "\n" +
      @"|__█__|";
    public const string Store =
        @" /^^^\ " + "\n" +
        @"/Store\" + "\n" +
        @"|     |" + "\n" +
        @"|  █  |";
    public const string JhinGames =
        @" /^^^\ " + "\n" +
        @"/Jhins\" + "\n" +
        @"|     |" + "\n" +
        @"|  █  |";
    public const string Chest =
        @"  ___  " + "\n" +
        @" |_|_| " + "\n" +
        @" |_☠_| " + "\n" +
        @"       ";
    public const string EmptyChest =
        @" ____  " + "\n" +
        @" \___) " + "\n" +
        @" |_☠_| " + "\n" +
        @"       ";
    public const string Water =
        @"~^~^~^~" + "\n" +
        @"~^~^~^~" + "\n" +
        @"~^~^~^~" + "\n" +
        @"~^~^~^~";
    public const string Water1 =
        @"^~^~^~^" + "\n" +
        @"^~^~^~^" + "\n" +
        @"^~^~^~^" + "\n" +
        @"^~^~^~^";
    public const string StoneNodes =
        @"       " + "\n" +
        @"   _   " + "\n" +
        @" _/ \  " + "\n" +
        @"/____\ ";
    public const string StoneNodes1 =
       @"       " + "\n" +
       @"  ,-.  " + "\n" +
       @" /\,-\ " + "\n" +
       @"/_____\";
    public const string Wall_0000 =
        @"▒▒▒▒▒▒▒" + "\n" +
        @"▒▒▒▒▒▒▒" + "\n" +
        @"▒▒▒▒▒▒▒" + "\n" +
        @"▒▒▒▒▒▒▒";
    public const string Wall_0001 =
        @"▒▒▒▒▒▒▒" + "\n" +
        @"▒▒▒▒▒▒▒" + "\n" +
        @"       " + "\n" +
        @"       ";
    public const string Tree =
        @"  ###  " + "\n" +
        @" ##### " + "\n" +
        @"   |   " + "\n" +
        @"   |   ";
    public const string Tree2 =
        @"   ##  " + "\n" +
        @"  #### " + "\n" +
        @" ######" + "\n" +
        @"   ||  ";
    public const string Barrels1 =
        @"    __ " + "\n" +
        @" __/__\" + "\n" +
        @"/__\[]|" + "\n" +
        @"\__/__/";
    public const string Mountain =
        @"  /\   " + "\n" +
        @" /\/\  " + "\n" +
        @"/    \ " + "\n" +
        @"      \";
    public const string Mountain2 =
        @"  /\   " + "\n" +
        @" /**\  " + "\n" +
        @"/    \ " + "\n" +
        @"      \";
    //〠 toq simvol gurmi igrata
    public const string OldMan =
        @"       " + "\n" +
        @"  .ɒ__ " + "\n" +
        @" /(  ī " + "\n" +
        @"  /\ | ";
    public const string Soldier =
        @"    ȭ  " + "\n" +
        @"•==щ|J " + "\n" +
        @"    |  " + "\n" +
        @"   | \ ";
    public const string Lady =
        @"   'Ố  " + "\n" +
        @"   /)) " + "\n" +
        @"   / | " + "\n" +
        @"   L_| ";
    public const string Guard =
        @"   O  ↑" + "\n" +
        @" ()Y▬▬o" + "\n" +
        @"  /_\ |" + "\n" +
        @"  _W_ |";
    public const string NoteTaker =
       @"  ( ) |" + "\n" +
       @"  _Ō__ḽ" + "\n" +
       @"Ƹ/_/   " + "\n" +
       @" > >   ";
    public static readonly string[] RunRight = new[]
    {
		// 0
		@"   ☻   " + '\n' +
        @"   |_  " + '\n' +
        @"   |)  " + '\n' +
        @"  /|   ",
		// 1
		@"   ☻   " + '\n' +
        @"  (|(  " + '\n' +
        @"   |_  " + '\n' +
        @"   |/  ",
		// 2
		@"   ☻   " + '\n' +
        @"  (|(  " + '\n' +
        @"   |_  " + '\n' +
        @"  /  | ",
		// 3
		@"  _☻   " + '\n' +
        @" | |(  " + '\n' +
        @"   /-  " + '\n' +
        @"  /  | ",
		// 4
		@"  __☻  " + '\n' +
        @" / /\_ " + '\n' +
        @"__/\   " + '\n' +
        @"    \  ",
		// 5
		@"   _☻  " + '\n' +
        @"  |/|_ " + '\n' +
        @"  /\   " + '\n' +
        @" /  |  ",
		// 6
		@"    ☻  " + '\n' +
        @"  (/(  " + '\n' +
        @"   \   " + '\n' +
        @"   /|  ",
    };

    public static readonly string[] RunLeft = new[]
    {
		// 0
		@"   ☻   " + '\n' +
        @"  _|   " + '\n' +
        @"  (|   " + '\n' +
        @"   |\  ",
		// 1
		@"   ☻   " + '\n' +
        @"  )|)  " + '\n' +
        @"  _|   " + '\n' +
        @"  \|   ",
		// 2
		@"   ☻   " + '\n' +
        @"  )|)  " + '\n' +
        @"  _|   " + '\n' +
        @" |  \  ",
		// 3
		@"   ☻_  " + '\n' +
        @"  )| ) " + '\n' +
        @"  _\   " + '\n' +
        @" |  \  ",
		// 4
		@"  ☻__  " + '\n' +
        @" _/\ \ " + '\n' +
        @"   /\__" + '\n' +
        @"  /    ",
		// 5
		@"  ☻_   " + '\n' +
        @" _|\|  " + '\n' +
        @"   /\  " + '\n' +
        @"  |  \ ",
		// 6
		@"  ☻    " + '\n' +
        @"  )\)  " + '\n' +
        @"   /   " + '\n' +
        @"  |\   ",
    };
    //  public static readonly string[] RunDown = new[]
    // {
    //// 0
    //@"   _   " + '\n' +
    //      @"  <|>  " + '\n' +
    //      @"   |   " + '\n' +
    //      @"  / p  ",
    //// 1
    //@"   _   " + '\n' +
    //      @"  (|)  " + '\n' +
    //      @"  _|   " + '\n' +
    //      @"  b \  ",
    //// 2
    //@"   _   " + '\n' +
    //      @"  (|>  " + '\n' +
    //      @"  _|   " + '\n' +
    //      @"  b p  ",
    //// 3
    //@"   _   " + '\n' +
    //      @"  (|)  " + '\n' +
    //      @"   |_  " + '\n' +
    //      @"  p b  ",
    //// 4
    //@"  _o_  " + '\n' +
    //      @"  )|<  " + '\n' +
    //      @"   |_  " + '\n' +
    //      @"  b \  ",
    //// 5
    //@"  o_   " + '\n' +
    //      @"  (\}  " + '\n' +
    //      @"   /\  " + '\n' +
    //      @"  b  p ",
    //// 6
    //@"   _   " + '\n' +
    //      @"  {/)  " + '\n' +
    //      @"  /\   " + '\n' +
    //      @"  b p  ",
    //  };
    //  public static readonly string[] RunUp = new[]
    // {
    //// 0
    //@"   ◍   " + '\n' +
    //      @"  <|>  " + '\n' +
    //      @"   |   " + '\n' +
    //      @"  / b  ",
    //// 1
    //@"   ◍   " + '\n' +
    //      @"  (|)  " + '\n' +
    //      @"  _|   " + '\n' +
    //      @"  b \  ",
    //// 2
    //@"   ◍   " + '\n' +
    //      @"  (|>  " + '\n' +
    //      @"  _|   " + '\n' +
    //      @"  b p  ",
    //// 3
    //@"   ◍   " + '\n' +
    //      @"  (|)  " + '\n' +
    //      @"   |_  " + '\n' +
    //      @"  p b  ",
    //// 4
    //@"  _◍_  " + '\n' +
    //      @"  )|<  " + '\n' +
    //      @"   |_  " + '\n' +
    //      @"  b \  ",
    //// 5
    //@"  ◍_   " + '\n' +
    //      @"  (\}  " + '\n' +
    //      @"   /\  " + '\n' +
    //      @"  b  p ",
    //// 6
    //@"   ◍   " + '\n' +
    //      @"  {/)  " + '\n' +
    //      @"  /\   " + '\n' +
    //      @"  b p  ",
    //  };
    public static readonly string[] RunDown = (string[])RunRight.Clone();
    public static readonly string[] RunUp = (string[])RunLeft.Clone();

    public static readonly string IdleLeft2 =
        @"   ☻   " + '\n' +
        @"  )|)  " + '\n' +
        @"   |   " + '\n' +
        @"  / )  ";

    public static readonly string IdleLeft1 =
        @"   ☻   " + '\n' +
        @"  )|)  " + '\n' +
        @"   |   " + '\n' +
        @"  ( \  ";

    public static readonly string[] IdleLeft =
        Enumerable.Repeat(IdleLeft1, 10).Concat(Enumerable.Repeat(IdleLeft2, 10)).ToArray();

    public static readonly string IdleRight1 =
        @"   ☻   " + '\n' +
        @"  (|(  " + '\n' +
        @"   |   " + '\n' +
        @"  ( \  ";

    public static readonly string IdleRight2 =
        @"   ☻   " + '\n' +
        @"  (|(  " + '\n' +
        @"   |   " + '\n' +
        @"  / )  ";
    public static readonly string[] IdleRight =
        Enumerable.Repeat(IdleRight1, 10).Concat(Enumerable.Repeat(IdleRight2, 10)).ToArray();
    public static readonly string[] IdleDown = (string[])IdleRight.Clone();
    public static readonly string[] IdleUp = (string[])IdleLeft.Clone();

}