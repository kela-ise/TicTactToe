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
       
        public const int GRID_ROWS = 3;  
        public const int GRID_COLUMNS = 3; 
        public const char EMPTY_CELL = ' ';  // Empty cell
        public const int FIRST_ROW = 0;  
        public const int FIRST_COL = 0; 
        public const int SECOND_ROW = 1;  
        public const int SECOND_COL = 1;  
        public const int LAST_ROW = GRID_ROWS - 1;  // Index for the last row
        public const int LAST_COL = GRID_COLUMNS - 1;  // Index for the last column
        public const int INDEX_OFFSET = 1;  
        public const int MIN_PLAYERS_MOVE = 1;  
        public const int MAX_PLAYERS_MOVE = 9;  
        public const int DISPLAY_OFFSET = 1;  
        public const int MOVE_INDEX_OFFSET = 1; 

        // Variables to store symbols X & O
        public static char playerSymbol;
        public static char aiSymbol;
        public static Random random = new Random();  // Random number generator for AI's move

        public static void InitializeGrid(char[,] grid) // Initialize the grid with empty spaces
        {
            for (int row = 0; row < GRID_ROWS; row++)  
            {
                for (int col = 0; col < GRID_COLUMNS; col++)  
                {
                    grid[row, col] = EMPTY_CELL;  // Set the cell to empty
                }
            }
        }

        public static void InitializePlayers()  // Initialize the player and AI symbols
        {
            playerSymbol = 'X';  
            aiSymbol = 'O';  
        }

        
        public static char GetPlayerSymbol() // Return the player's symbol X
        {
            return playerSymbol;
        }

        public static char GetAISymbol()         
        {
            return aiSymbol;  
        }

        public static void PlayerMove(char[,] grid)
        {
            int move; 
            while (true)  
            {
                Console.Write("Enter the number of the cell (1-9) where you want to place your move: ");
                string input = Console.ReadLine(); 

               
                if (int.TryParse(input, out move) && move >= MIN_PLAYERS_MOVE && move <= MAX_PLAYERS_MOVE)  // Validate player's input, numbers btw 1-9
                {
                    int row = (move - MOVE_INDEX_OFFSET) / GRID_COLUMNS;  
                    int col = (move - MOVE_INDEX_OFFSET) % GRID_COLUMNS;  
                    if (grid[row, col] == EMPTY_CELL)  // Check if the cell is empty
                    {
                        grid[row, col] = playerSymbol;  // Place the player's symbol in the selected cell
                        break;  // Exit the loop after a valid move
                    }
                }

                Console.WriteLine("Invalid move! Try again."); 
            }
        }

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
        public static bool CheckWin(char[,] grid, char symbol) // check for a win
        {
            bool checkWin = false;  

           
            for (int row = 0; row < GRID_ROWS; row++)  // Check for row and column wins
            {
                if (grid[row, FIRST_COL] == symbol && grid[row, SECOND_COL] == symbol && grid[row, LAST_COL] == symbol)  // Row win
                    return true;  // Return true if all cells in the row match
                if (grid[FIRST_ROW, row] == symbol && grid[SECOND_ROW, row] == symbol && grid[LAST_ROW, row] == symbol)  // Column win
                    return true;  // Return true if all cells in the column match
            }

            bool diagonalMatch1 = true;  
            bool diagonalMatch2 = true;  
            for (int i = 1; i < GRID_ROWS; i++)  // Iterate through diagonal positions to check win
            {
                if (grid[i, i] != grid[FIRST_ROW, FIRST_COL])  // Compare first diagonal
                    diagonalMatch1 = false;
                if (grid[i, GRID_COLUMNS - i - MOVE_INDEX_OFFSET] != grid[FIRST_ROW, LAST_COL])  // Compare second diagonal
                    diagonalMatch2 = false;
            }

            checkWin = diagonalMatch1 || diagonalMatch2;
            return checkWin;
        }
    }
}
