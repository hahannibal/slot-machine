using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slot_machine
{
    static class UI
    {
        /// <summary>
        /// Welcome message written out on the beginning of the game
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine("Hello there! This is a slot machine game! Let's play!");
        }

        /// <summary>
        /// Message written out when there's 1 or multpile winning rows
        /// </summary>
        /// <param name="wonAmount">The amount of coins won with the winning rows</param>
        public static void DisplayWinningMessage(int wonAmount)
        {
            if (wonAmount == 1)
            {
                Console.WriteLine("You won a coin! Congrats!");
            }
            else
            {
                Console.WriteLine($"You won {wonAmount} coins, wow!");
            }
        }

        /// <summary>
        /// Writing out the current number of coins the player has.
        /// </summary>
        /// <param name="coins">number of coins owned by the player currently</param>
        public static void Current_Purse(int coins)
        {
            Console.WriteLine($"You have {coins} coin currently!");
        }
        /// <summary>
        /// Visualization of the slot game grid
        /// </summary>
        /// <param name="gridOfNumbers">2d array of numbers</param>
        public static void DisplayGameGrid(int[,] gridOfNumbers)
        {
            for (int row = 0; row < gridOfNumbers.GetLength(0); row++)
            {
                for (int column = 0; column < gridOfNumbers.GetLength(1); column++)
                {
                    Console.Write($" {gridOfNumbers[row, column]} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// bet selection for multiple row play
        /// </summary>
        /// <param name="coin"></param>
        /// <returns>Returns the selected game mode</returns>
        public static GameMode GameModeSelect()
        {
            Console.WriteLine("What's your bet? 1 or 3 rows?");
            string bet = (Console.ReadLine());
            switch (bet)
            {
                case "1":
                    return GameMode.SingleRow;
                case "3":
                    return GameMode.TripleRow;
                default:
                    Console.WriteLine("As you couldn't answer the question, you will play only the middle row for 2 coins, hah!");
                    return GameMode.Default;
            }
        }

        /// <summary>
        /// Asking the player if he wants to play again
        /// </summary>
        public static Boolean AskToPlayAgain()
        {
            Console.WriteLine("Push the Spacebar to play again!");
            ConsoleKeyInfo answer = Console.ReadKey();
            
            if (answer.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.Write("Good bye!");
                return false;
            }
        }

        /// <summary>
        /// message written out when the user runs out of money
        /// </summary>

        public static void NoCoinsLeft()
        {
            Console.WriteLine("You're all out of money, Honey!");
        }
    }
}
