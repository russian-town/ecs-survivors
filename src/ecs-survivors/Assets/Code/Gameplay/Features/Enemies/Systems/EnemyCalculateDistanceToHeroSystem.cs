using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyCalculateDistanceToHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public EnemyCalculateDistanceToHeroSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition));
            _enemies = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Distance,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var enemy in _enemies)
            foreach (var hero in _heroes)
            {
                enemy.ReplaceDistance(Vector3.Distance(enemy.WorldPosition, hero.WorldPosition));
            }
        }
    }
}