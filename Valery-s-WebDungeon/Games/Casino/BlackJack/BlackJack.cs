//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using Valery_s_Dungeon;

public class BlackJack
{

    public static async Task Play()
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
                await Render();
                switch ((await BlazorConsole.ReadKey(true)).Key)
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
            await Render();
        GetEnter:
            switch ((await BlazorConsole.ReadKey(true)).Key)
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


        async Task Render()
        {
            Dungeon.currentPlayer.coins = playerMoney;
            BlazorConsole.CursorVisible = false;
            await BlazorConsole.Clear();
            if (state is State.IntroScreen)
            {
                BlazorConsole.ForegroundColor = ConsoleColor.Red;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Green;
                await BlazorConsole.WriteLine(MainSprites.Gambit);
                BlazorConsole.ForegroundColor = ConsoleColor.Red;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Green;
                await BlazorConsole.WriteLine(" ");
                await BlazorConsole.WriteLine("Hear ye, hear ye! Shouldst thou procure the services of a JESTER, thou shalt receive a payment of one and a half times thy original wager.");
                await BlazorConsole.WriteLine("'Tis surely a profitable enterprise, methinks!.");
                await BlazorConsole.WriteLine();
                await BlazorConsole.WriteLine("Thusly doth the JESTER ply his trade:");
                await BlazorConsole.WriteLine("He shall draw from the deck until his hand's score doth reach no less than 17.");
                await BlazorConsole.WriteLine();
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Red;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ForegroundColor = ConsoleColor.Blue;
                await BlazorConsole.WriteLine("           Hit [enter] to continiue!)");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.Red;
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                BlazorConsole.ResetColor();
                return;
            }
            BlazorConsole.ForegroundColor = ConsoleColor.Red;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ForegroundColor = ConsoleColor.DarkGreen;
            await BlazorConsole.WriteLine($"  JESTER's deck, comprised of the following cards: {deck.Count}");
            await BlazorConsole.WriteLine($"  The Discard Pile, where castoff cards doth reside: {discardPile.Count}");
            await BlazorConsole.WriteLine($"  Your hoard of coins: ${playerMoney}");
            BlazorConsole.ForegroundColor = ConsoleColor.Red;
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            BlazorConsole.ResetColor();
            BlazorConsole.ForegroundColor = ConsoleColor.Green;
            if (state is not State.IntroScreen &&
                state is not State.PlaceBet &&
                state is not State.OutOfMoney)
            {
                BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
                await BlazorConsole.WriteLine();
                await BlazorConsole.WriteLine($"  Jester's Hand{(dealerHand.Any(c => !c.FaceUp) ? "" : ($" ({ScoreCards(dealerHand)})"))}:");
                BlazorConsole.ResetColor();
                for (int i = 0; i < Card.RenderHeight; i++)
                {
                    await BlazorConsole.Write("    ");
                    for (int j = 0; j < dealerHand.Count; j++)
                    {
                        string s = dealerHand[j].Render()[i];
                        await BlazorConsole.Write(j < dealerHand.Count - 1 ? s[..5] : s);
                    }
                    await BlazorConsole.WriteLine();
                }
                await BlazorConsole.WriteLine();
                BlazorConsole.ForegroundColor = ConsoleColor.DarkYellow;
                await BlazorConsole.WriteLine($"  Your Hand{(playerHands.Count > 1 ? "s" : "")}:");
                BlazorConsole.ResetColor();
                for (int hand = 0; hand < playerHands.Count; hand++)
                {
                    for (int i = 0; i < Card.RenderHeight; i++)
                    {
                        if (hand == activeHand)
                        {
                            await BlazorConsole.Write(i == Card.RenderHeight / 2 ? "    " : "    ");
                        }
                        else
                        {
                            await BlazorConsole.Write("    ");
                        }
                        for (int j = 0; j < playerHands[hand].Cards.Count; j++)
                        {
                            string s = playerHands[hand].Cards[j].Render()[i];
                            await BlazorConsole.Write(j < playerHands[hand].Cards.Count - 1 ? s[..5] : s);
                        }
                        await BlazorConsole.WriteLine();
                    }
                    BlazorConsole.ForegroundColor = ConsoleColor.Blue;
                    await BlazorConsole.WriteLine($"    Hand Score: {ScoreCards(playerHands[hand].Cards)}");
                    await BlazorConsole.WriteLine($"    Hand Bet: {(playerHands[hand].Bet > 0 ? $"${playerHands[hand].Bet}" : "---")}");
                    BlazorConsole.ResetColor();
                }
            }
            await BlazorConsole.WriteLine();
            if (discardShuffledIntoDeck)
            {
                BlazorConsole.ForegroundColor = ConsoleColor.DarkGray;
                await BlazorConsole.WriteLine("'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.");
                BlazorConsole.ResetColor();
                BlazorConsole.ForegroundColor = ConsoleColor.DarkBlue;
                await BlazorConsole.WriteLine("  The Jester shuffled the discard pile into the deck.");
                BlazorConsole.ForegroundColor = ConsoleColor.DarkGray;
                await BlazorConsole.WriteLine("'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.'.");
                BlazorConsole.ResetColor();
                discardShuffledIntoDeck = false;
            }

            int x = Dungeon.currentPlayer.GetXP();
            switch (state)
            {

                case State.PlaceBet:
                    BlazorConsole.ForegroundColor = ConsoleColor.Red;
                    await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.Green;
                    await BlazorConsole.WriteLine("  Place your bet...");
                    await BlazorConsole.WriteLine("  Use [up] or [down] arrows to increase or decrease bet.");
                    await BlazorConsole.WriteLine("  Hit [enter] to place your bet.");
                    await BlazorConsole.WriteLine("  Hit [e] twice to run away.");
                    await BlazorConsole.WriteLine($"  Bet (${minimumBet}-${playerMoney}): ${bet}");
                    BlazorConsole.ForegroundColor = ConsoleColor.Red;
                    await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    await BlazorConsole.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    BlazorConsole.ResetColor();
                    shouldExit = true;
                    break;
                case State.ConfirmDealtBlackjack:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine("  You were dealt a Jester! (21). You win this hand!");
                    await BlazorConsole.WriteLine("  Your bet was payed out.");
                    await BlazorConsole.WriteLine("  You have gained " + x + "XP!");
                    Dungeon.currentPlayer.xp += x;
                    if (Dungeon.currentPlayer.CanlevelUP())
                    {
                        await Dungeon.currentPlayer.LevelUP();
                    }
                    await BlazorConsole.WriteLine("  Press [enter] to continue...");
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    break;
                case State.ChooseMove:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.DarkCyan;
                    await BlazorConsole.WriteLine("  Choose your move...");
                    await BlazorConsole.WriteLine("  (S)tay");
                    await BlazorConsole.WriteLine("  (H)it");
                    if (CanChop())
                    {
                        await BlazorConsole.WriteLine("  (C)hop");
                    }
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    break;
                case State.ConfirmBust:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
                    await BlazorConsole.WriteLine($"  Bust! Your hand ({ScoreCards(playerHands[activeHand].Cards)}) is greater than 21.");
                    await BlazorConsole.WriteLine("  You lose this bet.");
                    await BlazorConsole.WriteLine("  Press [enter] to continue...");
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    break;
                case State.ConfirmChop:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.DarkBlue;
                    await BlazorConsole.WriteLine("  You Chop your hand and the dealer dealt you an additional");
                    await BlazorConsole.WriteLine("  card to each Chop.");
                    await BlazorConsole.WriteLine("  Press [enter] to continue...");
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    break;
                case State.ConfirmDealerDraw:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.Blue;
                    await BlazorConsole.WriteLine("  The Jester drew a card to his hand.");
                    await BlazorConsole.WriteLine("  Press [enter] to continue...");
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    break;
                case State.ConfirmDealerCardFlip:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.Blue;
                    await BlazorConsole.WriteLine("  The Jester flipped over his second card.");
                    await BlazorConsole.WriteLine("  Press [enter] to continue...");
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    break;
                case State.ConfirmLoss:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
                    await BlazorConsole.WriteLine($"  Lost! The Jester ({ScoreCards(dealerHand)}) beat your hand ({ScoreCards(playerHands[activeHand].Cards)}).");
                    await BlazorConsole.WriteLine("  Press [enter] to continue...");
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    break;
                case State.ConfirmDraw:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.Cyan;
                    await BlazorConsole.WriteLine($"  Draw! This hand was equal to the Jester's hand ({ScoreCards(dealerHand)}).");
                    await BlazorConsole.WriteLine($"  Your bet was returned to you.");
                    await BlazorConsole.WriteLine("  Press [enter] to continue...");
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor(); break;
                case State.ConfirmWin:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.Yellow;
                    await BlazorConsole.WriteLine($"  Win! The Jester {(ScoreCards(dealerHand) > 21 ? "busted" : "stands")} ({ScoreCards(dealerHand)}).");
                    await BlazorConsole.WriteLine($"  Your bet was payed out.");
                    await BlazorConsole.WriteLine("  You have gained " + x + "XP!");
                    Dungeon.currentPlayer.xp += x;
                    if (Dungeon.currentPlayer.CanlevelUP())
                    {
                        await Dungeon.currentPlayer.LevelUP();
                    }
                    await BlazorConsole.WriteLine("  Press [enter] to continue!");
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    break;
                case State.OutOfMoney:
                    shouldExit = false;
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
                    BlazorConsole.ForegroundColor = ConsoleColor.DarkRed;
                    await BlazorConsole.WriteLine($"  You ran out of money. Better luck next time.");
                    await BlazorConsole.WriteLine("  Press [enter] to close the game...");
                    BlazorConsole.ForegroundColor = ConsoleColor.Magenta;
                    await BlazorConsole.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
                    BlazorConsole.ResetColor();
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