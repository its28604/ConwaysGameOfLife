// See https://aka.ms/new-console-template for more information
class ConsoleCanvas : ICanvas
{
    public event StateChangedEventHandler? StateChanged;

    public void Empty(int x, int y)
    {
        Console.SetCursorPosition(x * sizeof(char), y);
        Console.Write("□");
    }

    public void Fill(int x, int y)
    {
        Console.SetCursorPosition(x * sizeof(char), y);
        Console.Write("■");
    }

    public void Init(int width, int height)
    {
        Console.SetWindowSize(width * sizeof(char), height);
        Console.SetBufferSize(width * sizeof(char), height);
        Console.Clear();
        Console.SetWindowPosition(0, 0);
    }

    public void Console_CancelKeyPress()
    {
        var pos = Console.GetCursorPosition();
        StateChanged?.Invoke(this, new StateChangedEventArgs(pos.Left / sizeof(char), pos.Top));
    }
}
