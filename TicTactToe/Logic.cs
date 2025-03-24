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
        // Define the grid size constants here so they can be used anywhere
        public const int GRID_ROWS = 3;
        public const int GRID_COLUMNS = 3;
        public static void InitializeGrid(char[,] grid)
        {

        //char[,] grid = new char[GRID_ROWS, GRID_COLUMNS];
           for (int rows = 0; rows<GRID_ROWS; rows++)  // Initialize the grid with empty spaces
            {
                for (int cols = 0; cols<GRID_COLUMNS; cols++)
                {
                    grid[rows, cols] = ' ';
                }
        
        }
        
}








    }
}
