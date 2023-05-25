//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
using Valery_s_Dungeon;

namespace Valery_s_Dungeon

{
    [Serializable]
    public class Player
    {
        public bool demonInteractNote = false;
        public bool demonInteract = false;
        public bool mermaidInteract = false;
        public bool oldmanstoryInteract = false;
        public int armorV = 0;
        public int damage = 1;
        public int health = 20;
        public int coins = 10;
        public string? name;
        public int potions = 3;
        public int weaponV = 1;
        public int diffmods = 0;
        public int level = 0;
        public int xp = 0;

        public int GetCoins()
        {
            int upper = (15 * diffmods + 50);
            int lower = (10 * diffmods + 10);
            return Dungeon.rand.Next(lower, upper);
        }
        public int GetTougher()
        {
            int upper = (2 * diffmods + 5);
            int lower = (diffmods + 3);
            return Dungeon.rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * diffmods + 2);
            int lower = (diffmods + 1);
            return Dungeon.rand.Next(lower, upper);
        }
        public enum PlayerClass { Healer, Acrobat, Berserk }
        public PlayerClass currentClass = PlayerClass.Berserk;


        public int GetXP()
        {
            int upper = (20 * diffmods + 50);
            int lower = (10 * diffmods + 19);
            return Dungeon.rand.Next(lower, upper);
        }

        //suzdavam helper fukciite

        public int GetLevelUpV()
        {
            return 100 * level + 400;
        }

        public bool CanlevelUP()
        {
            if (xp >= GetLevelUpV())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task LevelUP()
        {
            while (CanlevelUP())
            {
                xp -= GetLevelUpV();
                level++;
            }
            await BlazorConsole.Clear();
            //dobawqm cvqt
            BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
            await Dungeon.Print("You just leveled up! Your new level is " + level + " !!!");
            BlazorConsole.ResetColor();
        }
    }
}

