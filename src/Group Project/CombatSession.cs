using System;
using System.Collections.Generic;

namespace Group_Project
{
    // one single fight between current player and one enemy
    // shouldn't know about maps, tiles, section, winforms, etc.
    // should only run combat rounds and track the result
    public class CombatSession
    {
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }

        public bool CombatFinished { get; private set; }
        public bool PlayerWon { get; private set; }
        public bool PlayerDied { get; private set; }

        public CombatSession(Player player, Enemy enemy)
        {
            Player = player;
            Enemy = enemy;
            CombatFinished = false;
            PlayerWon = false;
            PlayerDied = false;
        }

        public string ProcessRound()
        {
            // if fight is over don't allow more turns
            if (CombatFinished)
            {
                return "Combat is over";
            }

            double playerDamage = Player.Attack(Enemy);

            if (!Enemy.IsAlive)
            {
                CombatFinished = true;
                PlayerWon = true;

                return Player.Name + " dealt" + (int)playerDamage +
                       " damage and defeated " + Enemy.Name;
            }

            double enemyDamage = Enemy.Attack(Player);

            // if player died from enemy's counter attack then end fight now
            if (!Player.IsAlive)
            {
                CombatFinished = true;
                PlayerDied = true;

                return Enemy.Name + " dealt" + (int)enemyDamage +
                       " damage and defeated you";
            }

            // if both are still alive then report the full round (summary?)
            return Player.Name + " dealt" + (int)playerDamage + " damage." +
                   Environment.NewLine +
                   Enemy.Name + " dealt" + (int)enemyDamage + " damage";
        }
    }
}
