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
    }
}
