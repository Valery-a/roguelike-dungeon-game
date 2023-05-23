//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
using System.Diagnostics.Metrics;

namespace Valery_s_Dungeon
{
    public class Puzzles
    {
        static char[,] board = new char[3, 3]; // 2D array to hold the Tic Tac Toe board
        static bool playerTurn = true; // boolean variable to keep track of whose turn it is (true = player, false = AI)
        static Random rand = new Random();
        //===================================================================================================//
        public static async Task Puzzle1()
        {
            await BlazorConsole.Clear();
            await BlazorConsole.WriteLine("After a lot of fearsome battles you stumble across a giant wall with strange symbols written on it.");
            await BlazorConsole.WriteLine("You see that the wall is full of colorful plates (represented as numbers)");
            await BlazorConsole.ReadKey();
            await BlazorConsole.Clear();
            await BlazorConsole.WriteLine("You realise that this is no orinary room!");
            await BlazorConsole.WriteLine("To complete this puzzle you need to look for the most repeated number in each column and row");
            await BlazorConsole.WriteLine("Type a number between 1 and 4 that represents the most repeated number. (LEFT to RIGHT)");

            List<char> chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8' }.ToList();
            List<int> positions = new List<int>();
            char c = chars[rand.Next(0, 9)];
            chars.Remove(c);
            for (int y = 0; y < 4; y++)
            {
                int pos = rand.Next(0, 2);
                positions.Add(pos);
                for (int x = 0; x < 4; x++)
                {
                    if (x == pos)
                    {
                        await BlazorConsole.Write(c);
                    }
                    else
                    {
                        await BlazorConsole.Write(chars[rand.Next(0, 7)]);
                    }
                }
                await BlazorConsole.Write("\n");
            }
            await BlazorConsole.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    //chekwa dali e cqlo chislo
                    if (int.TryParse(await BlazorConsole.ReadLine(), out int input) && input < 5 && input > 0)
                    {
                        if (positions[i] == input - 1)
                        {
                            break;
                        }
                        else
                        {
                            await BlazorConsole.WriteLine("You hear a voice in your head that says.");
                            await BlazorConsole.WriteLine("Denkata shte zawursi!?");
                            await BlazorConsole.WriteLine("That makes you feel anxious and you want to smash something so bad! " +
                                "That you end up hurting yourself.");
                            await BlazorConsole.WriteLine("You lost 1 health.");
                            Dungeon.currentPlayer.health -= 2;
                            if (Dungeon.currentPlayer.health <= 0)
                            {
                                await BlazorConsole.WriteLine("You start hitting yourself in the head, hoping that Denkata da ne zawurshi!");
                                await BlazorConsole.WriteLine("But after countless hours you can't get rid of it and just decide to end it.");
                                await BlazorConsole.WriteLine("You died!");
                                await BlazorConsole.ReadKey();
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                await BlazorConsole.WriteLine("Luckuly you find an elixir that stops that noise.");
                            }

                            break;

                        }
                    }
                    else
                    {
                        await BlazorConsole.WriteLine("Invalid Input! Try a number between 1 and 4");

                    }
                }
            }
            await BlazorConsole.WriteLine("You have succsessfuly finished the puzzle!");
            await BlazorConsole.ReadKey();


        }
        //===================================================================================================//
        public static async Task Puzzle2()
        {
            await BlazorConsole.Clear();
            await BlazorConsole.WriteLine("You stumble across a room with a table sitting in the middle.");
            await BlazorConsole.WriteLine("As you get closer, you see that a creature appears before you.");
            await BlazorConsole.WriteLine("He invites you to play a game of tictactoe with him. How can you not accept?");
            await BlazorConsole.ReadKey();
            await BlazorConsole.Clear();

            InitializeBoard();
            await DisplayBoard();

            while (!CheckForWin() && !CheckForTie())
            {
                if (playerTurn)
                {
                    await PlayerMove();
                }
                else
                {
                    await AIMove();
                }

                playerTurn = !playerTurn; // switch turns
                await DisplayBoard();
            }

            if (CheckForWin())
            {
                if (playerTurn)
                {
                    await BlazorConsole.WriteLine("You lost!");
                }
                else
                {
                    await BlazorConsole.WriteLine("You won!");
                }
            }
            else
            {
                await BlazorConsole.WriteLine("Tie game!");
            }

            await BlazorConsole.ReadLine();

            static void InitializeBoard()
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        board[row, col] = '-';
                    }
                }
            }

            static async Task DisplayBoard()
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        await BlazorConsole.Write(board[row, col] + " ");
                    }
                    await BlazorConsole.WriteLine();
                }
            }

            static bool CheckForWin()
            {
                // check rows
                for (int row = 0; row < 3; row++)
                {
                    if (board[row, 0] != '-' && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                    {
                        return true;
                    }
                }

                // check columns
                for (int col = 0; col < 3; col++)
                {
                    if (board[0, col] != '-' && board[0, col] == board[1, col] && board[1, col] == board[2, col])
                    {
                        return true;
                    }
                }

                // check diagonals
                if (board[0, 0] != '-' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                {
                    return true;
                }
                if (board[0, 2] != '-' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                {
                    return true;
                }

                return false;
            }

            static bool CheckForTie()
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row, col] == '-')
                        {
                            return false; // if there's at least one empty space, the game is not tied
                        }
                    }
                }

                return true;
            }

            static async Task PlayerMove()
            {
                await BlazorConsole.Write("Enter row: ");
                int row = int.Parse(await BlazorConsole.ReadLine()!) - 1; // subtract 1 to account for zero-indexing
                await BlazorConsole.Write("Enter column: ");
                int col = int.Parse(await BlazorConsole.ReadLine()!) - 1; // subtract 1 to account for zero-indexing

                if (board[row, col] == '-')
                {
                    board[row, col] = 'X';
                }
                else
                {
                    await BlazorConsole.WriteLine("Invalid move. Try again.");
                    await PlayerMove(); // recursively call the method to prompt the player for another move
                }
            }

            static async Task AIMove()
            {
                Random random = new Random();
                int row, col;

                do
                {
                    row = random.Next(0, 3);
                    col = random.Next(0, 3);
                } while (board[row, col] != '-');

                board[row, col] = 'O';
                await BlazorConsole.WriteLine(string.Format("The creature placed an O at row {0}, column {1}", row, col));
            }
        }
        //===================================================================================================//
        public static void Puzzle3()
        {

        }

    }
}



