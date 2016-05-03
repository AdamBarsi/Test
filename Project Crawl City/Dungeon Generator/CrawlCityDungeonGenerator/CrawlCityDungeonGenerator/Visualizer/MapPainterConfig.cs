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

        public Size OriginalSize { get; private set; } // The original size of a tile
        public Size TileSize { get; set; }   //The desired size of each tile to be drawn

        public float ScaleX
        {
            get
            {
                return TileSize.Width / OriginalSize.Width;
            }
        }

        public float ScaleY
        {
            get
            {
                return TileSize.Height / OriginalSize.Width;
            }
        }

        public Point Origin { get; set; } // The origin point of the map
        public Point MapOffset { get; set; } // The offset from the origin that determines where to draw the map

        public Pen GridPen { get; set; }    //The pen used for drawing the grid
        public Brush EmptyTileBrush1 { get; set; }  // The first brush used to draw an empty tile in every other place
        public Brush EmptyTileBrush2 { get; set; }  // The second brush used to draw an empty tile in every other place

        public bool DrawLineGrid { get; set; }  //Draws a line grid if set to true

        #endregion

        #region Constructors

        public MapPainterConfig(int squareTileSize)
            :this(squareTileSize, squareTileSize, new Point(0,0))
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MapPainterConfig(int tileSizeX, int tileSizeY, Point origin)
        {
            OriginalSize = new Size(tileSizeX, tileSizeY);
            TileSize = OriginalSize;
            Origin = origin;
            MapOffset = new Point(0, 0);
            GridPen = new Pen(Color.Olive);
            EmptyTileBrush1 = Brushes.Gainsboro;
            EmptyTileBrush2 = Brushes.GhostWhite;
        }

        #endregion
    }
}
