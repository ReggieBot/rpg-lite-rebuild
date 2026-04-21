using System.Collections.Generic;

namespace Group_Project
{
    public class GameSession
    {
        private List<GameMap> _maps;
        private int _currentMapIndex;

        // private set so that only the GameSession can modify the player
        // but other classes can read it
        public Player Player { get; private set; }
        public GameState CurrentState { get; set; }


        // player's current location on active board section
        // Player.cs shouldn't own this as it's directly related to current board state
        public int PlayerRow { get; private set; }
        public int PlayerColumn { get; private set; }

        // expose active map in one place
        // CurrentMap exposes the sessions currently selected map
        // `get` belongs to a property not a method, so it can be accessed like a field
        // e.g. 'gameSession.CurrentMap' instead of 'gameSession.GetCurrentMap()'
        // C# is pretty cool.
        public GameMap CurrentMap
        {
            get
            {
                return _maps[_currentMapIndex];
            }
        }

        // expose active section in one place
        public Section CurrentSection
        {
            get
            {
                return CurrentMap.GetCurrentSection();
            }
        }

        public GameSession(Player player, List<GameMap> maps, int currentMapIndex)
        {
            Player = player;
            _maps = maps;
            _currentMapIndex = currentMapIndex;
            CurrentState = GameState.Exploring;

            SetPlayerSpawnForCurrentSection();
        }

        private void SetPlayerSpawnForCurrentSection()
        {
            PlayerRow = 6;
            PlayerColumn = 3;
        }

        // prevent accidental access to tiles outside board
        private bool IsInsideGrid(int row, int column)
        {
            if (row < 0 || row >= Section.GRID_SIZE)
            {
                return false;
            }

            if (column < 0 || column >= Section.GRID_SIZE)
            {
                return false;
            }

            return true;
        }

        private bool IsAdjacentToPlayer(int row, int column)
        {
            // using 'Manhattan geometry' to determine if the tile is adjacent to the player
            // it checks if the clicked tile is exactly one step away from the player
            // measures the distance in terms of rows and columns separately, not diagonally
            // using absolute value to account for direction (left vs. right, up vs. down)
            int rowDifference = Math.Abs(PlayerRow - row);
            int columnDifference = Math.Abs(PlayerColumn - column);

            if (rowDifference == 1 && columnDifference == 0)
            {
                return true;
            }

            if (columnDifference == 1 && rowDifference == 0)
            {
                return true;
            }

            // not adjacent
            return false;

        }

        // make sure player is on tile
        public bool IsPlayerOnTile(int row, int column)
        {
            if (PlayerRow == row && PlayerColumn == column)
            {
                return true;
            }

            return false;
        }

        // only empty tiles can be walkable
        private bool IsWalkableTile(Tile tile)
        {
            if (tile.Type == TileType.Empty)
            {
                return true;
            }

            return false;
        }

        // this succeeds if the tile inside board, tile is next to player, tile exists, and tile is walkable
        // if all checks pass then session updates PlayerRow and PlayerColumn (moving the player)
        public bool TryToMovePlayer(int row, int column)
        {
            // check if player is inside grid first
            if (!IsInsideGrid(row, column))
            {
                return false;
            }

            if (!IsAdjacentToPlayer(row, column))
            {
                return false;
            }

            Tile tile = CurrentSection.GetTile(row, column);
            if (tile == null)
            {
                return false;
            }

            if (!IsWalkableTile(tile))
            {
                return false;
            }

            PlayerRow = row;
            PlayerColumn = column;
            return true;
        }

        // GameSession uses CurrentMap and CurrentSection, which don't belong to Form1 anymore
        // so the logic for moving to the next section or map belongs here too
        public bool TryMoveToTileDestination(int row, int column)
        {
            if (!IsInsideGrid(row, column))
            {
                return false;
            }

            // now arrows can only be clicked if they are next to a player
            // before they were accessible from any location on the board
            if (!IsAdjacentToPlayer(row, column))
            {
                return false;
            }

            Tile tile = CurrentSection.GetTile(row, column);
            if (tile == null)
            {
                return false;
            }

            // get tile type from Tile.cs
            // LoadInteraction returns TileType.Empty for non-interactable and InteractionFinished tiles
            TileType interactionType = tile.LoadInteraction();
            if (interactionType != TileType.ArrowLeft &&
                interactionType != TileType.ArrowRight &&
                interactionType != TileType.ArrowUp &&
                interactionType != TileType.ArrowDown)
            {
                return false;
            }

            bool movedToNewSection = CurrentMap.GoToSection(tile.DestinationSectionId);
            if (!movedToNewSection)
            {
                return false;
            }

            // after changing sections we need to respawn the player
            // hoping to improve this to mirrow arrow tile of prev. section in the future
            SetPlayerSpawnForCurrentSection();
            return true;
        }

        public bool TryPickUpItem(int row, int column)
        {
            if (!IsInsideGrid(row, column))
            {
                return false;
            }

            // player must now be next to an item to pick it up
            if (!IsAdjacentToPlayer(row, column))
            {
                return false;
            }

            // look up clicked tile from active section
            Tile tile = CurrentSection.GetTile(row, column);
            if (tile == null)
            {
                return false;
            }

            // check if the tile is an item tile and can be interacted with
            TileType interactionType = tile.LoadInteraction();
            if (interactionType != TileType.Item)
            {
                return false;
            }

            // safely get item ref. stored on tile (using `as`)
            Item item = tile.Entity as Item;
            if (item == null)
            {
                return false;
            }

            // apply pickup then mark tile as completed
            Player.AddItem(item);
            tile.CompleteInteraction();
            return true;

        }

        public bool TryHandleTileClick(int row, int column)
        {
            // check if clicked tile is an arrow and try moving to the destination section
            if (TryMoveToTileDestination(row, column))
            {
                return true;
            }

            // try picking up item
            if (TryPickUpItem(row, column))
            {
                return true;
            }

            // nothing happened
            return false;
        }
    }
}
