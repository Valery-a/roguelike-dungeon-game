//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
using System.Globalization;
using Valery_s_Dungeon;

namespace Valery_s_Dungeon
{
    partial class Card
    {
        public BlackJack.Suit Suit;
        public BlackJack.CardValue CardValue;
        public bool FaceUp = true;


        public const int RenderHeight = 7;

        public string[] Render()
        {
            if (!FaceUp)
            {
                return new string[]
                {
                $".-------.",
                $"| .---. |",
                $"| :|x|: |",
                $"| :|x|: |",
                $"| :|x|: |",
                $"| '---' |",
                $"`-------'",
                };

            }

            char suit = Suit.ToString()[0];
            switch (Suit)
            {
                //case BlackJack.Suit.Clubs:
                //    suit = '♣';
                //    break;
                //case BlackJack.Suit.Diamonds:
                //    suit = '♦';
                //    break;
                //case BlackJack.Suit.Hearts:
                //    suit = '♥';
                //    break;
                //case BlackJack.Suit.Spades:
                //    suit = '♠';
                //    break;
                case BlackJack.Suit.Clubs:
                    suit = '☘';
                    break;
                case BlackJack.Suit.Diamonds:
                    suit = '✟';
                    break;
                case BlackJack.Suit.Hearts:
                    suit = '❦';
                    break;
                case BlackJack.Suit.Spades:
                    suit = '☠';
                    break;
            }
            string value = CardValue switch
            {
                BlackJack.CardValue.Ace => "A",
                BlackJack.CardValue.Ten => "10",
                BlackJack.CardValue.Jack => "J",
                BlackJack.CardValue.Queen => "Q",
                BlackJack.CardValue.King => "K",
                _ => ((int)CardValue).ToString(CultureInfo.InvariantCulture),
            };
            string card = $"{value}{suit}";
            string card2 = $"{suit}";
            string a = card.Length < 3 ? $"{card} " : card;
            string b = card2.Length < 3 ? $"{card2} " : card2;
            return new[]
            {
            $".-------.",
            $"|{a}    |",
            $"|       |",
            $"|   {b}  |",
            $"|       |",
            $"|    {a}|",
            $"`-------'",
            };


        }

    }
}

