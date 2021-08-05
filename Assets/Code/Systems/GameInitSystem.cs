using Client.Objects;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class GameInitSystem:IEcsInitSystem
    {
        private readonly EcsWorld _world;
        public void Init()
        {
            var go = Object.FindObjectsOfType<MonoBehaviourEntity>();
            foreach (var obj in go)
            {
                obj.Initial(_world.NewEntity(), _world);
            }
        }
    }
}