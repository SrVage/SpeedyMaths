using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class ExpressionDestroySystem:IEcsRunSystem
    {
        private readonly EcsFilter<Destroy> _destroy;
        private readonly EcsFilter<ButtonTextRef, RightAnswer> _right;
        private readonly EcsFilter<ButtonTextRef, LooseAnswer> _loose;
        public void Run()
        {
            foreach (var destroy in _destroy)
            {
                foreach (var r in _right)
                {
                    _right.GetEntity(r).Del<RightAnswer>();
                }
                foreach (var l in _loose)
                {
                    _loose.GetEntity(l).Del<LooseAnswer>();
                }
                ref var go = ref _destroy.GetEntity(destroy).Get<Expression>().GameObject;
                GameObject.Destroy(go);
                _destroy.GetEntity(destroy).Destroy();
            }
        }
    }
}