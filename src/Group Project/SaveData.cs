using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// root save data object written to and read from the JSON save file.
    /// contains all data needed to restore a player's game session.
    /// </summary>
    public class SaveData
    {
        // the player's stats, inventory, and allies at time of save
        public PlayerSaveData Player { get; set; }
        // which map the player was on when the save occurred
        public MapSaveData MapProgress { get; set; }
    }

    /// <summary>
    /// lightweight data transfer object for serializing player state to JSON.
    /// kept separate from the Player domain class to maintain layer separation.
    /// </summary>
    public class PlayerSaveData
    {
        public byte Level { get; set; }
        public float CurrentExperiencePoints { get; set; }
        public float NextLevelExperiencePointsRequired { get; set; }
        public double MaxHealth { get; set; }
        public double CurrentHealth { get; set; }
        public double Damage { get; set; }
        public byte SkillPoints { get; set; }
        // list of items with name and quantity only — descriptions are derived at load time
        public List<InventoryItemData> Inventory { get; set; }
        // list of ally names only — full ally data is rebuilt from the name at load time
        public List<AllySaveData> Allies { get; set; }
    }

    /// <summary>
    /// stores the minimum data needed to reconstruct an inventory item from a save.
    /// </summary>
    public class InventoryItemData
    {
        public string ItemName { get; set; }
        public byte Quantity { get; set; }
    }

    /// <summary>
    /// stores only the ally's name. full ally data is rebuilt using CreateAllyFromNPC() at load time.
    /// </summary>
    public class AllySaveData
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// stores the current map name so the game knows where to resume.
    /// </summary>
    public class MapSaveData
    {
        public string MapName { get; set; }
    }
}