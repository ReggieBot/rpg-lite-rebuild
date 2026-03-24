using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// represents the human controlled player character.
    /// inherits from Organism and adds leveling, experience, inventory, and ally management
    /// </summary>
    public class Player : Organism
    {
        public float CurrentXP { get; set; } // the players current accumulated experience points.

        public float XPToNextLevel { get; set; } // the amount of XP required to reach the next level

        public byte SkillPoints { get; set; } // available skill points to invest in health or damage via the FireKeeper 

        public List<Item> Inventory { get; set; } // the player's collection of items. Managed through AddItem() 

        public List<Ally> Allies { get; set; } // list of recruited allies available for combat abilities

        Random random = new Random(); // Used to generate random damage 

        /// <summary>
        /// initializes a new player at level 1 with empty inventory and no allies
        /// </summary>
        public Player(string name, double maxHealth, double damage) : base(name, maxHealth, damage)
        {
            Level = 1;
            CurrentXP = 0;
            XPToNextLevel = 100;
            SkillPoints = 0;
            Inventory = new List<Item>();
            Allies = new List<Ally>();
        }

        /// <summary>
        /// called when the players health reaches 0
        /// triggers the game over state
        /// </summary>
        public override void Die()
        {
            // Trigger game over state, play death sound
        }

        /// <summary>
        /// adds experience points to the player and fully heals them
        /// if enough XP is accumulated, triggers a level up
        /// returns true if a level up occurred, false otherwise. Used by the UI to show a notification
        /// </summary>
        public bool GainXP(float amount)
        {
            CurrentXP += amount;
            CurrentHealth = MaxHealth; // full heal after every battle

            if (CurrentXP >= XPToNextLevel)
            {
                LevelUp();
                return true;
            }
            return false;
        }

        /// <summary>
        /// increments the player's level, adjusts XP threshold, and grants skill points
        /// called internally by GainXP() when enough XP is accumulated
        /// </summary>
        private void LevelUp()
        {
            Level++;
            CurrentXP -= XPToNextLevel;
            XPToNextLevel *= 1.25f; // each level needs 25% more XP
            SkillPoints += 3;       // 3 skill points per level to invest via FireKeeper
            MaxHealth += 10;        // base health increases each level
        }

        /// <summary>
        /// adds an item to the player's inventory
        /// if the item already exists, increments its quantity instead of adding a duplicate
        /// </summary>
        public void AddItem(Item item)
        {
            var existing = Inventory.Find(i => i.Name == item.Name);
            if (existing != null) existing.Quantity++;
            else Inventory.Add(item);
        }

        /// <summary>
        /// Attack logic for player
        /// calculates and deals damage to the target enemy
        /// 15% chance to land a critical hit at 1.5x damage
        /// has a higher base damage returned from attack compared to enemies
        /// </summary>
        public double Attack(Enemy enemy)
        {
            // Numbers generated are higher for the player
            int damage = random.Next((int)(CurrentDamage * 0.8), (int)(CurrentDamage * 1.5));
            // checks if damage is greater than health, if so, the enemy of this object dies
            if (damage >= enemy.CurrentHealth)
            {
                enemy.Die();
            }
            else
                enemy.CurrentHealth -= damage; // reduces the boss health by the damage generated
            return damage; // returns damage to update display
        }
    }
}