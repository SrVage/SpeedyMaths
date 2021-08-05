using Leopotam.Ecs;
using UnityEngine;

namespace Client.Objects
{
    public abstract class MonoBehaviourEntity:MonoBehaviour
    {
        public virtual void Initial(EcsEntity entity, EcsWorld world)
        {
            gameObject.AddComponent<EntityRef>().Entity = entity;
            Destroy(gameObject.GetComponent<MonoBehaviourEntity>());
        }
    }
}