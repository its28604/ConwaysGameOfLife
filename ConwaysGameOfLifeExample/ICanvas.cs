// See https://aka.ms/new-console-template for more information
public interface ICanvas
{
    event StateChangedEventHandler StateChanged;
    void Init(int width, int height);
    void Fill(int x, int y);
    void Empty(int x, int y);
}

public delegate void StateChangedEventHandler(object? sender, StateChangedEventArgs args);
public struct StateChangedEventArgs
{
    public StateChangedEventArgs(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
}
