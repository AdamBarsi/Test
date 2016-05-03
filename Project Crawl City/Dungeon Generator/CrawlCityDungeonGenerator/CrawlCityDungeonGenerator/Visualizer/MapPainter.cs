using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CrawlCityDungeonGenerator.Visualizer
{
    public class MapPainter
    {
        #region Properties

        public MapPainterConfig Config { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MapPainter()
        {
            Config = new MapPainterConfig(20);
        }
        
        #endregion

        #region Public Methods
        
        public void Paint(Bitmap bitmap)
        {
            try
            {
                PaintGrid(bitmap);
            }
            catch(Exception e)
            {
                Console.WriteLine("MapPainter exception: " + e.Message);
            }
        }

        #endregion

        #region Private Methods

        private void PaintGrid(Bitmap bitmap)
        {
            bool paintGridLines = Config.DrawLineGrid;
            Size tileSize = Config.TileSize;
            Size surfaceSize = bitmap.Size;
            Graphics graphics = Graphics.FromImage(bitmap);
            Pen gridPen = Config.GridPen;
            int gridOffset = paintGridLines
                ? 1
                : 0;
            Size tileOffset = paintGridLines
                ? new Size(tileSize.Width + 1, tileSize.Height + 1)
                : tileSize;

            int columnCount = (surfaceSize.Width - 1) / tileOffset.Width;
            int rowCount = (surfaceSize.Height - 1) / tileOffset.Height;

            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                    Point p1 = new Point(
                        (columnIndex * tileOffset.Width) + gridOffset,
                        (rowIndex * tileOffset.Height) + gridOffset);
                    Point p2 = new Point(
                        (columnIndex * tileOffset.Width + tileOffset.Width - 1) + gridOffset,
                        (rowIndex * tileOffset.Height) + gridOffset);
                    Point p3 = new Point(
                        (columnIndex * tileOffset.Width + tileOffset.Width - 1) + gridOffset,
                        (rowIndex * tileOffset.Height + tileOffset.Height - 1) + gridOffset);
                    Point p4 = new Point(
                        (columnIndex * tileOffset.Width) + gridOffset,
                        (rowIndex * tileOffset.Height + tileOffset.Height - 1) + gridOffset);

                    if ((columnIndex % 2 == 0 && rowIndex % 2 == 1) || (columnIndex % 2 == 1 && rowIndex % 2 == 0))
                    {
                        graphics.FillRectangle(Config.EmptyTileBrush1, new Rectangle(p1, tileSize));
                    }
                    else
                    {
                        graphics.FillRectangle(Config.EmptyTileBrush2, new Rectangle(p1, tileSize));
                    }
            }

            if (paintGridLines)
            {
                //Draw columns
                for (int columnIndex = 0; columnIndex < columnCount + 1; columnIndex++)
                {
                    Point startPoint = new Point(columnIndex * tileOffset.Width, 0);
                    Point finishPoint = new Point(columnIndex * tileOffset.Width, rowCount * tileOffset.Height);
                    graphics.DrawLine(gridPen, startPoint, finishPoint);
                }
                //Draw rows
                for (int rowIndex = 0; rowIndex < rowCount + 1; rowIndex++)
                {
                    Point startPoint = new Point(0, rowIndex * tileOffset.Height);
                    Point finishPoint = new Point(columnCount * tileOffset.Width, rowIndex * tileOffset.Height);
                    graphics.DrawLine(gridPen, startPoint, finishPoint);
                }
            }
        }

        #endregion
    }
}
