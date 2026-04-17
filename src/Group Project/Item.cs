using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// represents a collectible or usable item in the game
    /// items can be picked up from tiles, gifted to NPCs, or used during combat
    /// </summary>
    public class Item : IMapEntity
    {
        // the display name of the item (e.g. "First Aid Spray", "Siegbrau")
        public string Name { get; set; }
        // a short description of what the item is
        public string Description { get; set; }
        // explains what the item does and how it is used
        public string UsageInfo { get; set; }
        // path to the image displayed in the inventory modal
        public string ImagePath { get; set; }
        // the number of this item the player currently holds. Stacks via AddItem() in Player
        public byte Quantity { get; set; }

        /// <summary>
        /// creates a new item with the specified details. quantity defaults to 1
        /// </summary>
        public Item(string name, string description, string usageInfo, string imagePath, byte quantity = 1)
        {
            Name = name;
            Description = description;
            UsageInfo = usageInfo;
            ImagePath = imagePath;
            Quantity = quantity;
        }
    }
}
