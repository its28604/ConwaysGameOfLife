// See https://aka.ms/new-console-template for more information
public class Cell
{
    private bool next;
    private Cell[] neighbours = Array.Empty<Cell>();
    private int neighboursAlive = -1;

    public int NeighboursAlive
    {
        get
        {
            if (neighboursAlive == -1)
            {
                neighboursAlive = 0;
                foreach (Cell neighbour in neighbours)
                    if (neighbour.IsAlive)
                        neighboursAlive++;
            }

            return neighboursAlive;
        }
    }
    public bool IsAlive { get; private set; }

    public Cell() { }

    public void AssignNeibours(params Cell[] neighbours)
    {
        this.neighbours = neighbours;
    }

    public bool Underpopulation()
    {
        return NeighboursAlive < 2;
    }

    public bool Overpopulation()
    {
        return NeighboursAlive > 3;
    }

    public bool Generate()
    {
        neighboursAlive = -1;
        if (IsAlive != next)
        {
            IsAlive = next;
            return true;
        }
        else return false;
    }

    public bool AbleToReproduction()
    {
        return NeighboursAlive == 3;
    }

    public void Lives()
    {
        next = true;
    }

    public void Dies()
    {
        next = false;
    }
}
