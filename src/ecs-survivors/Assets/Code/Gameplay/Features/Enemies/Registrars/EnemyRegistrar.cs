using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyRegistrar : MonoBehaviour
    {
        public float Speed = 2f;
        public float TargetDistance = 1f;
        public EnemyAnimator EnemyAnimator;

        private GameEntity _entity;

        private void Awake()
        {
            _entity = CreateEntity
                .Empty()
                .AddTransform(transform)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddDistance(0)
                .AddTargetDistance(TargetDistance)
                .AddSpriteRenderer(EnemyAnimator.SpriteRenderer)
                .AddEnemyAnimator(EnemyAnimator)
                .With(x => x.isEnemy = true);
        }
    }
}
