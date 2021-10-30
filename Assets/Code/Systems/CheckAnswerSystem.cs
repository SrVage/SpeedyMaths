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
        private readonly EcsFilter<GameState> _gameState;
        public void Run()
        {
            foreach (var state in _gameState)
            {
                ref var currentState = ref _gameState.Get1(state).GameStatus;
                if (currentState != GameStatus.Play)
                    return;
            }
            foreach (var button in _button)
            {
                ref var entity = ref _button.GetEntity(button);
                if (entity.Has<RightAnswer>())
                {
                    Debug.Log("Right");
                    DelExpression(ref entity);
                    ChangeScore(true);
                }
                else if (entity.Has<LooseAnswer>())
                {
                    Debug.Log("Loose");
                    DelExpression(ref entity);
                    ChangeScore(false);
                }
            }
        }

        private void ChangeScore(bool add)
        {
            foreach (var count in _count)
            {
                ref var text = ref _count.Get1(count).TextCount;
                ref var generalCount = ref _count.Get1(count).GeneralCount;
                if (add)
                    generalCount++;
                else
                    generalCount--;
                text.text = generalCount.ToString();
            }
        }

        private void DelExpression(ref EcsEntity entity)
        {
            entity.Del<Pressed>();
            foreach (var exp in _expression)
            {
                _expression.GetEntity(exp).Get<Destroy>();
            }
        }
    }
}