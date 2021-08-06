using System;

namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Random number = new Random();
            int[,] slotNumbers = new int[3, 3];
            int coins = 100;
            Console.WriteLine($"Hello! This is a slotmachine game. Let's go!");


            while (coins > 0)
            {
                int bet = Bet_Select();
                Current_Purse(coins);
                coins = coins -bet;
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

                coins = coins + Check_Winning_Row(bet, slotNumbers);

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
        static void Winning()
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
        /// <param name="bet"></param>
        /// <param name="slotNumber"></param>
        /// <returns></returns>
        static int Check_Winning_Row(int bet, int[,] slotNumber)
        {
            if (bet == 1)
            {
                if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2])
                {
                    Winning();
                    return 1;
                }
            }

            //issue: it checks all rows, but only give 1 coin, even if multiple rows won
            if (bet == 3)
            {
                for (int i = 0; i < slotNumber.GetLength(0); i++)
                {
                    if (slotNumber[i, 0] == slotNumber[i, 1] && slotNumber[i, 1] == slotNumber[i, 2])
                    {
                        Winning();
                        return 1;
                    }
                }
            }
            return 0;

        }
        /// <summary>
        /// bet selection for multiple row play
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        static int Bet_Select()
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
