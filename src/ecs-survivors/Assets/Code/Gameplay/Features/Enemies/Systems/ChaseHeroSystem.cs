using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class ChaseHeroSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public ChaseHeroSystem(ITimeService timeService, GameContext gameContext)
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
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var hero in _heroes)
            foreach (var enemy in _enemies)
            {
                enemy.ReplaceDirection((hero.WorldPosition - enemy.WorldPosition).normalized);
                enemy.isMoving = true;
            }
        }
    }
}