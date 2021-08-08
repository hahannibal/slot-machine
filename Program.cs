﻿using System;

namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Random number = new Random();
            int[,] slotGrid = new int[3, 3];
            int coins = 100;
            UI.WelcomeMessage();

            while (coins > 0)
            {
                UI.Current_Purse(coins);
                int gameMode = GameModeSelect();
                coins = coins - gameMode;
                for (int row = 0; row < slotGrid.GetLength(0); row++)
                {
                    for (int column = 0; column < slotGrid.GetLength(1); column++)
                    {
                        slotGrid[row, column] = number.Next(0, 3);
                    }
                }
                UI.GameGrid(slotGrid);

                int wonAmount = CheckWinningRow(gameMode, slotGrid);
                if (wonAmount > 0)
                    UI.DisplayWinningMessage(wonAmount);
                coins = coins + wonAmount;
                UI.Current_Purse(coins);
                
                Console.WriteLine("Do you wanna play again?(y/n)");
                string answer = Console.ReadLine();

                if (answer == "y")
                {
                    Console.WriteLine($"You have {coins} coins left");
                    Console.Clear();
                }
                else
                {
                    Console.Write("Good bye!");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("You have no coins left :( Good bye!");
            Environment.Exit(0);
        }

        /// <summary>
        /// checking the rows for winning numbers
        /// </summary>
        /// <param name="gameMode">1: Middle Row 3:all 3 rows</param>
        /// <param name="gameGrid">2d array to check</param>
        /// <returns>amount won</returns>
        static int CheckWinningRow(int gameMode, int[,] gameGrid)
        {

            if (gameMode == 1)
            {
                if (gameGrid[1, 0] == gameGrid[1, 1] && gameGrid[1, 0] == gameGrid[1, 2])
                {
                    return 2;
                }
            }

            if (gameMode == 3)
            {
                int winning = 0;
                for (int i = 0; i < gameGrid.GetLength(0); i++)
                {
                    if (gameGrid[i, 0] == gameGrid[i, 1] && gameGrid[i, 1] == gameGrid[i, 2])
                    {
                        winning = winning + 2;
                    }

                }
                return winning;
            }

            return 0;

        }
        /// <summary>
        /// bet selection for multiple row play
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        static int GameModeSelect()
        {
            Console.WriteLine("What's your bet? 1 or 3 lane?");
            int bet = Convert.ToInt32(Console.ReadLine());
            if (bet == 1)
            {
                return 1;
            }
            if (bet == 3)
            {
                return 3;
            }
            else
            {
                Console.WriteLine("As you couldn't answer the question, you will play only the middle row for 2 coins, hah!");
                return 2;
            }
        }
    }
}
