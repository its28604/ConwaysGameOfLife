namespace GameModel
{
    class Cell
    {
        private const int LT = 0;
        private const int LM = 1;
        private const int LB = 2;
        private const int MT = 3;
        private const int MB = 4;
        private const int RT = 5;
        private const int RM = 6;
        private const int RB = 7;

        private Cell?[] neighbours;
        private int neighboursAlive;

        public bool IsAlive { get; private set; }

        public int NeighboursAlive
        {
            get
            {
                if (neighboursAlive < 0)
                {
                    neighboursAlive = 0;
                    foreach (var neighbour in neighbours)
                        if (neighbour?.IsAlive ?? false)
                            neighboursAlive++;
                }
                return neighboursAlive;
            }
        }

        public bool Next { get; private set; }

        public Cell(bool is_alive)
        {
            this.IsAlive = is_alive;
            this.neighboursAlive = -1;
            this.neighbours = new Cell[8];
        }

        public bool AbleToReproduction()
        {
            return NeighboursAlive == 3;
        }
        public void AssignNeibours(Grid parent, int x, int y)
        {
            neighbours[LT] = parent[x - 1, y - 1];
            neighbours[LM] = parent[x - 1, y];
            neighbours[LB] = parent[x - 1, y + 1];
            neighbours[MT] = parent[x, y - 1];
            neighbours[MB] = parent[x, y + 1];
            neighbours[RT] = parent[x + 1, y - 1];
            neighbours[RM] = parent[x + 1, y];
            neighbours[RB] = parent[x + 1, y + 1];
        }
        public void Dies() => Next = false;
        public bool Generate()
        {
            neighboursAlive = -1;
            if (IsAlive != Next)
            {
                IsAlive = Next;
                return true;
            }
            return false;
        }
        public void Lives() => Next = true;
        public bool Overpopulation()
        {
            return NeighboursAlive > 3;

        }
        public bool Underpopulation()
        {
            return NeighboursAlive < 2;

        }
    }
}
