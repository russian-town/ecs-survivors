using Code.Gameplay.Features.Hero.Systems.StatusVisuals;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class StatusVisualFeature : Feature
    {
        public StatusVisualFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyPoisonVisualsSystem>());
            Add(systems.Create<UnapplyPoisonVisualsSystem>());
        }
    }
}