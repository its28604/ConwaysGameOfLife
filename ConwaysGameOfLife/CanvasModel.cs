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
                Cells[i, j].Live();
        }

        public static void Generate()
        {
            var next_cells = new Cell[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    var cell = Cells[i, j];
                    if (cell.IsAlive)
                    {
                        if (FewerThanTwoLiveNeighbours(i, j))
                            next_cells[i, j].Dies();
                        else if (MoreThanThreeLiveNeighbours(i, j))
                            next_cells[i, j].Dies();
                        else
                            next_cells[i, j].Live();
                    }
                    else
                    {
                        if (ExactlyThreeLiveNeighbours(i, j))
                            next_cells[i, j].Live();
                        else
                            next_cells[i, j].Dies();
                    }
                }
            }
            Cells = next_cells;
        }

        private static bool ExactlyThreeLiveNeighbours(int i, int j)
        {
            int n = 0;
            foreach (var cell in GetNeighbours(i, j))
            {
                if (cell.IsAlive)
                    n++;
            }
            return n == 3;
        }

        private static bool FewerThanTwoLiveNeighbours(int i, int j)
        {
            int n = 0;
            foreach (var cell in GetNeighbours(i, j))
            {
                if (cell.IsAlive)
                    n++;
            }
            return n < 2;
        }

        private static IEnumerable<Cell> GetNeighbours(int i, int j)
        {
            if (i - 1 >= 0)
            {
                yield return Cells[i - 1, j];

                if (j - 1 >= 0)
                    yield return Cells[i - 1, j - 1];

                if (j + 1 < Height)
                    yield return Cells[i - 1, j + 1];
            }

            if (j - 1 >= 0)
                yield return Cells[i, j - 1];

            if (j + 1 < Height)
                yield return Cells[i, j + 1];

            if (i + 1 < Width)
            {
                yield return Cells[i + 1, j];

                if (j - 1 >= 0)
                    yield return Cells[i + 1, j - 1];

                if (j + 1 < Height)
                    yield return Cells[i + 1, j + 1];
            }
        }

        private static bool MoreThanThreeLiveNeighbours(int i, int j)
        {
            int n = 0;
            foreach (var cell in GetNeighbours(i, j))
            {
                if (cell.IsAlive)
                    n++;
            }
            return n > 3;
        }
    }
}
