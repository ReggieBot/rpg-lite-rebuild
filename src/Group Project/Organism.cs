using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// Abstract base class for all living entities in the game.
    /// Demonstrates the Template Method pattern — subclasses (Player, Enemy)
    /// overrideable abstract Die() method with their own behavior for enemy and player
    /// </summary>
    public abstract class Organism
    {
        // the displayed name of the organism
        public string Name { get; set; }

        // the maximum health the organism can have. Protected set to prevent external modification
        public double MaxHealth { get; protected set; }

        // the current health of the organism. Reaching 0 triggers Die()
        public double CurrentHealth { get; set; }

        // the base damage value. does not change during combat
        public double MaxDamage { get; set; }

        // the active damage value. Can be modified by buffs/debuffs during combat
        public double CurrentDamage { get; set; }

        // the current level of the organism. Affects stats for the player, used for scaling on enemies 
        public byte Level { get; set; }

        // returns true if CurrentHealth is greater than 0 
        public bool IsAlive => CurrentHealth > 0;

        /// <summary>
        /// protected constructor — can only be called by subclasses
        /// initializes all stats and sets current values equal to max values
        /// </summary>
        protected Organism(string name, double maxHealth, double damage)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            MaxDamage = damage;
            CurrentDamage = damage;
        }

        /// <summary>
        /// abstract method that defines what happens when the organism's health reaches 0
        /// player overrides this to trigger game over. Enemy overrides this to play death sound
        /// </summary>
        public abstract void Die();
    }
}