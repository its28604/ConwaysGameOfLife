// See https://aka.ms/new-console-template for more information

using GameModel;

const int WIDTH = 50;
const int HEIGHT = 50;

bool pause = false;

ConsoleCanvas canvas = new ConsoleCanvas();
Grid grid = new Grid(WIDTH, HEIGHT, canvas);

Task.Run(() =>
{
    while (true)
    {
        if (!pause)
        {
            grid.Generation();
            grid.Print();
            Task.Delay(100).Wait();
        }
    }
});

var key = ConsoleKey.A;
while (key != ConsoleKey.Escape)
{
    key = Console.ReadKey(true).Key;
    switch (key)
    {
        case ConsoleKey.P:
            pause = !pause;
            break;
        case ConsoleKey.W:
            {
                var pos = Console.GetCursorPosition();
                Console.SetCursorPosition(
                    pos.Left,
                    pos.Top > 0 ? pos.Top - 1 : HEIGHT - 1);
                break;
            }
        case ConsoleKey.A:
            {
                var pos = Console.GetCursorPosition();
                int x = pos.Left / sizeof(char);
                int y = pos.Top;
                Console.SetCursorPosition(
                    x > 0 ? (x - 1) * sizeof(char) : (WIDTH - 1) * sizeof(char),
                    pos.Top);
                break;
            }
        case ConsoleKey.S:
            {
                var pos = Console.GetCursorPosition();
                Console.SetCursorPosition(
                    pos.Left,
                    pos.Top < HEIGHT - 1 ? pos.Top + 1 : 0);
                break;
            }
        case ConsoleKey.D:
            {
                var pos = Console.GetCursorPosition();
                int x = pos.Left / sizeof(char);
                int y = pos.Top;
                Console.SetCursorPosition(
                    x < WIDTH - 1 ? (x + 1) * sizeof(char) : 0,
                    pos.Top);
                break;
            }
        case ConsoleKey.Spacebar:
            {
                canvas.Console_CancelKeyPress();
                var pos = Console.GetCursorPosition();
                int x = pos.Left / sizeof(char);
                int y = pos.Top;
                Console.SetCursorPosition(
                    x > 0 ? (x - 1) * sizeof(char) : (WIDTH - 1) * sizeof(char),
                    pos.Top);
                break;
            }
    }
}
