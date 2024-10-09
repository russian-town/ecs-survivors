using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Cooldowns.Systems
{
    public class CooldownSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _cooldownables;
        private readonly List<GameEntity> _buffer = new(32);

        public CooldownSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _cooldownables = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Cooldown,
                    GameMatcher.CooldownLeft));
        }

        public void Execute()
        {
            foreach (var cooldownable in _cooldownables.GetEntities(_buffer))
            {
                cooldownable.ReplaceCooldownLeft(cooldownable.CooldownLeft - _timeService.DeltaTime);

                if (cooldownable.CooldownLeft <= 0)
                {
                    cooldownable.isCooldownUp = true;
                    cooldownable.RemoveCooldownLeft();
                }
            }
        }
    }
}