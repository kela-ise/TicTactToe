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

        // Initialize the grid with empty spaces
        public static void InitializeGrid(char[,] grid)
        {
            for (int row = 0; row < Constant.GRID_ROWS; row++)
            {
                for (int col = 0; col < Constant.GRID_COLUMNS; col++)
                {
                    grid[row, col] = Constant.EMPTY_CELL;  // Set the cell to empty
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

        // Check if there is a win for the given symbol (Player or AI)
        public static bool CheckWin(char[,] grid, char symbol)
        {
            // Ensure at least enough moves have been made before checking for a winner
            int movesMade = 0;
            foreach (var cell in grid)
            {
                if (cell != Constant.EMPTY_CELL)
                {
                    movesMade++;
                }
            }


            if (movesMade < Constant.MIN_MOVE_FOR_WIN)   // Check if there are enough moves made to form a winner (at least 5 moves for a win)
            {
                return false; // No winner possible yet
            }

            for (int row = 0; row < Constant.GRID_ROWS; row++)  // Check rows/horizontal win
            {
                if (grid[row, Constant.FIRST_COL] == symbol && grid[row, Constant.SECOND_COL] == symbol && grid[row, Constant.LAST_COL] == symbol)
                    return true; // Horizontal win
            }

          
            for (int col = 0; col < Constant.GRID_COLUMNS; col++)   // Check for columns/vertical win
            {
                if (grid[Constant.FIRST_ROW, col] == symbol && grid[Constant.SECOND_ROW, col] == symbol && grid[Constant.LAST_ROW, col] == symbol)
                    return true; // Vertical win
            }

            // Check diagonals for a win 
            if (grid[Constant.FIRST_ROW, Constant.FIRST_COL] == symbol && grid[Constant.SECOND_ROW, Constant.SECOND_COL] == symbol && grid[Constant.LAST_ROW, Constant.LAST_COL] == symbol)
                return true; // Top-left to bottom-right diagonal win

            if (grid[Constant.FIRST_ROW, Constant.LAST_COL] == symbol && grid[Constant.SECOND_ROW, Constant.SECOND_COL] == symbol && grid[Constant.LAST_ROW, Constant.FIRST_COL] == symbol)
                return true; // Top-right to bottom-left diagonal win

            return false; // No win found
        }
    }
}

