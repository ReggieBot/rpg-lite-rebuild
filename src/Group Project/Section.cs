using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// represents one area within a map, containing a 7x7 grid of tiles
    /// part of the Composite pattern: GameMap contains Sections, Sections contain Tiles
    /// </summary>
    public class Section
    {
        // the display name of this section (e.g. "Starting Area", "Boss Arena")
        public string SectionName { get; set; }
        // the tiles in this section. Key = tile index (row * 7 + col), Value = the Tile object
        public Dictionary<int, Tile> Tiles { get; set; }

        /// <summary>
        /// creates a new section with an empty tile dictionary
        /// </summary>
        public Section(string name) { SectionName = name; Tiles = new Dictionary<int, Tile>(); }

        /// <summary>
        /// loads a pre-built tile dictionary into this section
        /// called during map initialization to populate all 49 tiles
        /// </summary>
        public void LoadSection(Dictionary<int, Tile> tileData) { Tiles = tileData; }

        /// <summary>
        /// retrieves a tile by its grid index (0-48)
        /// returns null if no tile exists at that index
        /// </summary>
        public Tile GetTile(int index) { return Tiles.ContainsKey(index) ? Tiles[index] : null; }

        /// <summary>
        /// retrieves a tile by its row and column position
        /// converts to index internally using row * 7 + col
        /// </summary>
        public Tile GetTile(int row, int col) { return GetTile(row * 7 + col); }
    }
}