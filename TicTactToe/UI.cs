using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTactToe
{
    public static class UI
    {

        public static void welcomeMessage()
        {
            Console.WriteLine("Tic Tac Toe Game");
        }

        public static void displayGrid(char[,] grid)
        {

            Console.Clear();
            const int GRID_ROWS = 3;
            const int GRID_COLUMNS = 3;
            int lastRow = 2;
            int lastColumn = 2;
            for (int rows = 0; rows < GRID_ROWS; rows++)
            {
                for (int cols = 0; cols < GRID_COLUMNS; cols++)
                {
                    Console.Write($" {grid[rows, cols]} ");
                    if (cols < lastColumn) Console.Write("|");  // Print a vertical separator "|" between columns, but not after the last column
                }
                Console.WriteLine();
                if (rows < lastRow) Console.WriteLine("---+---+---");  // Print a horizontal separator "---+---+---" between rows, but not after the last row


            }

        }
    }
}
