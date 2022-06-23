using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife
{
    public partial class CanvasView : Form
    {
        private CanvasController CanvasController;
        public CanvasView()
        {
            InitializeComponent();
        }

        private void CanvasView_Load(object sender, EventArgs e)
        {
            CanvasController = new CanvasController();
            CanvasController.Target = this.canvas_pictureBox;
            CanvasController.Start();
        }

        private void canvas_pictureBox_Click(object sender, EventArgs e)
        {
            CanvasController.Click((sender as PictureBox).PointToClient(Cursor.Position));
        }
    }
}
