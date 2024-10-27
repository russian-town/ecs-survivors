using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public class BoosterDurationSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _tick;
        private readonly IGroup<MetaEntity> _boosters;

        public BoosterDurationSystem(MetaContext meta)
        {
            _tick = meta.GetGroup(MetaMatcher.Tick);

            _boosters = meta.GetGroup(
                MetaMatcher
                    .AllOf(
                        MetaMatcher.GoldGainBoost,
                        MetaMatcher.Duration
                    ));
        }

        public void Execute()
        {
            foreach (var tick in _tick)
            foreach (var booster in _boosters)
            {
                booster.ReplaceDuration(booster.Duration - tick.Tick);

                if (booster.Duration <= 0f)
                    booster.isDestructed = true;
            }
        }
    }
}
