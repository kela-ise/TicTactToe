using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTactToe
{
    internal class Logic
    {

        public Logic() {

            const int GRID_ROWS = 3;
            const int GRID_COLUMNS = 3;
            char[,] grid = new char[GRID_ROWS, GRID_COLUMNS];
            for (int rows = 0; rows < GRID_ROWS; rows++)  // Initialize the grid with empty spaces
            {
                for (int cols = 0; cols < GRID_COLUMNS; cols++)
                {
                    grid[rows, cols] = ' ';
                }

            }
        
}


    }
}
