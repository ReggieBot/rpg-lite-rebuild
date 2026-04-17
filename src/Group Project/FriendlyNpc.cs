using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// represents a non-combat NPC that the player can talk to, gift items to, and recruit
    /// does not extend Organism because friendly NPCs cannot be attacked or die
    /// </summary>
    public class FriendlyNPC : IMapEntity
    {
        // the NPC's display name
        public string Name { get; set; }
        // dialog tree for this NPC. Key = context (e.g. "root", "afterRecruit"), Value = starting DialogOption
        public Dictionary<string, DialogOption> Dialogs { get; set; }
        // the item name this NPC wants in order to be recruited. Null if they don't want anything
        public string RequiredItem { get; set; }
        // path to the small sprite image shown on the 7x7 tile grid
        public string SpriteIconPath { get; set; }
        // path to the larger image shown in the InteractionForm
        public string InteractionIconPath { get; set; }
        // whether this NPC has been recruited as an ally
        public bool IsRecruited { get; set; }
        /// <summary>
        /// creates a new friendly NPC with an empty dialog tree and unrecruited status
        /// dialog trees and asset paths are set during map initialization in Form1.cs
        /// </summary>
        public FriendlyNPC(string name)
        {
            Name = name;
            Dialogs = new Dictionary<string, DialogOption>();
            IsRecruited = false;
        }
    }
}
