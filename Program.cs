﻿using System;

namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Random number = new Random();
            int[,] slotNumbers = new int[3, 3];
            int coins = 10;
            Console.WriteLine("Hello! This is a slotmachine game. You have" + coins + " coins to play with! Let's see the first try!");



            while (coins > 0)
            {
                coins--;
                Console.WriteLine("You have " + coins + " coins left!");
                for (int row = 0; row < 3; row++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        slotNumbers[row, column] = number.Next(0, 3);
                    }

                }

                for (int row = 0; row < 3; row++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        Console.Write("{0} ", slotNumbers[row, column]);
                    }
                    Console.WriteLine();

                }

       
                //checking the rows and columns for a match
                for (int i = 0; i < slotNumbers.GetLength(0); i++)
                {
                    if (slotNumbers[i, 0] == slotNumbers[i, 1] && slotNumbers[i, 1] == slotNumbers[i, 2])
                    {
                        Winning();
                        coins++;
                    }
                    if (slotNumbers[0, i] == slotNumbers[1, i] && slotNumbers[1, i] == slotNumbers[2, i])
                    {
                        Winning();
                        coins++;
                    }
                }

                Console.WriteLine("Do you wanna play again?(y/n)");

                string answer = Console.ReadLine();

                if (answer == "y")
                {
                    Console.WriteLine("You have " + coins + " coins left");
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

        static void Winning()
        {
            Console.WriteLine("You won a coin!");
        }

    }
}
