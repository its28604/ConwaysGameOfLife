using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    /// <summary>
    /// Any live cell with fewer than two live neighbours dies, as if by underpopulation.
    /// Any live cell with two or three live neighbours lives on to the next generation.
    /// Any live cell with more than three live neighbours dies, as if by overpopulation.
    /// Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
    /// </summary>
    public static class CanvasModel
    {
        public static int Width { get; private set; } = 100;
        public static int Height { get; private set; } = 100;

        public static Cell[,] Cells { get; set; }

        public static void Init(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[Width, Height];
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    Cells[i, j] = new Cell();
        }

        public static void ChangedCellState(int i, int j)
        {
            if (Cells[i, j].IsAlive)
                Cells[i, j].Dies();
            else
                Cells[i, j].Lives();
        }

        public static void Generate()
        {
            var next_cells = new Cell[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var cell = Cells[x, y];
                    if (cell.IsAlive)
                    {
                        if (cell.Underpopulation() || cell.Overpopulation())
                            next_cells[x, y].Dies();
                        else
                            next_cells[x, y].Lives();
                    }
                    else
                    {
                        if (cell.AbleToReproduction())
                            next_cells[x, y].Lives();
                        else
                            next_cells[x, y].Dies();
                    }
                }
            }
            Cells = next_cells;
        }
    }
}
