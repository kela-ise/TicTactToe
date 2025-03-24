namespace TicTactToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            UI.welcomeMessage();
            char[,] grid = new char[Logic.GRID_ROWS, Logic.GRID_COLUMNS];
            UI.displayGrid(grid); // Display the grid
        }
    }
}
