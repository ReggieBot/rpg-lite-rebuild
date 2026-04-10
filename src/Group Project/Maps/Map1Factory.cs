using System;
using System.Collections.Generic;
using System.Linq;

// Builder class for scaffolding game maps

namespace Group_Project {

    public static class MapFactory {

        // helper method for building tiles
        private static Tile MakeTile(int row, int col, TileType type, string entityName = null,
            string imagePath = null, int destination = -1) {
                Tile tile = new Tile(row, col, type);
                tile.EntityName = entityName;
                tile.ImagePath = imagePath;
                tile.DestinationSectionIndex = destination;
                return tile;
        }

        public static GameMap BuildMap1() {

            // create map and populate with enemies, NPCs, items, and sections
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

            // instantiate + add items to map
            Item firstAidSpray = new Item
            ("First Aid Spray",
            "Restores Health",
            "A single-use item that fully restores the player's health when used in combat.",
            @"assets\img\MapItems\assets_img_MapItems_FirstAidSpray.png",
            2);

            Item siegbrau = new Item
            ("Siegbrau",
            "A warm drink for Siegward.",
            "Give to Siegward to recruit him.",
            "PLACEHOLDER PATHING",
            1
            );

            map1.MapItems.Add(firstAidSpray);
            map1.MapItems.Add(siegbrau);

            // Section 1 scaffolding
            Section m1_Section1 = new Section("Map 1 - Section 1");

            /*

            From what I can see, the 'Section' constructor creates an empty dictionary.
            First we need to instantiate a tile, the tile constructor expects the following parameters:
            - Row
            - Column
            - TileType (enum in TileType.cs)

            Once instantiated, we need to add that tile to the sections dictionary
            The dictionary doesn't expect row/column from the looks of it. It expects a single tile position
            The tile position is calculated using the following formula (Row * 7 + Col), assuming 0-based indexing.

            That calculated location becomes the Section dictionary key, and the value is the Tile object we created.
            So we are storing tile location twice, in the tile itself, and in the section dictionary.
            Though they both use different formats of location data

            Whatever we don't explicitly add to the section's tile dict will default to null.
            I'm assuming we are going to treat null tiles as empty spaces that are walkable, but have no interaction.

             */

            // [ITEM] First Aid Spray
            m1_Section1.Tiles.Add(40, MakeTile(5, 5, TileType.Item, "First Aid Spray",
                @"assets\img\MapItems\assets_img_MapItems_FirstAidSpray.png"));

            // [NPC] FireKeeper
            m1_Section1.Tiles.Add(26, MakeTile(3, 5, TileType.LevelUp, "FireKeeper",
                @"assets\img\Npcs\NPCs\FireKeeper\FireKeeper_SpriteIcon.png"));

            // [ENEMY] Dr. Salvador
            m1_Section1.Tiles.Add(9, MakeTile(1, 2, TileType.Enemy, "DrSalvador",
                @"assets\img\Npcs\Hostiles\DrSalvador\DrSalvador_SpriteIcon.jpg"));

            // [ENEMY] Regenerator
            m1_Section1.Tiles.Add(29, MakeTile(4, 1, TileType.Enemy, "Regenerator",
                @"assets\img\Npcs\Hostiles\Regenerator\Regenerator_SpriteIcon.png"));

            // [INVENTORY]
            m1_Section1.Tiles.Add(24, MakeTile(3, 3, TileType.Inventory, "Inventory",
                "PLACEHOLDER"));

            // [ARROW] leads to Section 2
            m1_Section1.Tiles.Add(21, MakeTile(3, 0, TileType.ArrowLeft,
                imagePath: "PLACEHOLDER", destination: 1)); // index of LeftSection




        }

        public static GameMap BuildMap2() {

        }

        public static GameMap BuildMap3() {

        }
    }
}
