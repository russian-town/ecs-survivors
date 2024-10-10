﻿using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public sealed class StatusFeature : Feature
    {
        public StatusFeature(ISystemFactory systems)
        {
            Add(systems.Create<StatusDurationSystem>());
            Add(systems.Create<PeriodicDamageStatusSystem>());
            Add(systems.Create<StatusVisualFeature>());
            Add(systems.Create<CleanupUnappliedStatuses>());
        }
    }
}