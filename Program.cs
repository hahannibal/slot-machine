using System;

namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {

            int coins = 100;
            UI.WelcomeMessage();

            while (coins > 0)
            {
                UI.Current_Purse(coins);
                int gameMode = UI.GameModeSelect();
                coins = coins - gameMode;

                int[,] slotGrid = new int[3, 3];
                SlotGenerator(slotGrid);
                UI.GameGrid(slotGrid);

                int wonAmount = CheckWinningRow(gameMode, slotGrid);
                if (wonAmount > 0)
                    UI.DisplayWinningMessage(wonAmount);
                coins = coins + wonAmount;
                UI.Current_Purse(coins);
                UI.PlayAgain();

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
        static void SlotGenerator(int[,] TwoDArray)
        {
            Random number = new Random();
            for (int row = 0; row < TwoDArray.GetLength(0); row++)
            {
                for (int column = 0; column < TwoDArray.GetLength(1); column++)
                {
                    TwoDArray[row, column] = number.Next(0, 3);
                }
            }
        }
    }
}
