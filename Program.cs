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
            Console.WriteLine($"Hello! This is a slotmachine game. Let's go!");


            while (coins > 0)
            {
                //coins--;
                Current_Purse(coins);
                Bet_Select(coins);
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

                Check_Winning_Row(1, slotNumbers, coins);
       
                //checking the rows and columns for a match
                //for (int i = 0; i < slotNumbers.GetLength(0); i++)
                //{
                //    if (slotNumbers[i, 0] == slotNumbers[i, 1] && slotNumbers[i, 1] == slotNumbers[i, 2])
                //    {
                //        Winning();
                //        coins++;
                //    }
                //    if (slotNumbers[0, i] == slotNumbers[1, i] && slotNumbers[1, i] == slotNumbers[2, i])
                //    {
                //        Winning();
                //        coins++;
                //    }
                //}

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

        static void Check_Winning_Row(int bet, int[,] slotNumber, int coin)
        {
            if (bet == 1)
            {
                coin--;
                if (slotNumber[1,0] == slotNumber[1,1] && slotNumber[1,0] == slotNumber[1, 2])
                {
                    Winning();
                    Win_A_Coin(coin);
                }
            }
        }
        static int Win_A_Coin(int coin)
        {
            return coin+100;
        }
        /// <summary>
        /// bet selection for multiple row play
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        static int Bet_Select(int coin)
        {
            Console.WriteLine("What's your bet? 1 or 3 lane?");
            int bet = Convert.ToInt32(Console.ReadLine());
            if (bet == 1)
            {
                return coin--;
            }
            if (bet == 3)
            {
                return coin - 3;
            }
            else
            {
                Console.WriteLine("As you couldn't answer the question, you will play only the middle row for 2 coins, hah!");
                return coin - 2;
            }
        }
    }
}
