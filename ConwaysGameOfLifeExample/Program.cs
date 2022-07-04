// See https://aka.ms/new-console-template for more information

const int WIDTH = 50;
const int HEIGHT = 50;

ICanvas canvas = new ConsoleCanvas();
Grid grid = new Grid(WIDTH, HEIGHT, canvas);

Task.Run(() =>
{
    while (true)
    {
        grid.Process();
        grid.Generate();
        Task.Delay(200).Wait();
    }
});

while (Console.ReadKey().Key != ConsoleKey.Escape) ;