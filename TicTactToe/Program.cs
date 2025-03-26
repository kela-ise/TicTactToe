namespace TicTactToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.WelcomeMessage(); 
            char[,] grid = new char[Logic.GRID_ROWS, Logic.GRID_COLUMNS];  // Create a grid for the game state
            Logic.InitializeGrid(grid);  // Initialize the grid with empty spaces

            Logic.InitializePlayers(); // Initialize my players. player:X & AI:O)

            while (true)  // Loop through till theres a win or game ends
            {
                UI.DisplayGrid(grid);  // Display the grid


                Logic.PlayerMove(grid);  
                if (Logic.CheckWin(grid, Logic.GetPlayerSymbol()))  // Check if the player won
                {
                    UI.DisplayGrid(grid);  // Display current grid state
                    UI.PlayersWinningNote(); 
                    break;  
                }

              
                Logic.AIMove(grid);  
                if (Logic.CheckWin(grid, Logic.GetAISymbol()))  
                {
                    UI.DisplayGrid(grid); 
                    UI.AIWinningNote();  
                    break;  
                }
            }
        }
    }
}
