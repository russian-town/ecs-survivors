using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class RotateAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public RotateAlongDirectionSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.Direction,
                    GameMatcher.RotateAlignedAlongDirection));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                if (entity.Direction.sqrMagnitude >= .01f)
                {
                    float angle = Mathf.Atan2(entity.Direction.y, entity.Direction.x) * Mathf.Rad2Deg;
                    entity.Transform.rotation = Quaternion.Euler(0f, 0f, angle);
                }
            }
        }
    }
}