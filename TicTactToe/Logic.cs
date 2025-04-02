using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;




namespace TicTactToe
{
    public static class Logic
    {
        // Variables to store symbols X & O
        public static char playerSymbol;
        public static char aiSymbol;
        public static Random random = new Random();  // Random number generator for AI's move

        public static void InitializeGrid(char[,] grid)  // Initialize the grid with empty spaces
        {
            for (int row = 0; row < Constant.GRID_ROWS; row++)
            {
                for (int col = 0; col < Constant.GRID_COLUMNS; col++)
                {
                    grid[row, col] = Constant.EMPTY_CELL;  // Set the cell to empty
                }
            }
        }

        public static void InitializePlayers()  // Initialize the player and AI symbols
        {
            playerSymbol = 'X';
            aiSymbol = 'O';
        }
        public static char GetPlayerSymbol()  // Return the player's symbol X
        {
            return playerSymbol;
        }
        public static char GetAISymbol()  // Return the AI's symbol O
        {
            return aiSymbol;
        }

        public static void ApplyPlayerMove(char[,] grid, int move)   // Place the player's move into the grid
        {
            int row = (move - Constant.MOVE_INDEX_OFFSET) / Constant.GRID_COLUMNS;
            int col = (move - Constant.MOVE_INDEX_OFFSET) % Constant.GRID_COLUMNS;

            if (grid[row, col] == Constant.EMPTY_CELL)
            {
                grid[row, col] = playerSymbol; // Place the player's symbol in the selected cell
            }
        }
        // AI's move - randomly selects an empty cell to place its symbol
        public static void AIMove(char[,] grid)
        {
            int rows, cols;
            while (true)  // Loop until the AI selects an empty cell
            {
                rows = random.Next(Constant.FIRST_ROW, Constant.GRID_ROWS);
                cols = random.Next(Constant.FIRST_COL, Constant.GRID_COLUMNS);

                if (grid[rows, cols] == Constant.EMPTY_CELL)  // Check if the selected cell is empty
                {
                    Console.WriteLine($"AI placed '{aiSymbol}' at ({rows + Constant.DISPLAY_OFFSET}, {cols + Constant.DISPLAY_OFFSET})"); // Display where the move is placed
                    grid[rows, cols] = aiSymbol;
                    break;
                }
            }
        }
        public static bool CheckWin(char[,] grid, char symbol)   // Check if there is a win for X/O (Player/AI)
        {
            
            int movesMade = 0;
            foreach (char cell in grid) // Ensure at least enough moves have been made before checking for a winner
            {
                if (cell != Constant.EMPTY_CELL)
                {
                    movesMade++;
                }
            }

            if (movesMade < Constant.MIN_MOVE_FOR_WIN)   // Check if we have at least 5 moves to declare a win
            {
                return false; // No winner possible yet
            }

            return CheckHorizontalWins(grid, symbol) || CheckVerticalWins(grid, symbol) || CheckDiagonalWins(grid, symbol);
        }
        public static bool CheckHorizontalWins(char[,] grid, char symbol)
        {
            for (int row = 0; row < Constant.GRID_ROWS; row++)  // Check rows/horizontal win
            {
                if (grid[row, Constant.FIRST_COL] == symbol &&
                    grid[row, Constant.SECOND_COL] == symbol &&
                    grid[row, Constant.LAST_COL] == symbol)
                {
                    return true; // Horizontal win
                }
            }
            return false;
        }
        public static bool CheckVerticalWins(char[,] grid, char symbol)// Check for columns/vertical win
        {
            for (int col = 0; col < Constant.GRID_COLUMNS; col++)   
            {
                if (grid[Constant.FIRST_ROW, col] == symbol &&
                    grid[Constant.SECOND_ROW, col] == symbol &&
                    grid[Constant.LAST_ROW, col] == symbol)
                {
                    return true; // Vertical win
                }
            }
            return false;
        }

        public static bool CheckDiagonalWins(char[,] grid, char symbol)
        {
            if (grid[Constant.FIRST_ROW, Constant.FIRST_COL] == symbol &&
                grid[Constant.SECOND_ROW, Constant.SECOND_COL] == symbol &&
                grid[Constant.LAST_ROW, Constant.LAST_COL] == symbol)
            {
                return true; // Top-left to bottom-right diagonal win
            }

            if (grid[Constant.FIRST_ROW, Constant.LAST_COL] == symbol &&
                grid[Constant.SECOND_ROW, Constant.SECOND_COL] == symbol &&
                grid[Constant.LAST_ROW, Constant.FIRST_COL] == symbol)
            {
                return true; // Top-right to bottom-left diagonal win
            }

            return false;
        }
    }
}
