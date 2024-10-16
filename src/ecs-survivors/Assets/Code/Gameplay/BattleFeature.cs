﻿using Code.Common.Destruct;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Lifetime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<BindViewFeature>());
            Add(systemFactory.Create<HeroFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<DeathFeature>());
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<AbilityFeature>());
            Add(systemFactory.Create<ArmamentFeature>());
            Add(systemFactory.Create<CollectTargetsFeature>());
            Add(systemFactory.Create<EffectApplicationFeature>());
            Add(systemFactory.Create<EnchantFeature>());
            Add(systemFactory.Create<EffectFeature>());
            Add(systemFactory.Create<StatusFeature>());
            Add(systemFactory.Create<StatsFeature>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}