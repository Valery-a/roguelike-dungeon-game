//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
namespace Valery_s_Dungeon;

class PlayerHand
{
    public List<Card> Cards = new();
    public int Bet;
    public bool Resolved = false;
    public bool DoubledDown = false;
}

