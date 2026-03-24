using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public enum GameState
    {
        Exploring,    // Player is navigating the tile map
        InCombat,     // Player is in a combat modal
        InDialog,     // Player is talking to an NPC
        InInventory,  // Player is viewing inventory
        InLevelUp,    // Player is allocating skill points
        GameOver      // Player has died
    }

}
