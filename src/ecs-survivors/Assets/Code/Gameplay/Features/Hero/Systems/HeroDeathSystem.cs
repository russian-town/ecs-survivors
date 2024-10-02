﻿using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class HeroDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public HeroDeathSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Dead,
                    GameMatcher.HeroAnimator,
                    GameMatcher.ProccesingDeath));
        }

        public void Execute()
        {
            foreach (var hero in _heroes)
            {
                hero.isMovementAvailable = false;
                hero.isTurnedAlongDirection = false;
                hero.HeroAnimator.PlayDied();
            }
        }
    }
}