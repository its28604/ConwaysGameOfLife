// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int WIDTH = 200;
int HEIGHT = 200;

Cell[,] grid = new Cell[WIDTH, HEIGHT];
Cell[,] next = new Cell[WIDTH, HEIGHT];

for (int x = 0; x < WIDTH; x++)
{
    for (int y = 0; y < HEIGHT; y++)
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


class Cell
{
    public bool IsAlive { get; private set; }
    public void Dies() => IsAlive = false;
    public void Lives() => IsAlive = true;

    internal bool AbleToReproduction()
    {
        throw new NotImplementedException();
    }

    internal bool Overpopulation()
    {
        throw new NotImplementedException();
    }

    internal bool Underpopulation()
    {
        throw new NotImplementedException();
    }
}
