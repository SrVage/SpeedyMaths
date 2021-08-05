using Client.Components;
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class MoveExpressionSystem:IEcsRunSystem
    {
        private readonly EcsFilter<Expression, MathExpression>.Exclude<Moving> _movingExpressions;
        public void Run()
        {
            foreach (var moving in _movingExpressions)
            {
                ref var transform = ref _movingExpressions.Get1(moving).Transform;
                var entity = _movingExpressions.GetEntity(moving);
                DOTween.Sequence().Append(transform.DOMove(Vector3.zero, 5f).SetEase(Ease.Linear)).OnComplete(() => entity.Get<Destroy>());
                _movingExpressions.GetEntity(moving).Get<Moving>();
            }
        }
    }
}