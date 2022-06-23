namespace ConwaysGameOfLife
{
    partial class CanvasView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas_pictureBox
            // 
            this.canvas_pictureBox.BackColor = System.Drawing.Color.White;
            this.canvas_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.canvas_pictureBox.Name = "canvas_pictureBox";
            this.canvas_pictureBox.Size = new System.Drawing.Size(1134, 1104);
            this.canvas_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.canvas_pictureBox.TabIndex = 0;
            this.canvas_pictureBox.TabStop = false;
            this.canvas_pictureBox.Click += new System.EventHandler(this.canvas_pictureBox_Click);
            // 
            // CanvasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 1104);
            this.Controls.Add(this.canvas_pictureBox);
            this.Name = "CanvasView";
            this.Text = "Conway\'s Game Of Life";
            this.Load += new System.EventHandler(this.CanvasView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas_pictureBox;
    }
}