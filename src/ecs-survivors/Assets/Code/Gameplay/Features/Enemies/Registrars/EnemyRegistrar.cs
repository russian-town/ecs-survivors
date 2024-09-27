using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        public float Speed = 2f;
        public float TargetDistance = 1f;

        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddDistance(0)
                .AddTargetDistance(TargetDistance)
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true);
        }

        public override void UnregisterComponents() { }
    }
}
