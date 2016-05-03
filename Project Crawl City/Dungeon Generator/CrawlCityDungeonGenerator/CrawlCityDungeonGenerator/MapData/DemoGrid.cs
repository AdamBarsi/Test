using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CrawlCityDungeonGenerator.MapData
{
    public class DemoGrid : GridBase<DemoTile>
    {
        public DemoGrid(Size gridSize) 
            : base(gridSize)
        {
        }
    }
}
