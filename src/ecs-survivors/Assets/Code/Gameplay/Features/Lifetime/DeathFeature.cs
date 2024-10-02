﻿using Code.Gameplay.Features.Lifetime.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime
{
    public class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkDeadSystem>());
        }
    }
}