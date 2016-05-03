using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CrawlCityDungeonGenerator.MapData
{[Serializable]
    public abstract class TileBase : ICloneable
    {
        #region Constructors

        protected TileBase(Point location)
        {
            Location = location;
        }

        public Point Location { get; private set; }

        #endregion

        #region ICloneable members

    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    /// <filterpriority>2</filterpriority>
    public virtual object Clone()
        {
            TileBase newTile = (TileBase)Activator.CreateInstance(this.GetType());
            newTile.Location = new Point(Location.X, Location.Y);
            return newTile;
        }

        #endregion
    }
}
