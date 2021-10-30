using Client.Config;
using Client.Services;
using Client.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private ExpressionsConfig _expressionsConfig;
        [SerializeField] private ScreenConfig _screenConfig;
        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                //.Add(new GameInitSystem())
                .Add(new ChangeScreenService())
                .Add (new CreateNewExpressionSystem())
                .Add(new MoveExpressionSystem())
                .Add(new ExpressionDestroySystem())
                .Add(new ChangeViewExpressionSystem())
                .Add(new CreateUIButtonSystem())
                .Add(new ChangeUIButtonText())
                .Add(new CheckAnswerSystem())
                .Add(new StartGameSystem())
                // .Add (new TestSystem2 ())
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                 .Inject (_expressionsConfig)
                 .Inject(_screenConfig)
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}