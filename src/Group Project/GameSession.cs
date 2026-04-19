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
    }
}
