using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CrawlCityDungeonGenerator.Visualizer
{
    public class MapPainterConfig
    {
        #region Properties

        public Size TileSize { get; set; }   //The size of each tile to be drawn
        public Pen GridPen { get; set; }    //The pen used for drawing the grid
        public bool DrawLineGrid { get; set; }  //Draws a line grid if set to true
        public Brush EmptyTileBrush1 { get; set; }  // The first brush used to draw an empty tile in every other place
        public Brush EmptyTileBrush2 { get; set; }  // The second brush used to draw an empty tile in every other place

        #endregion

        #region Constructors

        public MapPainterConfig(int squareTileSize)
            :this(squareTileSize, squareTileSize)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MapPainterConfig(int tileSizeX, int tileSizeY)
        {
            TileSize = new Size(tileSizeX, tileSizeY);
            GridPen = new Pen(Color.Olive);
            EmptyTileBrush1 = Brushes.Gainsboro;
            EmptyTileBrush2 = Brushes.GhostWhite;
        }

        #endregion
    }
}
