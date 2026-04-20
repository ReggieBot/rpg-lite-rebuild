using System.Collections.Generic;

namespace Group_Project
{
    public static class GameSessionFactory
    {
        public static GameSession CreateNewSession()
        {
            // save/load setup
            GameStateManager saveManager = new GameStateManager();

            // map construction
            List<GameMap> maps = InitializeAllMaps();
            SaveData saveData = saveManager.LoadGame();


        }

        private static List<GameMap> InitializeAllMaps()
        {
            List<GameMap> maps = new List<GameMap>();

            // build first map
            GameMap map1 = Map1Factory.BuildMap1();
            maps.Add(map1);

            return maps;
        }
    }
}
