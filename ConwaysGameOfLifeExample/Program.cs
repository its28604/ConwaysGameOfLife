// See https://aka.ms/new-console-template for more information

int WIDTH = 200;
int HEIGHT = 200;

Grid grid = new Grid(WIDTH, HEIGHT);


Task.Run(() =>
{
    while (true)
    {
        grid.Generation();
        grid.Print();
        Task.Delay(1000);
    }
});
Console.ReadLine();

class Grid
{
    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        grid = new Cell[Width, Height];
    }

    public int Width { get; private set; }
    public int Height { get; private set; }

    private Cell[,] grid;

    public void Generation()
    {
        Cell[,] next = new Cell[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Cell cell = grid[x, y];

                if (cell.IsAlive)
                {
                    if (cell.Underpopulation() || cell.Overpopulation())
                        next[x, y].Dies();
                    else
                        next[x, y].Lives();
                }
                else
                {
                    if (cell.AbleToReproduction())
                        next[x, y].Lives();
                    else
                        next[x, y].Dies();
                }
            }
        }
    }

    internal void Print()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (grid[x, y].IsAlive)
                    Console.Write("■");
                else
                    Console.Write("□");
            }
            Console.WriteLine();
        }
    }
}

class Cell
{
    public bool IsAlive { get; private set; }
    public void Dies() => IsAlive = false;
    public void Lives() => IsAlive = true;

    internal bool AbleToReproduction()
    {
        Random random = new Random();

        return random.Next(0, 1) == 1 ? true : false;
    }

    internal bool Overpopulation()
    {
        Random random = new Random();

        return random.Next(0, 1) == 1 ? true : false;
    }

    internal bool Underpopulation()
    {
        Random random = new Random();

        return random.Next(0, 1) == 1 ? true : false;
    }
}
