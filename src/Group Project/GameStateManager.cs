using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// encapsulates all JSON save/load/delete operations for game persistence
    /// stores save data in the user's AppData folder
    /// if a save file is corrupted, it is automatically deleted and a new game starts
    /// </summary>
    public class GameStateManager
    {
        // path to the folder where the save file is stored (AppData/RPGLiteCombatGame)
        private readonly string _directoryPath;
        // full path to the JSON save file
        private readonly string _filePath;

        /// <summary>
        /// initializes the save manager and ensures the save directory exists
        /// </summary>
        public GameStateManager()
        {
            _directoryPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "RPGLiteCombatGame");
            _filePath = Path.Combine(_directoryPath, "savegame.json");
            Directory.CreateDirectory(_directoryPath);
        }

        /// <summary>
        /// saves the player's current state and map progress to a JSON file
        /// called when a map is completed
        /// </summary>
        public void SaveGame(Player player, GameMap gameMap)
        {
            // map domain objects to lightweight save DTOs
            var data = new SaveData
            {
                Player = new PlayerSaveData
                {
                    Level = player.Level,
                    CurrentExperiencePoints = player.CurrentXP,
                    NextLevelExperiencePointsRequired = player.XPToNextLevel,
                    MaxHealth = player.MaxHealth,
                    CurrentHealth = player.CurrentHealth,
                    Damage = player.MaxDamage,
                    SkillPoints = player.SkillPoints,
                    Inventory = player.Inventory.Select(i => 
                        new InventoryItemData { ItemName = i.Name, Quantity = i.Quantity }).ToList(), Allies = player.Allies.Select(a =>
                            new AllySaveData { Name = a.Name }).ToList()
                },
                MapProgress = new MapSaveData { MapName = gameMap.MapName }
            };

            // serialize with indentation for readability
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_filePath, JsonSerializer.Serialize(data, options));
        }

        /// <summary>
        /// loads the save file and returns the deserialized data.
        /// returns null if no save file exists.
        /// if the file is corrupted, deletes it and returns null to start a fresh game.
        /// </summary>
        public SaveData LoadGame()
        {
            try
            {
                if (!File.Exists(_filePath)) return null;
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<SaveData>(json);
            }
            catch { DeleteSave(); return null; }
        }

        /// <summary>
        /// deletes the save file. used for game reset or when a corrupt save is detected.
        /// </summary>
        public void DeleteSave()
        {
            if (File.Exists(_filePath)) File.Delete(_filePath);
        }
    }
}