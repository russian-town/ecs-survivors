﻿using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public class CalculateGoldGainSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<MetaEntity> _boosters;
        private readonly IGroup<MetaEntity> _storages;

        public CalculateGoldGainSystem(MetaContext meta, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            
            _boosters = meta.GetGroup(MetaMatcher.GoldGainBoost);
            _storages = meta.GetGroup(
                MetaMatcher
                    .AllOf(
                        MetaMatcher.GoldGainBoost,
                        MetaMatcher.GoldPerSecond
                    ));
        }

        public void Execute()
        {
            foreach (var storage in _storages)
            {
                var gainBonus = 1f;

                foreach (var booster in _boosters)
                    gainBonus += booster.GoldGainBoost;

                storage.ReplaceGoldPerSecond(_staticDataService.AfkGain.GoldPerSeconds * gainBonus);
            }
        }
    }
}
