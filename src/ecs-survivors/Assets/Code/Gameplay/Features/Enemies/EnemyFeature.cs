using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Enemies.Systems;

namespace Code.Gameplay.Features.Enemies
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(ITimeService timeService, GameContext gameContext)
        {
            Add(new EnemyFollowHeroSystem(timeService, gameContext));
            Add(new EnemyCalculateDistanceToHeroSystem(gameContext));
        }
    }
}