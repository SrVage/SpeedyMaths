using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Objects
{
    public class GameScreen:MonoBehaviourEntity
    {
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<ScreenEntity>().Screen = gameObject;
        }
    }
}