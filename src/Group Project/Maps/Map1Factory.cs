using System;
using System.Collections.Generic;
using System.Linq;

// Builder class for scaffolding game maps

namespace Group_Project {

    public static class Map1Factory {

        public static GameMap BuildMap1()
        {

            // create map and populate with enemies, NPCs, items, and sections
            GameMap map1 = new GameMap("Map1");

            // [ENEMY] Regenerator
            Enemy regenerator = MapEntityFactory.CreateEnemy(
                "Regenerator",
                75,
                10,
                20,
                false,
                @"assets\img\Npcs\Hostiles\Regenerator\Regenerator_SpriteIcon.png",
                @"assets\img\Npcs\Hostiles\Regenerator\Regenerator_InteractionIcon.png",
                @"assets\sounds\npcs\Hostiles\Regenerator\Regenerator_EnemyDeath.wav",
                @"assets\sounds\npcs\Hostiles\Regenerator\Regenerator_EnemyCriticalHit.wav");

            // [ENEMY] Dr. Salvador
            Enemy drSalvador = MapEntityFactory.CreateEnemy(
                "DrSalvador",
                100,
                30,
                30,
                false,
                @"assets\img\Npcs\Hostiles\DrSalvador\DrSalvador_SpriteIcon.jpg",
                @"assets\img\Npcs\Hostiles\DrSalvador\DrSalvador_InteractionIcon.png",
                @"assets\sounds\npcs\Hostiles\DrSalvador\DrSalvador_EnemyDeath.wav",
                @"assets\sounds\npcs\Hostiles\DrSalvador\DrSalvador_EnemyCriticalHit.wav");

            // [ENEMY] BigDaddy
            Enemy bigDaddy = MapEntityFactory.CreateEnemy(
                "BigDaddy",
                200,
                7.5,
                30,
                false,
                @"assets\img\Npcs\Hostiles\BigDaddy\BigDaddy_SpriteIcon.png",
                @"assets\img\Npcs\Hostiles\BigDaddy\BigDaddy_InteractionIcon.png",
                @"assets\sounds\npcs\Hostiles\BigDaddy\BigDaddy_EnemyDeath.wav",
                @"assets\sounds\npcs\Hostiles\BigDaddy\BigDaddy_EnemyCriticalHit.wav");

            // [BOSS] Nemesis
            Enemy nemesis = MapEntityFactory.CreateEnemy(
                "Nemesis",
                500,
                25,
                50,
                true,
                @"assets\img\Npcs\Hostiles\Nemesis\Nemesis_SpriteIcon.png",
                @"assets\img\Npcs\Hostiles\Nemesis\Nemesis_InteractionIcon.png",
                @"assets\sounds\npcs\Hostiles\Nemesis\Nemesis_EnemyDeath.wav",
                @"assets\sounds\npcs\Hostiles\Nemesis\Nemesis_EnemyCriticalHit.wav");

            // add enemies to map
            map1.MapHostiles.Add(regenerator);
            map1.MapHostiles.Add(drSalvador);
            map1.MapHostiles.Add(bigDaddy);
            map1.MapHostiles.Add(nemesis);

            // [NPC] FireKeeper
            FriendlyNPC fireKeeper = MapEntityFactory.CreateNpc(
                "FireKeeper",
                @"assets\img\Npcs\NPCs\FireKeeper\FireKeeper_SpriteIcon.png",
                @"assets\img\Npcs\NPCs\FireKeeper\FireKeeper_InteractionIcon.png");

            // [NPC] Siegward
            FriendlyNPC siegward = MapEntityFactory.CreateNpc(
                "Siegward",
                @"assets\img\Npcs\RecruitableNpcs\Siegward\Siegward_SpriteIcon.jpg",
                @"assets\img\Npcs\RecruitableNpcs\Siegward\Siegward_InteractionIcon.jpg",
                "Siegbrau");

            // [NPC] Solaire
            FriendlyNPC solaire = MapEntityFactory.CreateNpc(
                "Solaire",
                @"assets\img\Npcs\RecruitableNpcs\Solaire\Solaire_SpriteIcon.png",
                @"assets\img\Npcs\RecruitableNpcs\Solaire\Solaire_InteractionIcon.png",
                null);

            // add NPCs to map
            map1.MapNPCs.Add(fireKeeper);
            map1.MapNPCs.Add(siegward);
            map1.MapNPCs.Add(solaire);

            // instantiate + add items to map
            Item firstAidSpray = MapEntityFactory.CreateItem(
                "First Aid Spray",
                "Restores Health",
                "A single-use item that fully restores the player's health when used in combat.",
                @"assets\img\MapItems\assets_img_MapItems_FirstAidSpray.png",
                2);

            Item siegbrau = MapEntityFactory.CreateItem(
                "Siegbrau",
                "A warm drink for Siegward.",
                "Give to Siegward to recruit him.",
                "PLACEHOLDER PATHING",
                1);

            map1.MapItems.Add(firstAidSpray);
            map1.MapItems.Add(siegbrau);

            // Section 1 scaffolding
            Section m1_Section1 = new Section("main", "Map 1 - Section 1");


            // [ITEM] First Aid Spray
            MapEntityFactory.AddTile(m1_Section1, 5, 5, TileType.Item, firstAidSpray,
                @"assets\img\MapItems\assets_img_MapItems_FirstAidSpray.png");

            // [NPC] FireKeeper
            MapEntityFactory.AddTile(m1_Section1, 3, 5, TileType.LevelUp, fireKeeper,
                @"assets\img\Npcs\NPCs\FireKeeper\FireKeeper_SpriteIcon.png");

            // [ENEMY] Dr. Salvador
            MapEntityFactory.AddTile(m1_Section1, 1, 2, TileType.Enemy, drSalvador,
                @"assets\img\Npcs\Hostiles\DrSalvador\DrSalvador_SpriteIcon.jpg");

            // [ENEMY] Regenerator
            MapEntityFactory.AddTile(m1_Section1, 4, 1, TileType.Enemy, regenerator,
                @"assets\img\Npcs\Hostiles\Regenerator\Regenerator_SpriteIcon.png");

            // [INVENTORY]
            MapEntityFactory.AddTile(m1_Section1, 3, 3, TileType.Inventory, null,
                "PLACEHOLDER");

            // [ARROW] leads to Section 2
            MapEntityFactory.AddTile(m1_Section1, 3, 0, TileType.ArrowLeft,
                imagePath: "PLACEHOLDER", destinationSectionId: "left"); // index of LeftSection


            // Section 2 scaffolding
            Section m1_Section2 = new Section("left", "Map 1 - Section 2");

            // [NPC] Siegward
            MapEntityFactory.AddTile(m1_Section2, 2, 4, TileType.FriendlyNPC, siegward,
                @"assets\img\Npcs\RecruitableNpcs\Siegward\Siegward_SpriteIcon.jpg");

            // [ITEM] Siegbrau
            MapEntityFactory.AddTile(m1_Section2, 5, 1, TileType.Item, siegbrau,
                "PLACEHOLDER PATHING");

            // [ENEMY] BigDaddy
            MapEntityFactory.AddTile(m1_Section2, 1, 1, TileType.Enemy, bigDaddy,
                @"assets\img\Npcs\Hostiles\BigDaddy\BigDaddy_SpriteIcon.png");

            // [INVENTORY]
            MapEntityFactory.AddTile(m1_Section2, 3, 3, TileType.Inventory, null,
                "PLACEHOLDER");

            // [ARROW] leads back to Section 1
            MapEntityFactory.AddTile(m1_Section2, 3, 6, TileType.ArrowRight,
                imagePath: "PLACEHOLDER", destinationSectionId: "main"); // index of MainSection

            // [ARROW] leads to Section 3
            MapEntityFactory.AddTile(m1_Section2, 0, 0, TileType.ArrowUp,
                imagePath: "PLACEHOLDER", destinationSectionId: "up"); // index of section 3


            // section 3 scaffolding
            Section m1_Section3 = new Section("up", "Map 1 - Section 3");

            // [NPC] Solaire
            MapEntityFactory.AddTile(m1_Section3, 6, 2, TileType.FriendlyNPC, solaire,
                @"assets\img\Npcs\RecruitableNpcs\Solaire\Solaire_SpriteIcon.png");

            // [INVENTORY]
            MapEntityFactory.AddTile(m1_Section3, 2, 0, TileType.Inventory, null,
                "PLACEHOLDER");

            // [BOSS] Nemesis
            MapEntityFactory.AddTile(m1_Section3, 1, 5, TileType.Boss, nemesis,
                @"assets\img\Npcs\Hostiles\Nemesis\Nemesis_SpriteIcon.png");

            // [ARROW] leads back to Section 2
            MapEntityFactory.AddTile(m1_Section3, 6, 0, TileType.ArrowDown,
                imagePath: "PLACEHOLDER", destinationSectionId: "left"); //



            // Dictionary to hold sections
            Dictionary<string, Section> sections = new Dictionary<string, Section>
            {
                { "main", m1_Section1 },
                { "left", m1_Section2 },
                { "up", m1_Section3 }
            };


            // populate map with sections
            map1.LoadMap(sections);

            return map1;

        }
    }
}
