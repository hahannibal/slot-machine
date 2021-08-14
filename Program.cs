﻿using System;

namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            int coins = 100;
            UI.WelcomeMessage();
            GameMode gameMode = UI.GameModeSelect();
            int gameCost = GetGameCost(gameMode);

            while (coins > 0)
            {
                UI.Current_Purse(coins);


                coins = coins - gameCost;

                int[,] slotGrid = SlotNumberGenerator(3,3);
                UI.DisplayGameGrid(slotGrid);

                int wonAmount = CheckWinningRow(gameCost, slotGrid);
                if (wonAmount > 0)
                    UI.DisplayWinningMessage(wonAmount);
                coins = coins + wonAmount;
                UI.Current_Purse(coins);
                bool answer = UI.AskToPlayAgain();
                if (answer == false)
                {
                    Environment.Exit(0);
                }

            }
            UI.NoCoinsLeft();
        }

        /// <summary>
        /// checking the rows for winning numbers
        /// </summary>
        /// <param name="gameMode">1: Middle Row 3:all 3 rows</param>
        /// <param name="gameGrid">2d array to check</param>
        /// <returns>amount won</returns>
        static int CheckWinningRow(int gameMode, int[,] gameGrid)
        {

            if (gameMode != 3)
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
        /// Generating and filling up a 2D Array with
        /// </summary>
        /// <param name="width">2D Array width</param>
        /// <param name="length">2D Array length</param>
        /// <returns>returns the random numbers of the 2D array</returns>
        static int[,] SlotNumberGenerator(int width, int length)
        {
            int[,] TwoDArray = new int[width, length];
            Random number = new Random();
            for (int row = 0; row < TwoDArray.GetLength(0); row++)
            {
                for (int column = 0; column < TwoDArray.GetLength(1); column++)
                {
                    TwoDArray[row, column] = number.Next(0, 3);
                }
            }
            return TwoDArray;
        }
        static int GetGameCost(GameMode gameMode)
        {
            switch (gameMode)
            {
                case GameMode.SingleRow:
                    return 1;
                case GameMode.TripleRow:
                    return 3;
                case GameMode.Diagonal:
                case GameMode.Default:
                    return 2;
                default:
                    throw new NotImplementedException();
             }
        }
    }
}
