//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using Valery_s_Dungeon;

public class BlackJack
{

    public static void Play()
    {
        Exception? exception = null;

        Random random = new();
        List<Card> deck;
        List<Card> discardPile;
        List<PlayerHand> playerHands;
        List<Card> dealerHand;
        int playerMoney = Dungeon.currentPlayer.coins;
        const int minimumBet = 24;
        int previousBet = 24;
        int bet;
        int activeHand;
        State state = State.IntroScreen;
        bool discardShuffledIntoDeck = false;
        bool shouldExit = false;

        try
        {
            Initialize();
            DefaultBet();
            activeHand = 0;
            while (!(state is State.PlaceBet && playerMoney < minimumBet))
            {
                Render();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        switch (state)
                        {
                            case State.IntroScreen:
                                state = State.PlaceBet;
                                break;
                            case State.PlaceBet:
                                playerMoney -= bet;

                                previousBet = bet;
                                InitializeRound();
                                if (ScoreCards(playerHands[activeHand].Cards) is 21)
                                {
                                    playerMoney += (playerHands[activeHand].Bet / 2) * 3;
                                    playerHands[activeHand].Bet = 0;
                                    playerHands[activeHand].Resolved = true;
                                    state = State.ConfirmDealtBlackjack;
                                    break;
                                }
                                state = State.ChooseMove;
                                break;
                            case State.ConfirmChop:
                                if (ScoreCards(playerHands[activeHand].Cards) is 21)
                                {
                                    playerMoney += (playerHands[activeHand].Bet / 2) * 3;

                                    playerHands[activeHand].Bet = 0;
                                    playerHands[activeHand].Resolved = true;
                                    state = State.ConfirmDealtBlackjack;
                                    break;
                                }
                                state = State.ChooseMove;
                                break;
                            case State.ConfirmDealtBlackjack
                                or State.ConfirmBust:
                                ProgressStateAfterHandCompletion();
                                break;
                            case State.ConfirmDraw
                                or State.ConfirmLoss
                                or State.ConfirmDealerCardFlip
                                or State.ConfirmDealerDraw
                                or State.ConfirmWin:
                                ProgressStateAfterDealerAction();
                                break;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (state is State.PlaceBet)
                        {
                            bet = Math.Max(minimumBet, bet - 2);
                        }
                        break;
                    case ConsoleKey.E:
                        if (shouldExit == true)
                        {
                            return;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (state is State.PlaceBet)
                        {
                            bet = Math.Min(playerMoney, bet + 2);
                            if (bet % 2 is 1)
                            {
                                bet--;
                            }
                        }
                        break;
                    case ConsoleKey.S: // stay
                        if (state is State.ChooseMove)
                        {
                            ProgressStateAfterHandCompletion();
                        }
                        break;
                    case ConsoleKey.H: // hit
                        if (state is State.ChooseMove)
                        {
                            playerHands[activeHand].Cards.Add(deck[^1]);
                            deck.RemoveAt(deck.Count - 1);
                            if (ScoreCards(playerHands[activeHand].Cards) > 21)
                            {
                                playerHands[activeHand].Resolved = true;
                                playerHands[activeHand].Bet = 0;
                                state = State.ConfirmBust;
                            }
                        }
                        break;
                    case ConsoleKey.C: // Chop (Chop)
                        if (state is State.ChooseMove && CanChop())
                        {
                            playerMoney -= playerHands[activeHand].Bet;
                            playerHands.Add(new());
                            playerHands[^1].Bet = playerHands[activeHand].Bet;
                            playerHands[^1].Cards.Add(playerHands[activeHand].Cards[^1]);
                            playerHands[activeHand].Cards.RemoveAt(playerHands[activeHand].Cards.Count - 1);
                            playerHands[activeHand].Cards.Add(deck[^1]);
                            deck.RemoveAt(deck.Count - 1);
                            playerHands[^1].Cards.Add(deck[^1]);
                            deck.RemoveAt(deck.Count - 1);
                            state = State.ConfirmChop;
                        }
                        break;

                }
            }
            state = State.OutOfMoney;
            Render();
        GetEnter:
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter: return;
                default: goto GetEnter;
            }
        }
        catch (Exception e)
        {
            exception = e;
            throw;
        }


        void Render()
        {
            Dungeon.currentPlayer.coins = playerMoney;
            Console.CursorVisible = false;
            Console.Clear();
            if (state is State.IntroScreen)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(MainSprites.Gambit);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ");
                Console.WriteLine("Hear ye, hear ye! Shouldst thou procure the services of a JESTER, thou shalt receive a payment of one and a half times thy original wager.");
                Console.WriteLine("'Tis surely a profitable enterprise, methinks!.");
                Console.WriteLine();
                Console.WriteLine("Thusly doth the JESTER ply his trade:");
                Console.WriteLine("He shall draw from the deck until his hand's score doth reach no less than 17.");
                Console.WriteLine();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("           Hit [enter] to continiue!)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"  JESTER's deck, comprised of the following cards: {deck.Count}");
            Console.WriteLine($"  The Discard Pile, where castoff cards doth reside: {discardPile.Count}");
            Console.WriteLine($"  Your hoard of coins: ${playerMoney}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            if (state is not State.IntroScreen &&
                state is not State.PlaceBet &&
                state is not State.OutOfMoney)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine($"  Jester's Hand{(dealerHand.Any(c => !c.FaceUp) ? "" : ($" ({ScoreCards(dealerHand)})"))}:");
                Console.ResetColor();
                for (int i = 0; i < Card.RenderHeight; i++)
                {
                    Console.Write("    ");
                    for (int j = 0; j < dealerHand.Count; j++)
                    {
                        string s = dealerHand[j].Render()[i];
                        Console.Write(j < dealerHand.Count - 1 ? s[..5] : s);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"  Your Hand{(playerHands.Count > 1 ? "s" : "")}:");
                Console.ResetColor();
                for (int hand = 0; hand < playerHands.Count; hand++)
                {
                    for (int i = 0; i < Card.RenderHeight; i++)
                    {
                        if (hand == activeHand)
                        {
                            Console.Write(i == Card.RenderHeight / 2 ? "    " : "    ");
                        }
                        else
                        {
                            Console.Write("    ");
                        }
                        for (int j = 0; j < playerHands[hand].Cards.Count; j++)
                        {
                            string s = playerHands[hand].Cards[j].Render()[i];
                            Console.Write(j < playerHands[hand].Cards.Count - 1 ? s[..5] : s);
                        }
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"    Hand Score: {ScoreCards(playerHands[hand].Cards)}");
                    Console.WriteLine($"    Hand Bet: {(playerHands[hand].Bet > 0 ? $"${playerHands[hand].Bet}" : "---")}");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            if (discardShuffledIntoDeck)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("  The Jester shuffled the discard pile into the deck.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.");
                Console.ResetColor();
                discardShuffledIntoDeck = false;
            }

            int x = Dungeon.currentPlayer.GetXP();
            switch (state)
            {

                case State.PlaceBet:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("  Place your bet...");
                    Console.WriteLine("  Use [up] or [down] arrows to increase or decrease bet.");
                    Console.WriteLine("  Hit [enter] to place your bet.");
                    Console.WriteLine("  Hit [e] twice to run away.");
                    Console.WriteLine($"  Bet (${minimumBet}-${playerMoney}): ${bet}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.ResetColor();
                    shouldExit = true;
                    break;
                case State.ConfirmDealtBlackjack:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  You were dealt a Jester! (21). You win this hand!");
                    Console.WriteLine("  Your bet was payed out.");
                    Console.WriteLine("  You have gained " + x + "XP!");
                    Dungeon.currentPlayer.xp += x;
                    if (Dungeon.currentPlayer.CanlevelUP())
                    {
                        Dungeon.currentPlayer.LevelUP();
                    }
                    Console.WriteLine("  Press [enter] to continue...");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    break;
                case State.ChooseMove:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("  Choose your move...");
                    Console.WriteLine("  (S)tay");
                    Console.WriteLine("  (H)it");
                    if (CanChop())
                    {
                        Console.WriteLine("  (C)hop");
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    break;
                case State.ConfirmBust:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"  Bust! Your hand ({ScoreCards(playerHands[activeHand].Cards)}) is greater than 21.");
                    Console.WriteLine("  You lose this bet.");
                    Console.WriteLine("  Press [enter] to continue...");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    break;
                case State.ConfirmChop:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("  You Chop your hand and the dealer dealt you an additional");
                    Console.WriteLine("  card to each Chop.");
                    Console.WriteLine("  Press [enter] to continue...");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    break;
                case State.ConfirmDealerDraw:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("  The Jester drew a card to his hand.");
                    Console.WriteLine("  Press [enter] to continue...");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    break;
                case State.ConfirmDealerCardFlip:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("  The Jester flipped over his second card.");
                    Console.WriteLine("  Press [enter] to continue...");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    break;
                case State.ConfirmLoss:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"  Lost! The Jester ({ScoreCards(dealerHand)}) beat your hand ({ScoreCards(playerHands[activeHand].Cards)}).");
                    Console.WriteLine("  Press [enter] to continue...");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    break;
                case State.ConfirmDraw:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"  Draw! This hand was equal to the Jester's hand ({ScoreCards(dealerHand)}).");
                    Console.WriteLine($"  Your bet was returned to you.");
                    Console.WriteLine("  Press [enter] to continue...");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor(); break;
                case State.ConfirmWin:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"  Win! The Jester {(ScoreCards(dealerHand) > 21 ? "busted" : "stands")} ({ScoreCards(dealerHand)}).");
                    Console.WriteLine($"  Your bet was payed out.");
                    Console.WriteLine("  You have gained " + x + "XP!");
                    Dungeon.currentPlayer.xp += x;
                    if (Dungeon.currentPlayer.CanlevelUP())
                    {
                        Dungeon.currentPlayer.LevelUP();
                    }
                    Console.WriteLine("  Press [enter] to continue!");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    break;
                case State.OutOfMoney:
                    shouldExit = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"  You ran out of money. Better luck next time.");
                    Console.WriteLine("  Press [enter] to close the game...");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    Console.ResetColor();
                    break;
                default:
                    throw new NotImplementedException();

            }

        }

        bool CanChop() =>
            playerMoney >= playerHands[activeHand].Bet &&
            playerHands[activeHand].Cards.Count is 2 &&
            playerHands[activeHand].Cards[0].CardValue == playerHands[activeHand].Cards[1].CardValue &&
            playerHands.Count < 4;

        int ScoreCards(List<Card> cards)
        {
            int score = 0;
            int numberOfAces = 0;
            foreach (Card card in cards)
            {
                if (card.CardValue is CardValue.King or CardValue.Queen or CardValue.Jack)
                {
                    score += 10;
                }
                else if (card.CardValue is not CardValue.Ace)
                {
                    score += (int)card.CardValue;
                }
                else
                {
                    numberOfAces++;
                }
            }
            if (numberOfAces is 0)
            {
                return score;
            }
            int scoreWithAn11 = score + 11 + (numberOfAces - 1);
            if (scoreWithAn11 <= 21)
            {
                return scoreWithAn11;
            }
            else
            {
                return score + numberOfAces;
            }
        }

        void Initialize()
        {
            discardPile = new();
            playerHands = new();
            dealerHand = new();
            deck = new();
            foreach (Suit suit in Enum.GetValues<Suit>())
            {
                foreach (CardValue value in Enum.GetValues<CardValue>())
                {
                    deck.Add(new()
                    {
                        Suit = suit,
                        CardValue = value,
                        FaceUp = true,
                    });
                }
            }
            Shuffle(deck);
        }

        void InitializeRound()
        {
            playerHands = new();
            playerHands.Add(new());
            playerHands[0].Bet = bet;
            playerHands[0].Cards.Add(DrawCard());
            playerHands[0].Cards.Add(DrawCard());
            dealerHand = new();
            dealerHand.Add(DrawCard());
            dealerHand.Add(DrawCard());
            dealerHand[^1].FaceUp = false;
        }

        bool UnresolvedHands()
        {
            bool unresolvedHands = false;
            foreach (PlayerHand hand in playerHands)
            {
                if (!hand.Resolved)
                {
                    unresolvedHands = true;
                    break;
                }
            }
            return unresolvedHands;
        }

        void ProgressStateAfterHandCompletion()
        {
            if (!UnresolvedHands())
            {
                discardPile.AddRange(dealerHand);
                foreach (PlayerHand hand in playerHands)
                {
                    discardPile.AddRange(hand.Cards);
                }
                activeHand = 0;
                DefaultBet();
                state = State.PlaceBet;
                return;
            }
            do
            {
                activeHand++;
            } while (activeHand < playerHands.Count - 1 && ScoreCards(playerHands[activeHand].Cards) > 21);
            if (activeHand < playerHands.Count)
            {
                if (ScoreCards(playerHands[activeHand].Cards) is 21)
                {
                    playerMoney += (playerHands[activeHand].Bet / 2) * 3;
                    playerHands[activeHand].Bet = 0;
                    playerHands[activeHand].Resolved = true;
                    state = State.ConfirmDealtBlackjack;
                    return;
                }
                state = State.ChooseMove;
            }
            else
            {
                activeHand = 0;
                dealerHand[^1].FaceUp = true;
                state = State.ConfirmDealerCardFlip;
            }
        }

        void ProgressStateAfterDealerAction()
        {
            if (!UnresolvedHands())
            {
                discardPile.AddRange(dealerHand);
                foreach (PlayerHand hand in playerHands)
                {
                    discardPile.AddRange(hand.Cards);
                }
                activeHand = 0;
                DefaultBet();
                state = State.PlaceBet;
                return;
            }
            if (playerHands.Any(hand => !hand.Resolved) && ScoreCards(dealerHand) < 17)
            {
                dealerHand.Add(DrawCard());
                state = State.ConfirmDealerDraw;
                return;
            }
            for (int i = 0; i < playerHands.Count; i++)
            {
                if (!playerHands[i].Resolved)
                {
                    if (ScoreCards(dealerHand) > 21 || ScoreCards(dealerHand) < ScoreCards(playerHands[i].Cards))
                    {
                        activeHand = i;
                        playerMoney += playerHands[activeHand].Bet * 2;
                        playerHands[activeHand].Resolved = true;
                        state = State.ConfirmWin;
                        return;
                    }
                    else if (ScoreCards(playerHands[i].Cards) < ScoreCards(dealerHand))
                    {
                        activeHand = i;
                        playerHands[activeHand].Bet = 0;
                        playerHands[activeHand].Resolved = true;
                        state = State.ConfirmLoss;
                        return;
                    }
                    else if (ScoreCards(playerHands[i].Cards) == ScoreCards(dealerHand))
                    {
                        activeHand = i;
                        playerMoney += playerHands[activeHand].Bet;
                        playerHands[activeHand].Bet = 0;
                        playerHands[activeHand].Resolved = true;
                        state = State.ConfirmDraw;
                        return;
                    }
                }
            }
        }

        void DefaultBet()
        {
            bet = Math.Min(playerMoney, previousBet);
            if (bet % 2 is 1)
            {
                bet--;
            }
        }

        void Shuffle(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int swap = random.Next(cards.Count);
                (cards[i], cards[swap]) = (cards[swap], cards[i]);
            }
        }

        void ShuffleDiscardIntoDeck()
        {
            deck.AddRange(discardPile);
            discardPile.Clear();
            Shuffle(deck);
            discardShuffledIntoDeck = true;
        }

        Card DrawCard()
        {
            if (deck.Count <= 0)
            {
                ShuffleDiscardIntoDeck();
            }
            Card card = deck[^1];
            deck.RemoveAt(deck.Count - 1);
            return card;
        }
    }
    public enum Suit
    {
        Hearts,
        Clubs,
        Spades,
        Diamonds,
    }

    public enum CardValue
    {
        Ace = 01,
        Two = 02,
        Three = 03,
        Four = 04,
        Five = 05,
        Six = 06,
        Seven = 07,
        Eight = 08,
        Nine = 09,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }

    public enum State
    {
        IntroScreen,
        PlaceBet,
        ConfirmDealtBlackjack,
        ChooseMove,
        ConfirmBust,
        ConfirmChop,
        ConfirmDealerDraw,
        ConfirmDealerCardFlip,
        ConfirmLoss,
        ConfirmDraw,
        ConfirmWin,
        OutOfMoney,
    }
}