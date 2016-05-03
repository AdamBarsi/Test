using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrawlCityDungeonGenerator.Visualizer;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using CrawlCityDungeonGenerator.MapData;

namespace CrawlCityDungeonGenerator
{
    public partial class MainForm : Form
    {
        #region Fields

        private MapPainter mapPainter;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            mapPainter = new MapPainter();
            this.DoubleBuffered = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Bitmap bitmap = new Bitmap(MainPictureBox.Size.Width, MainPictureBox.Size.Height);
            //Bitmap bitmap = new Bitmap((int)e.Graphics.VisibleClipBounds.Width, (int)e.Graphics.VisibleClipBounds.Height);
            mapPainter.Config = new MapPainterConfig(20) { DrawLineGrid = checkBoxDrawGridToggle.Checked};
            mapPainter.Paint(bitmap);

            sw.Stop();
            var t1 = sw.ElapsedMilliseconds.ToString();
            
            sw.Restart();

            e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);

            sw.Stop();
            this.Text = t1.ToString() + "|" + sw.ElapsedMilliseconds.ToString();
        }

        private void MainPictureBox_Resize(object sender, EventArgs e)
        {
            MainPictureBox.Refresh();
        }

        private void checkBoxDrawGridToggle_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Refresh();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            DemoGrid grid = new DemoGrid(new Size(10,10));
        }
    }
}
