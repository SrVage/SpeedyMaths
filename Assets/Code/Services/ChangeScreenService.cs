using Client.Components;
using Client.Config;
using Client.Objects;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Services
{
    public class ChangeScreenService:IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<LevelDifficultButton, Pressed> _startLevel;
        private readonly EcsWorld _world;
        private readonly ScreenConfig _screenConfig;
        private readonly EcsFilter<LevelDifficultButton, Pressed> _pressed;
        private readonly EcsFilter<ScreenEntity> _screen;
        public void Init()
        {
            _world.NewEntity().Get<GameState>().GameStatus = GameStatus.Menu;
            var gobj = GameObject.Instantiate(_screenConfig.ChangeLevelScreen);
            gobj.GetComponent<MonoBehaviourEntity>().Initial(_world.NewEntity(), _world);
            var go = Object.FindObjectsOfType<MonoBehaviourEntity>();
            foreach (var obj in go)
            {
                obj.Initial(_world.NewEntity(), _world);
            }
        }

        public void Run()
        {
            if (_pressed.IsEmpty()) return;
            foreach (var screen in _screen)
            {
                ref var screenEntity = ref _screen.Get1(screen).Screen;
                GameObject.Destroy(screenEntity);
                _screen.GetEntity(screen).Destroy();
            }
            var gobj = GameObject.Instantiate(_screenConfig.GameScreen);
            gobj.GetComponent<MonoBehaviourEntity>().Initial(_world.NewEntity(), _world);
            var go = Object.FindObjectsOfType<MonoBehaviourEntity>();
            foreach (var obj in go)
            {
                obj.Initial(_world.NewEntity(), _world);
            }
        }
    }
}