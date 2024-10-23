using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CollectExperienceSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;

        public CollectExperienceSystem(GameContext game)
        {
            _collected = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Collected,
                        GameMatcher.Experience
                    ));

            _heroes = game.GetGroup(GameMatcher.Hero);
        }

        public void Execute()
        {
            foreach (var hero in _heroes)
            foreach (var collected in _collected)
                hero.ReplaceExperience(hero.Experience + collected.Experience);
        }
    }
}
