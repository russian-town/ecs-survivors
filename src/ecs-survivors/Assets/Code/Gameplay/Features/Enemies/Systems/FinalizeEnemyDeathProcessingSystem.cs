using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class FinalizeEnemyDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(128);

        public FinalizeEnemyDeathProcessingSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Dead,
                    GameMatcher.ProccesingDeath));
        }

        public void Execute()
        {
            foreach (var enemy in _enemies.GetEntities(_buffer))
            {
                enemy.isProccesingDeath = false;
            }
        }
    }
}