using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTactToe
{
    public static class UI
    {
        // Display the welcome message
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");  
            Console.WriteLine($"NOTE: You'll be playing as 'X', and the AI will be 'O'.\n");  
        }

        public static void PlayersWinningNote()
        {
            Console.WriteLine("Congratulations! You Won");  
        }
        public static void AIWinningNote()
        {
            Console.WriteLine("Sorry you lost! AI Won");  
        }

        public static void DisplayGrid(char[,] grid) // Display the current state of the grid
        {
            Console.WriteLine("Current Board:"); 
            int cellNumber = 1;  // To track the cell #
            int lastRow = Logic.GRID_ROWS - 1;  
            int lastColumn = Logic.GRID_COLUMNS - 1;  

            for (int row = 0; row < Logic.GRID_ROWS; row++)
            {
                for (int col = 0; col < Logic.GRID_COLUMNS; col++)
                {
                    if (grid[row, col] == Logic.EMPTY_CELL)  // If the cell is empty, display the # assigned to the cell
                    {
                        Console.Write($" {cellNumber} ");
                    }
                    else  // If the cell is filled, display the symbol ('X' or 'O')
                    {
                        Console.Write($" {grid[row, col]} ");
                    }

                    if (col < lastColumn) 
                        Console.Write("|"); // Print a vertical separator "|" between columns, but not after the last column

                    cellNumber++;  
                }
                Console.WriteLine(); 
                if (row < lastRow)  
                    Console.WriteLine("---+---+---"); // Print a horizontal separator "---+---+---" between rows, but not after the last row
            }
        }
    }
}

