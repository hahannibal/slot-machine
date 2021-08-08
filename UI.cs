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
        /// What happens when there's a winning row/column
        /// </summary>
        public static void DisplayWinningMessage()
        {
            Console.WriteLine("You won a coin! Congrats!");
        }

        /// <summary>
        /// Writing out the current number of coins the player has.
        /// </summary>
        /// <param name="coins"></param>
        public static void Current_Purse(int coins)
        {
            Console.WriteLine($"You have {coins} coin currently!");
        }
    }
}
