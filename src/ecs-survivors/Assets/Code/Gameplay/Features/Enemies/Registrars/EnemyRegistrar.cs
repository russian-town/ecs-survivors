using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        public float HP = 3f;
        public float Damage = 1f;
        public float Speed = 2f;

        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddCurrentHP(HP)
                .AddMaxHP(HP)
                .AddDamage(Damage)
                .AddTargetsBuffer(new List<int>(1))
                .AddRadius(.3f)
                .AddCollectTargetsInterval(.5f)
                .AddCollectTargetsTimer(0f)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true);
        }

        public override void UnregisterComponents() { }
    }
}
