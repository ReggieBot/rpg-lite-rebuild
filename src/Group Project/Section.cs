using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// Represents a 7x7 grid of tiles
    /// </summary>
    public class Section
    {
        public const int GRID_SIZE = 7;

        public string SectionId { get; }
        public string SectionName { get; set; }

        // 2d array of immutable tiles
        private readonly Tile[,] _tiles;

        // construct new section
        public section(string sectionId, string sectionName)
        {
            SectionId = sectionId;
            SectionName = sectionName;
            _tiles = new Tile[GRID_SIZE, GRID_SIZE];

            InitializeEmptyTiles;
        }

        private void InitializeEmptyTiles()
        {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; row++)
                {
                    _tiles[row, col] = new Tile(row, col, TileType.Empty);
                }
            }
        }

        public Tile GetTile(int row, int col)
        {
            return _tiles[row, col];
        }

        public Tile SetTile(Tile tile)
        {
            _tiles[tile.Row, tile.Column] = tile;
        }
    }
}
