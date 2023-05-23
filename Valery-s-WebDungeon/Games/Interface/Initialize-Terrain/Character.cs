//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

namespace Valery_s_Dungeon;

public class Character
{
    public int I { get; set; }
    public int J { get; set; }
    // TileI and TileJ represent the character's position in tile coordinates
    // relative to the current map
    public int TileI => I < 0 ? (I - 6) / 7 : I / 7;
    public int TileJ => J < 0 ? (J - 3) / 4 : J / 4;
    private string[]? _mapAnaimation;
    public string[]? MapAnimation
    {
        get => _mapAnaimation;
        set
        {
            _mapAnaimation = value;
            _mapAnimationFrame = 0;
        }
    }
    private int _mapAnimationFrame;
    public int MapAnimationFrame
    {
        get => _mapAnimationFrame;
        set
        {
            _mapAnimationFrame = value;
            Moved = false;
            if (_mapAnimationFrame >= MapAnimation!.Length)
            {
                if (MapAnimation == Sprites.RunUp) { Moved = true; MapAnimation = Sprites.IdleUp; }
                if (MapAnimation == Sprites.RunDown) { Moved = true; MapAnimation = Sprites.IdleDown; }
                if (MapAnimation == Sprites.RunLeft) { Moved = true; MapAnimation = Sprites.IdleLeft; }
                if (MapAnimation == Sprites.RunRight) { Moved = true; MapAnimation = Sprites.IdleRight; }
                _mapAnimationFrame = 0;
            }
        }
    }
    public bool IsIdle
    {
        get =>
            _mapAnaimation == Sprites.IdleDown ||
            _mapAnaimation == Sprites.IdleUp ||
            _mapAnaimation == Sprites.IdleLeft ||
            _mapAnaimation == Sprites.IdleRight;
    }
    public string Render =>
        _mapAnaimation is not null && _mapAnimationFrame < _mapAnaimation.Length
        ? _mapAnaimation[_mapAnimationFrame]
        : // "T" pose :D
          @" __☻__ " + '\n' +
          @"   |   " + '\n' +
          @"   |   " + '\n' +
          @"  | |  ";
    public bool Moved { get; set; } = false;
}
