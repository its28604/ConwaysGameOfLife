// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int WIDTH = 200;
int HEIGHT = 200;

bool[,] grid = new bool[WIDTH, HEIGHT];
bool[,] next = new bool[WIDTH, HEIGHT];


for (int x = 0; x < WIDTH; x++)
{
    for (int y = 0; y < HEIGHT; y++)
    {
        Cell cell = grid[x, y];
        int alive_count = 0;
        if (x - 1 > 0 && y - 1 > 0 && grid[x - 1, y - 1])           // Left-Top
            alive_count++;
        if (x - 1 > 0 && grid[x - 1, y])                            // Left
            alive_count++;
        if (x - 1 > 0 && y + 1 < HEIGHT && grid[x - 1, y + 1])      // Left-Bottom
            alive_count++;
        if (y - 1 > 0 && grid[x, y - 1])                            // Top
            alive_count++;
        if (y + 1 < HEIGHT && grid[x, y + 1])                       // Bottom
            alive_count++;
        if (x + 1 < WIDTH && y - 1 > 0 && grid[x + 1, y - 1])       // Right-Top
            alive_count++;
        if (x + 1 < WIDTH && grid[x + 1, y])                        // Right
            alive_count++;
        if (x + 1 < WIDTH && y + 1 < HEIGHT && grid[x + 1, y + 1])  // Right-Bottom
            alive_count++;

        if (grid[x, y])
        {
            if (alive_count < 2)          // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                next[x, y] = false;
            else if (alive_count > 3)     // Any live cell with more than three live neighbours dies, as if by overpopulation.
                next[x, y] = false;
            else                          // Any live cell with two or three live neighbours lives on to the next generation.
                next[x, y] = true;
        }
        else
        {
            if (alive_count == 3)         // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                next[x, y] = true;
            else
                next[x, y] = false;
        }
    }
}

PrintGrid();