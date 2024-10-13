using Entitas;

namespace Code.Gameplay.Features.Enchants
{
    [Game] public class EnchantTypeIdComponent : IComponent { public EnchantTypeId Value; }
    [Game] public class PoisonEnchant : IComponent { }
    [Game] public class ExplosiveEnchant : IComponent { }
}