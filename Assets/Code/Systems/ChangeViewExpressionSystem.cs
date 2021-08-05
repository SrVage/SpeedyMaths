using System;
using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class ChangeViewExpressionSystem:IEcsRunSystem
    {
        public readonly EcsFilter<Expression, MathExpression> _expressions;
        public void Run()
        {
            foreach (var expression in _expressions)
            {
                ref var firstNumberText = ref _expressions.Get1(expression).NumberOne;
                ref var secondNumberText = ref _expressions.Get1(expression).NumberTwo;
                ref var operatorText = ref _expressions.Get1(expression).Operator;
                ref var firstNumber = ref _expressions.Get2(expression).FirstNumber;
                ref var secondNumber = ref _expressions.Get2(expression).SecondNumber;
                ref var oper = ref _expressions.Get2(expression).Operation;
                firstNumberText.text = firstNumber.ToString();
                secondNumberText.text = secondNumber.ToString();
                switch (oper)
                {
                    case Operation.plus: operatorText.text = "+";
                        break;
                    case Operation.minus: operatorText.text = "-";
                        break;
                    case Operation.multiply: operatorText.text = "*";
                        break;
                    case Operation.divide: operatorText.text = "/";
                        break;
                }
            }
        }
    }
}