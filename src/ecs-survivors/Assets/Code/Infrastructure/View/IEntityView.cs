using UnityEngine;

namespace Code.Infrastructure.View
{
    public interface IEntityView
    {
        public GameEntity Entity { get; }
        public GameObject gameObject { get; }
        public void SetEntity(GameEntity entity);
        public void ReleaseEntity();
    }
}