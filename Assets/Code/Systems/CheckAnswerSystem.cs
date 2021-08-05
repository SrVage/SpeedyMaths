using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class CheckAnswerSystem:IEcsRunSystem
    {
        private readonly EcsFilter<Pressed> _button;
        private readonly EcsFilter<Expression, MathExpression> _expression;
        private readonly EcsFilter<Count> _count;
        public void Run()
        {
            foreach (var button in _button)
            {
                ref var entity = ref _button.GetEntity(button);
                if (entity.Has<RightAnswer>())
                {
                    Debug.Log("Right");
                    entity.Del<Pressed>();
                    foreach (var exp in _expression)
                    {
                        _expression.GetEntity(exp).Get<Destroy>();
                    }

                    foreach (var count in _count)
                    {
                        ref var text = ref _count.Get1(count).TextCount;
                        ref var generalCount = ref _count.Get1(count).GeneralCount;
                        generalCount++;
                        text.text = generalCount.ToString();
                    }
                }
                else if (entity.Has<LooseAnswer>())
                {
                    Debug.Log("Loose");
                    entity.Del<Pressed>();
                    foreach (var exp in _expression)
                    {
                        _expression.GetEntity(exp).Get<Destroy>();
                    }
                    
                    foreach (var count in _count)
                    {
                        ref var text = ref _count.Get1(count).TextCount;
                        ref var generalCount = ref _count.Get1(count).GeneralCount;
                        generalCount--;
                        text.text = generalCount.ToString();
                    }
                }
                
                
            }
        }
    }
}