using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// base class for recruited companions that fight alongside the player
    /// each ally subclass overrides UseAbility() with unique behavior (polymorphism)
    /// </summary>
    public class Ally
    {
        // the ally's display name
        public string Name { get; set; }
        // path to the sprite image shown on the allies display tile
        public string SpriteIconPath { get; set; }
        // path to the .wav sound played when the ally uses their ability in combat
        public string AbilitySoundPath { get; set; }
        // path to the .wav sound played when the ally is first recruited
        public string RecruitSoundPath { get; set; }
        // the name of the ally's combat ability (e.g. "Storm Ruler", "Toxic")
        public string abilityName;
        // a short description of what the ability does, shown in the combat UI
        public string abilityDescription;
        // the maximum number of times this ability can be used per game
        public byte abilityUsageMaximum;
        // the remaining number of uses. Decremented each time the ability is used
        public byte abilityUsageLeft;

        /// <summary>
        /// executes the ally's unique ability during combat
        /// ability effect is determined by the ally's name
        /// e.g. Siegward deals damage to enemy, Solaire heals the player
        /// </summary>
        public void UseAbility(Player player, Enemy enemy)
        {
            // ally logic
        }
    }
}