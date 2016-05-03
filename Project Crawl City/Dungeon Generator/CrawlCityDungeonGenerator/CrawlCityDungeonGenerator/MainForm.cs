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

        private MapPainterConfig mapConfig;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            mapConfig = new MapPainterConfig(20);
            mapPainter = new MapPainter(mapConfig);
            this.DoubleBuffered = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            int offsetX = MainPictureBox.Size.Width / 4;
            int offsetY = MainPictureBox.Size.Height / 4;
            Bitmap bitmap = new Bitmap(
                MainPictureBox.Size.Width + offsetX * 2,
                MainPictureBox.Size.Height + offsetY * 2);

            mapPainter.Config.DrawLineGrid = checkBoxDrawGridToggle.Checked;
            mapPainter.Paint(bitmap);

            //e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            e.Graphics.DrawImage(
                bitmap,
                new Rectangle(0, 0, MainPictureBox.Size.Width, MainPictureBox.Size.Height),
                new Rectangle(offsetX, offsetY, MainPictureBox.Size.Width + offsetX, MainPictureBox.Size.Height + offsetY), 
                GraphicsUnit.Pixel);

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
            mapPainter.Map = grid;
            MainPictureBox.Refresh();
        }
    }
}
