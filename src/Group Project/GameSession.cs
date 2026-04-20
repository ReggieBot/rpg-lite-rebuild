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
        }

        // GameSession uses CurrentMap and CurrentSection, which don't belong to Form1 anymore
        // so the logic for moving to the next section or map belongs here too
        public bool TryMoveToTileDestination(int row, int column)
        {
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

            // if the tile is an arrow, use the tile's DestinationSectionId to move to the next section
            return CurrentMap.GoToSection(tile.DestinationSectionId);
        }

        public bool TryPickUpItem(int row, int column)
        {
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
