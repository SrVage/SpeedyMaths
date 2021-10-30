using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class ChangeUIButtonText:IEcsRunSystem
    {
        private readonly EcsFilter<ButtonTextRef, RightAnswer> _rightAnswer;
        private readonly EcsFilter<ButtonTextRef, LooseAnswer> _looseAnswer;
        private readonly EcsFilter<GameState> _gameState;
        public void Run()
        {
            foreach (var state in _gameState)
            {
                ref var currentState = ref _gameState.Get1(state).GameStatus;
                if (currentState != GameStatus.Play)
                    return;
            }
            foreach (var right in _rightAnswer)
            {
                ref var text = ref _rightAnswer.Get1(right).ButtonText;
                ref var number = ref _rightAnswer.Get2(right).Right;
                text.text = number.ToString();
            }

            foreach (var loose in _looseAnswer)
            {
                ref var text = ref _looseAnswer.Get1(loose).ButtonText;
                ref var number = ref _looseAnswer.Get2(loose).Loose;
                text.text = number.ToString();
            }
        }
    }
}