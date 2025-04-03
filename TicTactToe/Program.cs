namespace TicTactToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.WelcomeMessage(); // Display the welcome message
            char[,] grid = new char[Constant.GRID_ROWS, Constant.GRID_COLUMNS];  // Create a grid for the game state
            Logic.InitializeGrid(grid);  // Initialize the grid with empty spaces

            while (true)  // Loop through until there's a win or game ends
            {
                UI.DisplayGrid(grid);  // Display the grid
                int playerMove = UI.GetPlayerMove();

                Logic.ApplyPlayerMove(grid, playerMove);  // Add the player's move to the grid
                if (Logic.CheckWin(grid, Logic.GetPlayerSymbol()))  // Check if the player won
                {
                    UI.DisplayGrid(grid);  // Display current grid state
                    UI.PlayersWinningNote();
                    break;
                }

                Logic.AIMove(grid);  // AI makes its move
                if (Logic.CheckWin(grid, Logic.GetAISymbol()))  // Check if AI won
                {
                    UI.DisplayGrid(grid);  // Display current grid state
                    UI.AIWinningNote();
                    break;
                }
            }
        }
    }
}
