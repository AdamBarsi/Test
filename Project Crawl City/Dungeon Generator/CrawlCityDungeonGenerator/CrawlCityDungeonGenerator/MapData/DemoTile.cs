using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrawlCityDungeonGenerator.MapData
{
    public class DemoTile : TileBase
    {
        public int Value { get; private set; }

        public DemoTile(Point location) 
            : base(location)
        {
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override object Clone()
        {
            DemoTile clone = (DemoTile)base.Clone();
            clone.Value = Value;
            return clone;
        }
    }
}
