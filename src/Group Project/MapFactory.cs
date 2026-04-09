using System;
using System.Collections.Generic;
using System.Linq;

// Builder class for scaffolding game maps

namespace Group_Project {

    public static class MapFactory {

        public static GameMap BuildMap1() {
            GameMap map1 = new GameMap("Map 1");

            // [ENEMY] Regenerator
            Enemy regenerator = new Enemy("Regenerator", 75, 10, 20, false);
            // pathing for assets
            regenerator.SpriteIconPath =
            @"assets\img\Npcs\Hostiles\Regenerator\Regenerator_SpriteIcon.png";
            regenerator.InteractionIconPath =
            @"assets\img\Npcs\Hostiles\Regenerator\Regenerator_InteractionIcon.png";
            regenerator.DeathSoundPath =
            @"assets\sounds\npcs\Hostiles\Regenerator\Regenerator_EnemyDeath.wav";
            regenerator.CriticalHitSoundPath =
            @"assets\sounds\npcs\Hostiles\Regenerator\Regenerator_EnemyCriticalHit.wav";

            // [ENEMY] Dr. Salvador
            Enemy drSalvador = new Enemy("DrSalvador", 100, 30, 30, false);
            // pathing for assets
            drSalvador.SpriteIconPath =
            @"assets\img\Npcs\Hostiles\DrSalvador\DrSalvador_SpriteIcon.jpg";
            drSalvador.InteractionIconPath =
            @"assets\img\Npcs\Hostiles\DrSalvador\DrSalvador_InteractionIcon.png";
            drSalvador.DeathSoundPath =
            @"assets\sounds\npcs\Hostiles\DrSalvador\DrSalvador_EnemyDeath.wav";
            drSalvador.CriticalHitSoundPath =
            @"assets\sounds\npcs\Hostiles\DrSalvador\DrSalvador_EnemyCriticalHit.wav";

            // [ENEMY] BigDaddy
            Enemy bigDaddy = new Enemy("BigDaddy", 200, 7.5, 30, false);
            // pathing for assets
            bigDaddy.SpriteIconPath =
            @"assets\img\Npcs\Hostiles\BigDaddy\BigDaddy_SpriteIcon.png";
            bigDaddy.InteractionIconPath =
            @"assets\img\Npcs\Hostiles\BigDaddy\BigDaddy_InteractionIcon.png";
            bigDaddy.DeathSoundPath =
            @"assets\sounds\npcs\Hostiles\BigDaddy\BigDaddy_EnemyDeath.wav";
            bigDaddy.CriticalHitSoundPath =
            @"assets\sounds\npcs\Hostiles\BigDaddy\BigDaddy_EnemyCriticalHit.wav";

            // [BOSS] Nemesis
            Enemy nemesis = new Enemy("Nemesis", 500, 25, 50, true);
            // pathing for assets
            nemesis.SpriteIconPath =
            @"assets\img\Npcs\Hostiles\Nemesis\Nemesis_SpriteIcon.png";
            nemesis.InteractionIconPath =
            @"assets\img\Npcs\Hostiles\Nemesis\Nemesis_InteractionIcon.png";
            nemesis.DeathSoundPath =
            @"assets\sounds\npcs\Hostiles\Nemesis\Nemesis_EnemyDeath.wav";
            nemesis.CriticalHitSoundPath =
            @"assets\sounds\npcs\Hostiles\Nemesis\Nemesis_EnemyCriticalHit.wav";

            // add enemies to map
            map1.MapHostiles.Add(regenerator);
            map1.MapHostiles.Add(drSalvador);
            map1.MapHostiles.Add(bigDaddy);
            map1.MapHostiles.Add(nemesis);

            // [NPC] FireKeeper
            FriendlyNPC fireKeeper = new FriendlyNPC("FireKeeper");
            // pathing for assets
            fireKeeper.SpriteIconPath =
            @"assets\img\Npcs\NPCs\FireKeeper\FireKeeper_SpriteIcon.png";
            fireKeeper.InteractionIconPath =
            @"assets\img\Npcs\NPCs\FireKeeper\FireKeeper_InteractionIcon.png";
            fireKeeper.RequiredItem = null;

            // [NPC] Siegward
            FriendlyNPC siegward = new FriendlyNPC("Siegward");
            // pathing for assets
            siegward.SpriteIconPath =
            @"assets\img\Npcs\RecruitableNpcs\Siegward\Siegward_SpriteIcon.jpg";
            siegward.InteractionIconPath =
            @"assets\img\Npcs\RecruitableNpcs\Siegward\Siegward_InteractionIcon.jpg";
            siegward.RequiredItem = "Siegbrau";

            // [NPC] Solaire
            FriendlyNPC solaire = new FriendlyNPC("Solaire");
            // pathing for assets
            solaire.SpriteIconPath =
            @"assets\img\Npcs\RecruitableNpcs\Solaire\Solaire_SpriteIcon.png";
            solaire.InteractionIconPath =
            @"assets\img\Npcs\RecruitableNpcs\Solaire\Solaire_InteractionIcon.png";
            solaire.RequiredItem = "Sunlight Medal";

            // add NPCs to map
            map1.MapNPCs.Add(fireKeeper);
            map1.MapNPCs.Add(siegward);
            map1.MapNPCs.Add(solaire);

        }

        public static GameMap BuildMap2() {

        }

        public static GameMap BuildMap3() {

        }
    }
}
