// See https://aka.ms/new-console-template for more information
public class Grid
{
    private readonly Cell[,] m_grid;
    private readonly ICanvas m_canvas;

    public Grid(int width, int height, ICanvas canvas)
    {
        m_grid = new Cell[width, height];
        m_canvas = canvas;
        m_canvas.Init(width, height);

        InitGrid();
        AssignNeibours();
    }

    public Cell this[int x, int y]
    {
        get
        {
            int width = m_grid.GetLength(0);
            int height = m_grid.GetLength(1);
            int pos_x = x, pos_y = y;
            if (x < 0)
                pos_x = width + x;
            if (x >= width)
                pos_x = x - width;
            if (y < 0)
                pos_y = height + y;
            if (y >= height)
                pos_y = y - height;
            return m_grid[pos_x, pos_y];
        }
    }

    public void Process()
    {
        foreach (var cell in m_grid)
        {
            if (cell.IsAlive)
            {
                if (cell.Underpopulation() || cell.Overpopulation())
                    cell.Dies();
                else
                    cell.Lives();
            }
            else
            {
                if (cell.AbleToReproduction())
                    cell.Lives();
                else
                    cell.Dies();
            }
        }
    }

    public void Generate()
    {
        for (int x = 0; x < m_grid.GetLength(0); x++)
        {
            for (int y = 0; y < m_grid.GetLength(1); y++)
            {
                Cell cell = m_grid[x, y];
                if (cell.Generate())
                {
                    if (cell.IsAlive)
                        m_canvas.Fill(x, y);
                    else
                        m_canvas.Empty(x, y);
                }
            }
        }
    }

    private void AssignNeibours()
    {
        for (int x = 0; x < m_grid.GetLength(0); x++)
            for (int y = 0; y < m_grid.GetLength(1); y++)
                m_grid[x, y].AssignNeibours(
                    this[x - 1, y - 1],     // Left-Top
                    this[x - 1, y],         // Left-Medium
                    this[x - 1, y + 1],     // Left-Bottom
                    this[x, y - 1],         // Medium-Top
                    this[x, y + 1],         // Medium-Bottom
                    this[x + 1, y - 1],     // Right-Top
                    this[x + 1, y],         // Right-Medium
                    this[x + 1, y + 1]);    // Right-Bottom
    }

    private bool GetCellInitState(int x, int y)
    {
        Random random = new Random();
        return random.Next(0, 2) == 1;
    }

    private void InitGrid()
    {
        for (int x = 0; x < m_grid.GetLength(0); x++)
        {
            for (int y = 0; y < m_grid.GetLength(1); y++)
            {
                if (GetCellInitState(x, y))
                {
                    Cell cell = new Cell();
                    cell.Lives();
                    cell.Generate();
                    m_grid[x, y] = cell;
                    m_canvas.Fill(x, y);
                }
                else
                {
                    Cell cell = new Cell();
                    cell.Dies();
                    cell.Generate();
                    m_grid[x, y] = cell;
                    m_canvas.Empty(x, y);
                }
            }
        }
    }
}
