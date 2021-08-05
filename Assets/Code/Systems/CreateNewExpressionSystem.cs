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
        private readonly EcsWorld _world;
        public void Run()
        {
            if (!_expression.IsEmpty()) return;
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
            oper = (Operation)values.GetValue(Random.Range(0,4));
        }
    }
}