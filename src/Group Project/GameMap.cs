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
        private List<Section> _sections;
        public List<Enemy> MapHostiles { get; set; }
        public string MapName { get; set; }
        public List<Item> MapItems { get; set; }
        public List<FriendlyNPC> MapNPCs { get; set; }
        public int CurrentSectionIndex { get; set; }

        public GameMap(string mapName)
        {
            MapName = mapName; _sections = new List<Section>();
            MapHostiles = new List<Enemy>(); MapItems = new List<Item>();
            MapNPCs = new List<FriendlyNPC>(); CurrentSectionIndex = 0;
        }

        /// <summary>
        /// loads sections into the map from a dictionary
        /// </summary>
        public void LoadMap(Dictionary<string, Section> sections)
        {
            _sections.Clear();
            foreach (var kvp in sections) _sections.Add(kvp.Value);
        }

        /// <summary>
        /// returns the section the player is currently in
        /// </summary>
        public Section GetCurrentSection() => _sections[CurrentSectionIndex];

        /// <summary>
        /// navigates to a specific section by index
        /// returns true if valid, false if out of range
        /// </summary>
        public bool GoToSection(int sectionIndex)
        {
            if (sectionIndex >= 0 && sectionIndex < _sections.Count)
            {
                CurrentSectionIndex = sectionIndex;
                return true;
            }
            return false;
        }

        // the total number of sections in this map
        public int SectionCount => _sections.Count;

        public Enemy FindEnemy(string name) => MapHostiles.Find(e => e.Name == name);
        public FriendlyNPC FindNPC(string name) => MapNPCs.Find(n => n.Name == name);
        public Item FindItem(string name) => MapItems.Find(i => i.Name == name);
    }

}