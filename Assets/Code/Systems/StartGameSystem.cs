using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class StartGameSystem:IEcsRunSystem
    {
        private readonly EcsFilter<GameState> _gameState;
        private readonly EcsFilter<LevelDifficultButton, Pressed> _pressed;
        private readonly EcsWorld _world;

        public void Run()
        {
            if (_pressed.IsEmpty()) return;
            foreach (var state in _gameState)
            {
                ref var currentState = ref _gameState.Get1(state).GameStatus;
                currentState = GameStatus.Play;
            }

            foreach (var button in _pressed)
            {
                ref var diff = ref _pressed.Get1(button).CurrentDifficult;
                _world.NewEntity().Get<CurrentDifficult>().Difficult = diff;
                _pressed.GetEntity(button).Destroy();
            }
        }
    }
}