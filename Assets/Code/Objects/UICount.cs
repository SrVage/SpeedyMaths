using Client.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Objects
{
    public class UICount:MonoBehaviourEntity
    {
        [SerializeField] private Text _text;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<Count>().TextCount = _text;
            entity.Get<Count>().GeneralCount = 0;
        }
    }
}