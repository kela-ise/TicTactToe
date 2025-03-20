namespace TicTactToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            UI.welcomeMessage();
            const int GRID_ROWS = 3;
            const int GRID_COLUMNS = 3;
            char[,] grid = new char[GRID_ROWS, GRID_COLUMNS];


            UI.displayGrid(grid); // Display the grid
        }
    }
}
