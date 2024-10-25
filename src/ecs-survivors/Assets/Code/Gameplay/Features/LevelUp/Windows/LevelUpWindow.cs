﻿using Code.Common.Entity;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
    public class LevelUpWindow : BaseWindow
    {
        public Transform AbilityLayout;

        private IAbilityUIFactory _factory;
        private IAbilityUpgradeService _abilityUpgradeService;
        private IStaticDataService _staticData;
        private IWindowService _windowService;

        [Inject]
        public void Construct(
            IAbilityUIFactory factory,
            IAbilityUpgradeService abilityUpgradeService,
            IStaticDataService staticData,
            IWindowService windowService)
        {
            Id = WindowId.LevelUpWindow;
            _factory = factory;
            _abilityUpgradeService = abilityUpgradeService;
            _staticData = staticData;
            _windowService = windowService;
        }

        protected override void Initialize()
        {
            foreach (var upgradeOption in _abilityUpgradeService.GetUpgradeOptions())
            {
                var abilityLevel =
                    _staticData.GetAbilityLevel(upgradeOption.Id, upgradeOption.Level);

                _factory.CreateAbilityCard(AbilityLayout)
                    .Setup(upgradeOption.Id, abilityLevel, OnSelected);
            }
        }

        private void OnSelected(AbilityId id)
        {
            CreateEntity.Empty()
                .AddAbilityId(id)
                .isUpgradeRequest = true;
            
            _windowService.Close(Id);
        }
    }
}
