﻿using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.LevelUp;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityId, AbilityConfig> _abilityById;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;
        private Dictionary<LootTypeId, LootConfig> _lootById;
        private Dictionary<WindowId, GameObject> _windowPrefabsById;
        private LevelUpConfig _levelUp;

        public void LoadAll()
        {
            LoadAbilities();
            LoadEnchants();
            LoadLoot();
            LoadWindows();
            LoadLevelUpRules();
        }

        public AbilityConfig GetAbilityConfig(AbilityId abilityId)
        {
            if (_abilityById.TryGetValue(abilityId, out var config))
                return config;

            throw new Exception($"Ability config for {abilityId} was not found.");
        }

        public EnchantConfig GetEnchantConfig(EnchantTypeId typeId)
        {
            if (_enchantById.TryGetValue(typeId, out var config))
                return config;

            throw new Exception($"Enchant config for {typeId} was not found.");
        }

        public LootConfig GetLootConfig(LootTypeId typeId)
        {
            if (_lootById.TryGetValue(typeId, out var config))
                return config;

            throw new Exception($"Loot config for {typeId} was not found.");
        }

        public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
        {
            var config = GetAbilityConfig(abilityId);

            if (level > config.Levels.Count)
                level = config.Levels.Count;

            return config.Levels[level - 1];
        }

        public GameObject GetWindowPrefab(WindowId id) =>
            _windowPrefabsById.TryGetValue(id, out GameObject prefab)
                ? prefab
                : throw new Exception($"Prefab config for window {id} was not found");

        public int MaxLevel() =>
            _levelUp.MaxLevel;

        public float ExperienceForLevel(int level) =>
            _levelUp.ExperienceForLevel[level];
        
        private void LoadAbilities()
        {
            _abilityById = Resources
                .LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityId, x => x);
        }

        private void LoadEnchants()
        {
            _enchantById = Resources
                .LoadAll<EnchantConfig>("Configs/Enchants")
                .ToDictionary(x => x.TypeId, x => x);
        }

        private void LoadLoot()
        {
            _lootById = Resources
                .LoadAll<LootConfig>("Configs/Loot")
                .ToDictionary(x => x.TypeId, x => x);
        }

        private void LoadWindows()
        {
            _windowPrefabsById = Resources
                .Load<WindowsConfig>("Configs/Windows/windowsConfig")
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }

        private void LoadLevelUpRules() =>
            _levelUp = Resources.Load<LevelUpConfig>("Configs/LevelUp/LevelUpConfig");
    }
}