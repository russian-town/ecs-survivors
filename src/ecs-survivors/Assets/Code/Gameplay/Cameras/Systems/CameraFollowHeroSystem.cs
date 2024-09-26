﻿using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Entitas;

namespace Code.Gameplay.Cameras.Systems
{
    public class CameraFollowHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly ICameraProvider _cameraProvider;

        public CameraFollowHeroSystem(GameContext gameContext, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var hero in _heroes)
            {
                _cameraProvider.MainCamera.transform.SetWorldXY(hero.WorldPosition.x, hero.WorldPosition.y);
            }
        }
    }
}