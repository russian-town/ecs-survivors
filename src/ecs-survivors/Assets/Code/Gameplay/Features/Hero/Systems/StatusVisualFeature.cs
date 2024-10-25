using Code.Gameplay.Features.Enchants.Systems;
using Code.Gameplay.Features.Hero.Systems.StatusVisuals;
using Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class StatusVisualFeature : Feature
    {
        public StatusVisualFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyPoisonVisualsSystem>());
            Add(systems.Create<ApplyFreezeStatusSystem>());
            
            Add(systems.Create<UnapplyPoisonVisualsSystem>());
            Add(systems.Create<UnapplyFreezeVisualsSystem>());
            
            Add(systems.Create<RemoveUnappliedEnchantsFromHolder>());
        }
    }
}