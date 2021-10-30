using System;
using Client.Components;
using Client.Config;
using Client.Objects;
using Leopotam.Ecs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Client.Systems
{
    public class CreateNewExpressionSystem:IEcsRunSystem
    {
        private readonly ExpressionsConfig _expressionsConfig;
        private readonly EcsFilter<Expression> _expression;
        private readonly EcsFilter<GameState> _gameState;
        private readonly EcsFilter<CurrentDifficult> _difficult;
        private readonly EcsWorld _world;
        public void Run()
        {
            foreach (var state in _gameState)
            {
                ref var currentState = ref _gameState.Get1(state).GameStatus;
                if (currentState != GameStatus.Play)
                    return;
            }
            if (!_expression.IsEmpty()) return;
            LevelDifficult difficult = LevelDifficult.Easy;
            foreach (var VARIABLE in _difficult)
            {
                difficult = _difficult.Get1(VARIABLE).Difficult;
            }
            var go = GameObject.Instantiate(_expressionsConfig._prefab);
            var entity = _world.NewEntity();
            go.GetComponent<MonoBehaviourEntity>().Initial(entity, _world);
            entity.Get<Expression>().Transform.position = new Vector3(Random.Range(-4f, 4f), 4, 0);
            ref var first = ref entity.Get<MathExpression>().FirstNumber;
            ref var second = ref entity.Get<MathExpression>().SecondNumber;
            ref var oper = ref entity.Get<MathExpression>().Operation;
            first = Random.Range(0, 99);
            second = Random.Range(9, 99);
            var values = Enum.GetValues(typeof(Operation));
            switch (difficult)
            {
                case LevelDifficult.Easy:
                    oper = (Operation)values.GetValue(Random.Range(0,2));
                    break;
                case LevelDifficult.Medium:
                    oper = (Operation)values.GetValue(Random.Range(0,3));
                    break;
                case LevelDifficult.High:
                    oper = (Operation)values.GetValue(Random.Range(0,4)); 
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}