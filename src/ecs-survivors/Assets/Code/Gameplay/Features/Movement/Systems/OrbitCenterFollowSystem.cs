﻿using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class OrbitCenterFollowSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _orbitCenters;
        private readonly IGroup<GameEntity> _targets;

        public OrbitCenterFollowSystem(GameContext game)
        {
            _orbitCenters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.OrbitCenterPosition,
                    GameMatcher.OrbitFollowTarget));
            
            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var orbitCenter in _orbitCenters)
            foreach (var target in _targets)
            {
                if (orbitCenter.OrbitFollowTarget == target.Id)
                    orbitCenter.ReplaceOrbitCenterPosition(target.WorldPosition);
            }
        }
    }
}