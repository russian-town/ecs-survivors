﻿using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentFactory : IArmamentFactory
    {
        private const int TargetBufferSize = 16;

        private readonly IIdentifierService _identifiers;
        private IStaticDataService _staticDataService;

        public ArmamentFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateVegetableBolt(int level, Vector3 at)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
            var setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                .With(x => x.isRotateAlignedAlongDirection = true)
                .AddParentAbility(AbilityId.VegetableBolt);
        }

        public GameEntity CreateMushroom(int level, Vector3 at, float phase)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
            var setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                .AddParentAbility(AbilityId.OrbitingMushroom)
                .AddOrbitPhase(phase)
                .AddOrbitRadius(setup.OrbitRadius);
        }

        public GameEntity CreateEffectAura(AbilityId parentAbilityId, int producerId, int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.GarlicAura, level);
            var setup = abilityLevel.AuraSetup;

            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddParentAbility(parentAbilityId)
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .AddRadius(setup.Radius)
                .AddCollectTargetsInterval(setup.Interval)
                .AddCollectTargetsTimer(0f)
                .AddTargetsBuffer(new List<int>(TargetBufferSize))
                .With(x => x.AddEffectSetups(abilityLevel.EffectSetups),
                    when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(abilityLevel.StatusSetups),
                    when: !abilityLevel.StatusSetups.IsNullOrEmpty())
                .AddProducerId(producerId)
                .AddWorldPosition(Vector3.zero)
                .With(x => x.isFollowingProducer = true);
        }

        private GameEntity CreateProjectileEntity(Vector3 at, AbilityLevel abilityLevel, ProjectileSetup setup)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .With(x => x.isArmament = true)
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .AddWorldPosition(at)
                .AddSpeed(setup.Speed)
                .With(x => x.AddEffectSetups(abilityLevel.EffectSetups),
                    when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(abilityLevel.StatusSetups),
                    when: !abilityLevel.StatusSetups.IsNullOrEmpty())
                .With(x => x.AddTargetLimit(setup.Pierce), when: setup.Pierce > 0)
                .AddRadius(setup.ContactRadius)
                .AddTargetsBuffer(new List<int>(TargetBufferSize))
                .AddProcessedTargets(new List<int>(TargetBufferSize))
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContinuously = true)
                .AddSelfDestructTimer(setup.Lifetime);
        }

        public GameEntity CreateExplosion(int producerId, Vector3 at)
        {
            var config = _staticDataService.GetEnchantConfig(EnchantTypeId.ExplosiveArmaments);
            
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .AddRadius(config.Radius)
                .AddTargetsBuffer(new List<int>(TargetBufferSize))
                .With(x => x.AddEffectSetups(config.EffectSetups),
                    when: !config.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(config.StatusSetups),
                    when: !config.StatusSetups.IsNullOrEmpty())
                .AddViewPrefab(config.ViewPrefab)
                .AddProducerId(producerId)
                .AddWorldPosition(at)
                .With(x => x.isReadyToCollectTargets = true)
                .AddSelfDestructTimer(1);
        }
    }
}