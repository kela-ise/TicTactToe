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
        // Constants for the grid size, empty cell, and move range
        public const int GRID_ROWS = 3;
        public const int GRID_COLUMNS = 3;
        public const char EMPTY_CELL = ' ';  // Empty cell
        public const int FIRST_ROW = 0;
        public const int FIRST_COL = 0;
        public const int SECOND_ROW = 1;
        public const int SECOND_COL = 1;
        public const int LAST_ROW = GRID_ROWS - 1;  // Index for the last row
        public const int LAST_COL = GRID_COLUMNS - 1;  // Index for the last column
        public const int INDEX_OFFSET = 1;  // Used to replace magic numbers in the code
        public const int MIN_PLAYERS_MOVE = 1;
        public const int MAX_PLAYERS_MOVE = 9;
        public const int DISPLAY_OFFSET = 1;
        public const int MOVE_INDEX_OFFSET = 1;
        public const int MIN_MOVE_FOR_WIN = 5;

        // Variables to store symbols X & O
        public static char playerSymbol;
        public static char aiSymbol;
        public static Random random = new Random();  // Random number generator for AI's move

        // Initialize the grid with empty spaces
        public static void InitializeGrid(char[,] grid)
        {
            for (int row = 0; row < GRID_ROWS; row++)
            {
                for (int col = 0; col < GRID_COLUMNS; col++)
                {
                    grid[row, col] = EMPTY_CELL;  // Set the cell to empty
                }
            }
        }

        // Initialize the player and AI symbols
        public static void InitializePlayers()
        {
            playerSymbol = 'X';
            aiSymbol = 'O';
        }

        // Return the player's symbol X
        public static char GetPlayerSymbol()
        {
            return playerSymbol;
        }

        // Return the AI's symbol O
        public static char GetAISymbol()
        {
            return aiSymbol;
        }

        // Place the player's move into the grid
        public static void ApplyPlayerMove(char[,] grid, int move)
        {
            int row = (move - MOVE_INDEX_OFFSET) / GRID_COLUMNS;
            int col = (move - MOVE_INDEX_OFFSET) % GRID_COLUMNS;

            if (grid[row, col] == EMPTY_CELL)
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
                rows = random.Next(FIRST_ROW, GRID_ROWS);
                cols = random.Next(FIRST_COL, GRID_COLUMNS);

                if (grid[rows, cols] == EMPTY_CELL)  // Check if the selected cell is empty
                {
                    Console.WriteLine($"AI placed '{aiSymbol}' at ({rows + DISPLAY_OFFSET}, {cols + DISPLAY_OFFSET})"); // Display where the move is placed
                    grid[rows, cols] = aiSymbol;
                    break;
                }
            }
        }

        // Check if there is a win for the given symbol (Player or AI)
        public static bool CheckWin(char[,] grid, char symbol)
        {
            // Ensure at least enough moves have been made before checking for a winner
            int movesMade = 0;
            foreach (var cell in grid)
            {
                if (cell != EMPTY_CELL)
                {
                    movesMade++;
                }
            }

            /*
              if (movesMade < MIN_PLAYERS_MOVE + INDEX_OFFSET)   // Check if there are enough moves made to form a winner (at least 5 moves for a win)
              {
                  return false; // No winner possible yet
              }

             */

            if (movesMade < MIN_MOVE_FOR_WIN)   // Check if there are enough moves made to form a winner (at least 5 moves for a win)
            {
                return false; // No winner possible yet
            }

            for (int row = 0; row < GRID_ROWS; row++)  // Check rows/horizontal win
            {
                if (grid[row, FIRST_COL] == symbol && grid[row, SECOND_COL] == symbol && grid[row, LAST_COL] == symbol)
                    return true; // Horizontal win
            }

          
            for (int col = 0; col < GRID_COLUMNS; col++)   // Check for columns/vertical win
            {
                if (grid[FIRST_ROW, col] == symbol && grid[SECOND_ROW, col] == symbol && grid[LAST_ROW, col] == symbol)
                    return true; // Vertical win
            }

            // Check diagonals for a win 
            if (grid[FIRST_ROW, FIRST_COL] == symbol && grid[SECOND_ROW, SECOND_COL] == symbol && grid[LAST_ROW, LAST_COL] == symbol)
                return true; // Top-left to bottom-right diagonal win

            if (grid[FIRST_ROW, LAST_COL] == symbol && grid[SECOND_ROW, SECOND_COL] == symbol && grid[LAST_ROW, FIRST_COL] == symbol)
                return true; // Top-right to bottom-left diagonal win

            return false; // No win found
        }
    }
}

