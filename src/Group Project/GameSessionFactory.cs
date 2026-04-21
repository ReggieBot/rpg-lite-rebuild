using System;
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

            // default player (until I fix saves)
            Player player = CreateStartingPlayer(saveData);

            // if map points to known map then start there. otherwise fall back to first map
            int currentMapIndex = FindStartingMapIndex(maps, saveData);

            return new GameSession(player, maps, currentMapIndex);
        }

        private static Player CreateStartingPlayer(SaveData saveData)
        {
            // this will get changed hopefully
            return new Player("Reggie", 100, 15);
        }

        private static List<GameMap> InitializeAllMaps()
        {
            List<GameMap> maps = new List<GameMap>();

            // build first map
            GameMap map1 = Map1Factory.BuildMap1();
            maps.Add(map1);

            return maps;
        }

        private static int FindStartingMapIndex(List<GameMap> maps, SaveData saveData)
        {
            if (saveData == null || saveData.MapProgress == null)
            {
                // no save data so start at first map
                return 0;
            }

            // find what map the save points to
            // scary lambda function that looks through the list of maps
            // and finds the index of the one that matches the save data's map name
            int currentMapIndex = maps.FindIndex(
                m => m.MapName == saveData.MapProgress.MapName);

            if (currentMapIndex < 0)
            {
                return 0;
            }

            return currentMapIndex;
        }
    }
}
