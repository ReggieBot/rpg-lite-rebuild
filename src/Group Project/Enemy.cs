using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// represents a hostile NPC that the player can encounter and fight
    /// inherits from Organism. Each enemy has unique stats, sounds, visuals, and pre-combat dialog
    /// </summary>
    public class Enemy : Organism, IMapEntity
    {
        // the amount of experience points awarded to the player upon defeating this enemy
        public float XPReward { get; set; }
        // the item dropped when this enemy is defeated. Null if the enemy drops nothing
        public Item DropItem { get; set; }
        // true if this enemy is a map boss. Bosses have higher stats and guard map transitions
        public bool IsBoss { get; set; }
        // path to the small sprite image shown on the 7x7 tile grid
        public string SpriteIconPath { get; set; }
        // path to the larger image shown in the InteractionForm and CombatForm
        public string InteractionIconPath { get; set; }
        // path to the .wav sound played when this enemy is defeated
        public string DeathSoundPath { get; set; }
        // path to the .wav sound played when this enemy lands a critical hit
        public string CriticalHitSoundPath { get; set; }
        // pre-combat dialog tree. Key = context (e.g. "root"), Value = starting DialogOption
        public Dictionary<string, DialogOption> Dialogs { get; set; }

        Random random = new Random(); // Used to generate random damage 
        private bool willCriticalHit = false;

        /// <summary>
        /// creates a new enemy with the specified stats.
        /// dialog tree is initialized empty and populated during map initialization in Form1.cs
        /// </summary>
        public Enemy(string name, double maxHealth, double damage, float xpReward, bool isBoss = false) : base(name, maxHealth, damage)
        {
            XPReward = xpReward;
            IsBoss = isBoss;
            Dialogs = new Dictionary<string, DialogOption>();
        }

        /// <summary>
        /// called when the enemy's health reaches 0
        /// plays the death sound and signals the combat form that the fight is over
        /// </summary>
        public override void Die()
        {
            CurrentHealth = 0;
        }
        public double Attack(Player player)
        {
            // Numbers generated are lower for the neemies
            int damage = random.Next((int)(CurrentDamage * 0.8), (int)(CurrentDamage * 1.5));
            // checks if damage is greater than health, if so, the enemy of this object dies
            if (damage >= player.CurrentHealth)
            {
                player.CurrentHealth = 0;
                player.Die();
            }
            else
                player.CurrentHealth -= damage; // Reduces the players health by the damage generated

            return damage; // returns damage to update display
        }
    }
}
