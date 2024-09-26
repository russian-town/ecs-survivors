using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyFollowHeroSystem : IExecuteSystem

    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public EnemyFollowHeroSystem(ITimeService timeService, GameContext gameContext)
        {
            _timeService = timeService;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition));
            _enemies = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Speed,
                    GameMatcher.Distance,
                    GameMatcher.TargetDistance,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var enemy in _enemies)
            foreach (var hero in _heroes)
            {
                if (enemy.Distance > enemy.TargetDistance)
                {
                    float step = enemy.Speed * _timeService.DeltaTime;
                    Vector3 targetPosition = Vector3.Lerp(enemy.WorldPosition, hero.WorldPosition, step);
                    enemy.ReplaceWorldPosition(targetPosition);
                }
            }
        }
    }
}