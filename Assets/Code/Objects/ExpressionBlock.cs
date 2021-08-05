using System;
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Objects
{
    public class ExpressionBlock:MonoBehaviourEntity
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Text _numberOne;
        [SerializeField] private Text _numberTwo;
        [SerializeField] private Text _operator;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<Expression>().NumberOne = _numberOne;
            entity.Get<Expression>().NumberTwo = _numberTwo;
            entity.Get<Expression>().Operator = _operator;
            entity.Get<Expression>().Transform = transform;
            entity.Get<Expression>().GameObject = gameObject;
        }
    }
}