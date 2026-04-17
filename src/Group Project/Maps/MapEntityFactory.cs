using System;
using System.Collections.Generic;
using System.Linq;

// Factory class containing helper methods to create map entities
// Sections, tiles, enemies, NPCs, and items
// These methods are then called in the MapFactory classes
// Created to avoid cluttering the MapFactory classes with repeated code for creating entities

namespace Group_Project {
    internal static class MapEntityFactory
    {

        // Create new tile instance with the specified properties
        internal static Tile CreateTile(int row, int col, TileType type, IMapEntity entity,
            string imagePath = null, string destinationSectionId = null)
        {
            Tile tile = new Tile(row, col, type);
            tile.Entity = entity;
            tile.ImagePath = imagePath;
            tile.DestinationSectionId = destinationSectionId;
            return tile;
        }

        // Add tiles to section
        // Section now owns tile placement through its 2D grid
        // section.SetTile(tile) now tells 'Section' to place it
        // Factory now knows less about section storage and relies on added abstraction
        internal static void AddTile(
            Section section,
            int row,
            int col,
            TileType type,
            IMapEntity entity = null,
            string imagePath = null,
            string destinationSectionId = null)
        {

            Tile tile = CreateTile(row, col, type, entity, imagePath, destinationSectionId);
            section.SetTile(tile);
        }

        // Create Enemy instance
        internal static Enemy CreateEnemy(
            string name,
            double maxHealth,
            double damage,
            float xpReward,
            bool isBoss,
            string spritePath,
            string interactionPath,
            string deathSoundPath,
            string criticalHitSoundPath)
        {
            Enemy enemy = new Enemy(name, maxHealth, damage, xpReward, isBoss);
            enemy.SpriteIconPath = spritePath;
            enemy.InteractionIconPath = interactionPath;
            enemy.DeathSoundPath = deathSoundPath;
            enemy.CriticalHitSoundPath = criticalHitSoundPath;
            return enemy;
        }

        // Create FriendlyNPC instance
        internal static FriendlyNPC CreateNpc(
            string name,
            string spritePath,
            string interactionPath,
            string requiredItem = null)
        {
            FriendlyNPC npc = new FriendlyNPC(name);
            npc.SpriteIconPath = spritePath;
            npc.InteractionIconPath = interactionPath;
            npc.RequiredItem = requiredItem;
            return npc;
        }

        // create Item instance
        internal static Item CreateItem(
            string name,
            string description,
            string usageInfo,
            string imagePath,
            byte quantity = 1)
        {
            Item item = new Item(name, description, usageInfo, imagePath, quantity);
            return item;
        }
    }
}
