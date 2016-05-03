using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CrawlCityDungeonGenerator.MapData
{
    [Serializable]
    public abstract class GridBase<T> : ICloneable
        where T : TileBase
    {
        #region Constructors

        protected GridBase(Size gridSize)
        {
            GridSize = gridSize;
            Tiles = new T[GridSize.Width*gridSize.Height];
        }

        #endregion

        #region Properties

        /// <summary>
        /// The width of the grid
        /// </summary>
        public Size GridSize { get; }

        public T[] Tiles { get; }

        #endregion

        #region ICloneable

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public virtual object Clone()
        {
            //TODO: Rework for better support in cloning any Grid descendant
            GridBase<T> newGrid = (GridBase<T>)Activator.CreateInstance(this.GetType());
            for (int i = 0; i < Tiles.Length; i++)
            {
                T tile = Tiles[i];
                if (tile != null)
                {
                    newGrid.Tiles[i] = (T)tile.Clone();
                }
            }

            return newGrid;
        }

        #endregion

        #region Indexers

        public T this[int x, int y]
        {
            get
            {
                return ValidateIndex(x, y)
                    ? Tiles[y * GridSize.Width + x]
                    : null;
            }
            private set
            {
                if (!ValidateIndex(x, y))
                {
                    throw new Exception("Out of bounds!");
                }
                Tiles[y * GridSize.Width + x] = value;
            }
        }

        public T this[int index]
        {
            get
            {
                return ValidateIndex(index)
                    ? Tiles[index]
                    : null;
            }
            private set
            {
                if (!ValidateIndex(index))
                {
                    throw new Exception("Out of bounds!");
                }
                Tiles[index] = value;
            }
        }

        public virtual T InitializeTile(int x, int y)
        {
            this[x, y] = Activator.CreateInstance<T>();
            return this[x, y];
        }

        #endregion

        #region Public Methods

        public bool IsInBounds(int x, int y)
        {
            return ValidateIndex(x, y);
        }

        public bool IsEmpty(int x, int y)
        {
            return ValidateIndex(x, y) && this[x,y] == null;
        }

        #region Navigation

        public bool LeftFromTile(TileBase tile, out TileBase result)
        {
            Point loc = new Point(tile.Location.X - 1, tile.Location.Y);
            return TryGetTileAtLoc(loc, out result);
        }

        public bool RightFromTile(TileBase tile, out TileBase result)
        {
            Point loc = new Point(tile.Location.X + 1, tile.Location.Y);
            return TryGetTileAtLoc(loc, out result);
        }

        public bool UpFromTile(TileBase tile, out TileBase result)
        {
            Point loc = new Point(tile.Location.X, tile.Location.Y - 1);
            return TryGetTileAtLoc(loc, out result);
        }

        public bool DownFromTile(TileBase tile, out TileBase result)
        {
            Point loc = new Point(tile.Location.X, tile.Location.Y + 1);
            return TryGetTileAtLoc(loc, out result);
        }

        #endregion

        #endregion

        #region Private Methods

        private bool ValidateIndex(int index)
        {
            return index >= 0 && index < Tiles.Length;
        }

        private bool ValidateIndex(int x, int y)
        {
            return 
                x < GridSize.Width && x >= 0 &&
                y < GridSize.Height && y >= 0;
        }

        /// <summary>
        /// Returns true if 
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool TryGetTileAtLoc(Point loc, out TileBase result)
        {
            result = null;
            if (!ValidateIndex(loc.X, loc.Y))
                return false;
            result = this[loc.X, loc.Y];
            return true;
        }

        #endregion

    }
}
