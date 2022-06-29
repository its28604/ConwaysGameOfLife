namespace GameModel
{
    class Grid
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public ICanvas Canvas { get; private set; }

        private Cell[,] grid;

        public Grid(int width, int height, ICanvas canvas)
        {
            Width = width;
            Height = height;
            Canvas = canvas;

            InitGrid();
        }

        public Cell? this[int x, int y]
        {
            get
            {
                int pos_x = x, pos_y = y;
                if (x < 0)
                    pos_x = Width + x;
                if (x >= Width)
                    pos_x = x - Width;
                if (y < 0)
                    pos_y = Height + y;
                if (y >= Height)
                    pos_y = y - Height;
                return grid[pos_x, pos_y];
            }
        }
        public void Generation()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cell cell = grid[x, y];

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
        }

        public void Print()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cell cell = grid[x, y];
                    if (cell.Generate())
                    {
                        if (grid[x, y].IsAlive)
                            Canvas.Fill(x, y);
                        else
                            Canvas.Empty(x, y);
                    }
                }
            }
        }

        private void InitGrid()
        {
            Random random = new Random();

            Canvas.Init(Width, Height);
            Canvas.StateChanged += Canvas_StateChanged;

            grid = new Cell[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (random.Next(0, 2) == 1)
                    {
                        Cell cell = new Cell(true);
                        cell.Lives();
                        grid[x, y] = cell;
                        Canvas.Fill(x, y);
                    }
                    else
                    {
                        Cell cell = new Cell(false);
                        cell.Dies();
                        grid[x, y] = cell;
                        Canvas.Empty(x, y);
                    }
                }
            }

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    grid[x, y].ConnectWithNeighbours(this, x, y);
        }

        private void Canvas_StateChanged(object? sender, StateChangedEventArgs args)
        {
            Cell cell = grid[args.X, args.Y];
            if (cell.IsAlive)
                cell.Dies();
            else
                cell.Lives();
            Print();
        }
    }
}
