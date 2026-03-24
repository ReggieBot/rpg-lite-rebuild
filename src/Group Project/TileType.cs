using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public enum TileType
    {
        Empty,        // Non-interactive tile
        ArrowUp,   // Navigation indicator
        ArrowDown,
        ArrowLeft,
        ArrowRight,
        Enemy,        // Triggers combat
        FriendlyNPC,  // Triggers dialog
        Item,         // Collectible pickup
        Boss,         // Map boss encounter
        Inventory,    // Opens inventory
        LevelUp       // Skill allocation NPC (FireKeeper)
    }
}