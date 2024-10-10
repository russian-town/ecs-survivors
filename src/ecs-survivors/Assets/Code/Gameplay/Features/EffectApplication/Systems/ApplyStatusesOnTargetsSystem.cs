using Code.Common.Extensions;
using Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
    public class ApplyStatusesOnTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IStatusApplier _statusApplier;
        private readonly IGroup<GameEntity> _entities;

        public ApplyStatusesOnTargetsSystem(GameContext gameContext, IStatusApplier statusApplier)
        {
            _gameContext = gameContext;
            _statusApplier = statusApplier;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.StatusSetups));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            foreach (var targetId in entity.TargetsBuffer)
            foreach (var setup in entity.StatusSetups)
            {
                _statusApplier.ApplyStatus(setup, ProducerId(entity), targetId);
            }
        }

        private static int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}