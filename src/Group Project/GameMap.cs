using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// represents one complete map in the game
    /// contains sections, enemies, items, and NPCs
    /// </summary>
    public class GameMap
    {
        // let map keep section IDs instead of discarding them after LoadMap()
        private Dictionary<string, Section> _sections;
        public List<Enemy> MapHostiles { get; set; }
        public string MapName { get; set; }
        public List<Item> MapItems { get; set; }
        public List<FriendlyNPC> MapNPCs { get; set; }
        public string CurrentSectionId { get; set; }

        public GameMap(string mapName)
        {
            MapName = mapName;
            _sections = new Dictionary<string, Section>();
            MapHostiles = new List<Enemy>();
            MapItems = new List<Item>();
            MapNPCs = new List<FriendlyNPC>();
            CurrentSectionId = null;
        }

        /// <summary>
        /// loads sections into the map from a dictionary
        /// the dictionary keys are the section IDs, which are used for navigation and lookups
        /// if CurrentSectionId is null and main exists, initialize to 'main'
        /// </summary>
        public void LoadMap(Dictionary<string, Section> sections)
        {
            _sections.Clear();
            foreach (var kvp in sections)
            {
                _sections.Add(kvp.Key, kvp.Value);
            }

            if (CurrentSectionId == null && _sections.ContainsKey("main"))
            {
                CurrentSectionId = "main";
            }
        }

        /// <summary>
        /// returns the section the player is currently in
        /// </summary>
        public Section GetCurrentSection() => _sections[CurrentSectionId];

        /// <summary>
        /// navigates to a specific section by id
        /// returns true if valid, false if out of range
        /// </summary>
        public bool GoToSection(string sectionId)
        {
            if (_sections.ContainsKey(sectionId))
            {
                CurrentSectionId = sectionId;
                return true;
            }
            return false;
        }

        // the total number of sections in this map
        public int SectionCount => _sections.Count;
    }

}
