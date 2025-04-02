using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTactToe
{
  public static class Constant
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
    }
}
