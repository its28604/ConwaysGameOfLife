using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife
{
    public class CanvasController
    {
        public PictureBox Target { get; internal set; }

        private BackgroundWorker worker;
        private bool _refreshing = false;
        private int interval = 1000;
        private const int width = 20;
        private const int height = 20;

        public CanvasController()
        {
            worker = new BackgroundWorker();
            worker.DoWork += BackgroundWorker_DoWork;
            worker.WorkerSupportsCancellation = true;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                CanvasModel.Generate();
                Refresh();
                Thread.Sleep(interval);
            }
        }

        private void Refresh()
        {
            if (_refreshing)
                return;
            _refreshing = true;
            Bitmap canvas = new Bitmap(Target.Image);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    canvas.SetPixel(i, j, CanvasModel.Cells[i, j].IsAlive ? Color.Black : Color.White);
                }
            }
            Target.Image = canvas;
            _refreshing = false;
        }

        internal void Start()
        {
            CanvasModel.Init(width, height);
            var canvas = new Bitmap(width, height);
            Target.Image = canvas;
            Refresh();
            worker.RunWorkerAsync();
        }

        internal void Click(Point point)
        {
            int i = (int)((point.X * width) / Target.Width);
            int j = (int)((point.Y * height) / Target.Height);
            CanvasModel.ChangedCellState(i, j);
            Refresh();
        }
    }
}
