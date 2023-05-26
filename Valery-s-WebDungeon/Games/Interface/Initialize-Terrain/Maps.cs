//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

namespace Valery_s_Dungeon;

public static class Maps
{
    public static string GetMapTileRender(char[][] map, int tileI, int tileJ)
    {
        if (tileJ < 0 || tileJ >= map.Length || tileI < 0 || tileI >= map[tileJ].Length)
        {
            //if (map == Field) return Sprites.Mountain;
            //else if (map == Town) return Sprites.Tree;
            //return Sprites.Open;
            if (map == Field) return Sprites.Open;
            else if (map == Town) return Sprites.Open;
            return Sprites.Open;
        }
        return map[tileJ][tileI] switch
        {
            'G' => Sprites.Guard,
            'J' => Sprites.JhinGames,
            'C' => Sprites.Church,
            'Z' => Sprites.Casino1,
            'z' => Sprites.Casino2,
            'n' => Sprites.Casino3,
            'w' => Sprites.Water,
            'I' => Sprites.Water1,
            'W' => Sprites.Wall_0000,
            'r' => Sprites.Wall_0001,
            'b' => Sprites.Building,
            't' => Sprites.Tree,
            ' ' or 'X' => Sprites.Open,
            'i' => Sprites.Inn,
            's' => Sprites.Store,
            'c' => Sprites.Chest,
            'e' => Sprites.EmptyChest,
            'B' => Sprites.Barrels1,
            //'1' => tileJ < map.Length / 2 ? Sprites.ArrowUp : Sprites.ArrowDown,
            '1' => Sprites.Spawn,
            '7' => Sprites.DungeonEnterance,
            'm' => Sprites.Mountain,
            '0' => Sprites.Town,
            'g' => Sprites.OldMan,
            'u' => Sprites.OldHouse,
            'o' => Sprites.StoneNodes,
            'O' => Sprites.StoneNodes1,
            'p' => Sprites.Mountain2,
            'T' => Sprites.Tree2,
            'N' => Sprites.NoteTaker,
            //'h' => Sprites.Wall_0000, 
            'l' => Sprites.Lady,
            _ => throw new NotImplementedException()
        };
    }

    public static bool IsValidCharacterMapTile(char[][] map, int tileI, int tileJ)
    {
        if (tileJ < 0 || tileJ >= map.Length || tileI < 0 || tileI >= map[tileJ].Length)
        {
            return false;
        }
        return map[tileJ][tileI] switch
        {
            'N' => true,
            'J' => true,
            '7' => true,
            'g' => true,
            'l' => true,
            'z' => true,
            'C' => true,
            ' ' => true,
            'i' => true,
            's' => true,
            'c' => true,
            'e' => true,
            '1' => true,
            '0' => true,
            'G' => true,
            'X' => true,
            'k' => true,
            'I' => true,
            //'h' => true,
            _ => false,
        };
    }
    // J is isolated temporarily
    public static readonly char[][] Town = new char[][]
   {
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTwwwwwTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTmmpmTTTTTTTTTTTTTwwwwwwwwwwwTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTpmppmpmTTTTTTTTTTwwwwwwwwwwwwwwwT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTpmpmmpmppmmpTTTTTTTTwwwwwwwwwwwwwwwT".ToCharArray(),
        "TTTTTTTTTTTTTmmpmpmpmmpmppmmmpppTTTTTTTwwwwwwwwwwwwwwT".ToCharArray(),
        "TTTTTTTTmpmppmmpmpmpmmpmppmmpmmpmpTTTTTTTTwwwwwwwwwwwT".ToCharArray(),
        "TTTTmmpmmpmppmmpmpmpmmpmppmmpmpmpmmpmpmpmTTTwwwTTTTTTT".ToCharArray(),
        "TTmpmmpmmpmppmmpmpmpmmpmppmmpmpmpmmpmpmpmpTTTTTTTTTTTT".ToCharArray(),
        "TTTTmmpmmpmpmpmpmpmpmpWWWWWWWWWWWWWWWWWpmpmpppTTTTTTTT".ToCharArray(),
        "TTTTmmpmmmpmpmpmpmWWWWWtTttTtTZznTTTtcWWmpmpmpmmmpTTTT".ToCharArray(),
        "TTTTTTTmmpmpmpWWWWWtTtTtTtTT      bBT  WmpmpmpmmmpmTTT".ToCharArray(),
        "TTTTTTTTpmpmpWWTTTtT                   WWpmWWWWmmpmpTT".ToCharArray(),
        "TTTTTTTTmpmpWWBBbbB                     WpWWoOWWmpmpmT".ToCharArray(),
        "TTTTTTpmmpmpWtTtBbB l                    r    sWmpmpTT".ToCharArray(),
        "TTTTTmpmmpmpWWWWbB           WWWWWWW     X   oWWmpmpTT".ToCharArray(),
        "TTTTTTmpmpmppmmWWTTi         WtTpmmWWWO      WWmmpmpmT".ToCharArray(),
        "TTTTTTTmpmmmpmmpWWtTTc      WWtTpmmpmWWoO   mpmmmpTTTT".ToCharArray(),
        "TTTTTTTTmpmmpmmpmWWWWWW     rTtTpmmpmpmmp77mppmmTTTTTT".ToCharArray(),
        "TTTTTTTTTTmmpmpmmpTTTTWG    G   ppTTmpmmpmmpmTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTmppmTTTTTTTTT             TtTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTT               TTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTT              TTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTT                TTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTT               TTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTT                     TTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTT                     TTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTT              TTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTT      TTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTt111tTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT".ToCharArray(),
   };

    public static readonly char[][] Field = new char[][]
    {
        "mmpmmmpmpmpmpmpmpmpmpmpmppmpmmppmpmmpmpmpmpmpmpmpmpmmmp".ToCharArray(),
        "mmpmmmpmpmpmpmpmpmpmpmpmTTTTTTTTTTTmpmpmpmpmpmpmpmpmmmp".ToCharArray(),
        "mmpmmmpmpmpmpmpmpmTTTTTTTTTTTTTTTTTTTTTTTTTTTmpmpmpmmmp".ToCharArray(),
        "mmpmmmpmpmpmTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTmpmpmmmp".ToCharArray(),
        "mmpmmpmmpTTTTTTTTTTTTTTTTt0tTTTTTTTTTTTTTTTTTTTTTTmpmmp".ToCharArray(),
        "mmpmmpmmTTTTTTTTTTTTTTTT    TTTTTTTTT      TTTTTTTTpmmmp".ToCharArray(),
        "mmpmmpmmpTTTTTTTTTTTTT         cTTT           TTTTTTTmp".ToCharArray(),
        "mmpmmpmmpmTTTTTTTTTTTTTT     TTTTT     TTT   TTTTTTTmmp".ToCharArray(),
        "mmpmmpmmpmpTTTTT  TTTTTTTT   TT     TTTTTTT  TTTTTTTTmp".ToCharArray(),
        "mmpmmpmmpmppmTT  TTTTTTTT     TT TTTTTTTTT    TTTTTTmmpmpmpmpwwwwwww".ToCharArray(),
        "mmpmmpmmpmpTTTT    TTTTT       TTTTT  TTT    TTTTTTTTmpwwwwwwwwwwwww".ToCharArray(),
        "mmpmmpmmTTTTTTTT      TT TTT  TTTT c TTT    tttTTtttTTwwwwwwwwwwwwwwww".ToCharArray(),
        "pmpmmmTtTtt gu TTT     TTTTT    T   TTTTT     wwwwwwwwwwwwwwwwwwwwwwww".ToCharArray(),
        "pmpmmTTtt           TTTTTTTTT  TTT             wwwwwwwwwwwwwwwwwwwwwwww".ToCharArray(),
        "pmpmmTTtT        TTTT           TTTT            Iwwwwwwwwwwwwwwwwwwwwwww".ToCharArray(),
        "pmpmTTTc                 C      TTTTT N        wwwwwwwwwwwwwwwwwwwwwwww".ToCharArray(),
        "pmpmTTTtT       TTTT           TTTTT            wwwwwwwwwwwwwwwwwwwwwwww".ToCharArray(),
        "pmpmmTTtt  TTTTTTTTTT          TT              wwwwwwwwwwwwwwwwwwwwwwww".ToCharArray(),
        "pmpmmmpTt TTTTTTTTTTTTT                       wwwwwwwwwwwwwwwwwwwwwwww".ToCharArray(),
        "pmpmmmpTtTTTTTTTTTTTTTTT       TTTT            wwwwwwwwwwwwwwwwwwwwwwww".ToCharArray(),
        "mmpmmpmmpmTTTtttTTTTTTTT        TTtttTTT   TTtTttTTtTmwwwwwwwwwwwwwwwww".ToCharArray(),
        "mmpmmpmmpmppTTTTTTTTTTTTTT   TTTTTTTTc    TTTTTTTTTTmmpmpwwwwwwwwwww".ToCharArray(),
        "mmpmmpmmpmppmmTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTmp".ToCharArray(),
        "mmpmmmpmpmpmpmpmpTTTTTTTTTTTTTTTTTTTTTTTTTTTpmpmpmpmmmp".ToCharArray(),
        "mmpmmmpmpmpmpmpmpmpmpmpmppTTTTTTTTTTTTTTpmpmpmpmpmpmmmp".ToCharArray(),
        "mmpmmmpmpmpmpmpmpmpmpmpmppmpmmppmpmmpmpmpmpmpmpmpmpmmmp".ToCharArray(),

    };
}
