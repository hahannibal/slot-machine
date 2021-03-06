using System;
using System.Collections.Generic;
using System.Linq;

namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.WelcomeMessage();
            int coins = UI.StartingMoney();
            int gridLength = UI.ChoseGridLength();
            GameMode gameMode = UI.GameModeSelect();
            int gameCost = GetGameCost(gameMode);

            while (coins > 0)
            {
                UI.Current_Purse(coins);


                coins = coins - gameCost;
                
                int[,] slotGrid = SlotNumberGenerator(gridLength,gridLength);
                UI.DisplayGameGrid(slotGrid);

                int wonAmount = CheckWinningRow(gameMode, slotGrid, gridLength);
                if (wonAmount > 0)
                    UI.DisplayWinningMessage(wonAmount);
                coins = coins + wonAmount;
                UI.Current_Purse(coins);
                GameEndQuestion answer = UI.AskToPlayAgain();
                if (answer == GameEndQuestion.Exit)
                {
                    Environment.Exit(0);
                }
                if (answer == GameEndQuestion.ChangeGameMode)
                {
                    gameMode = UI.GameModeSelect();
                    gameCost = GetGameCost(gameMode);
                }
                if(coins < 3)
                {
                    UI.LowOnCoins();
                    gameMode = GameMode.SingleRow;
                    gameCost = GetGameCost(gameMode);
                }

            }

            UI.NoCoinsLeft();
        }

        /// <summary>
        /// Checking the rows for winning numbers
        /// </summary>
        /// <param name="gameMode">selected GameMode</param>
        /// <param name="gameGrid">2D array of random numbers</param>
        /// <param name="multiplier">A number that changes the won amount</param>
        /// <returns>Returns the amount won</returns>
        static int CheckWinningRow(GameMode gameMode, int[,] gameGrid, int multiplier)
        {
            switch (gameMode)
            {
                case GameMode.SingleRow:
                case GameMode.Default:
                    bool didYouWin = GetRowAndDistinctValues(gameGrid, gameGrid.GetLength(0)/2); //gameGrid.GetLength/2 => approx. middle row
                    if (didYouWin)
                    {
                        return 2*multiplier;
                    }
                    return 0;
                case GameMode.TripleRow:
                    int winning = 0;
                    for (int i = 0; i < gameGrid.GetLength(0); i++)
                    {
                        bool didYouWinMultiRow = GetRowAndDistinctValues(gameGrid, i);
                        if (didYouWinMultiRow)
                        {
                            winning = winning + 2 * multiplier;
                        }

                    }
                    return winning;
                default:
                    return 0;

            }
        }
        /// <summary>
        /// Generating and filling up a 2D Array with random numbers
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

        /// <summary>
        /// Determining the cost of the round by the selected GameMode
        /// </summary>
        /// <param name="gameMode">selected GameMode</param>
        /// <returns>The cost of the round</returns>
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
        /// <summary>
        /// turning the 2D array's row into a list and checking for distinct values. 
        /// </summary>
        /// <param name="TwoDArray">2D array that has to be turned into lists for checking</param>
        /// <param name="rowNumber">Which row should be checked</param>
        /// <returns>If 1 distinct value in a row = true, otherwise false</returns>
        static bool GetRowAndDistinctValues(int[,] TwoDArray, int rowNumber)
        {
            var row = new List<int>();
            for (int i = 0; i < TwoDArray.GetLength(1); i++)
            {
                row.Add(TwoDArray[rowNumber, i]);
            }
            if(row.Distinct().Count() == 1)
            {
                return true;
            }
            return false;
        }
    }
}
