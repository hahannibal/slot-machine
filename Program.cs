using System;

namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Random number = new Random();
            int[,] slotNumbers = new int[3, 3];
            int coins = 10;
            Console.WriteLine("Hello! This is a slotmachine game. Let's go!");


            while (coins > 0)
            {
                int gameMode = GameModeSelect();
                Current_Purse(coins);
                coins = coins - gameMode;
                for (int row = 0; row < slotNumbers.GetLength(0); row++)
                {
                    for (int column = 0; column < slotNumbers.GetLength(1); column++)
                    {
                        slotNumbers[row, column] = number.Next(0, 3);
                    }

                }

                for (int row = 0; row < slotNumbers.GetLength(0); row++)
                {
                    for (int column = 0; column < slotNumbers.GetLength(1); column++)
                    {
                        Console.Write($" {slotNumbers[row, column]} ");
                    }
                    Console.WriteLine();

                }
                int wonAmount = CheckWinningRow(gameMode, slotNumbers);

                if (wonAmount > 0)
                    DisplayWinningMessage();

                coins = coins + wonAmount;

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
                    Environment.Exit(1);
                }
            }
            Console.WriteLine("You have no coins left :( Good bye!");
            Environment.Exit(1);
        }
        /// <summary>
        /// What happens when there's a winning row/column
        /// </summary>
        static void DisplayWinningMessage()
        {
            Console.WriteLine("You won a coin! Congrats!");
        }
        /// <summary>
        /// Writing out the current number of coins the player has.
        /// </summary>
        /// <param name="coins"></param>

        static void Current_Purse(int coins)
        {
            Console.WriteLine($"You have {coins} coin currently!");
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
                    DisplayWinningMessage();
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
                        DisplayWinningMessage();
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
