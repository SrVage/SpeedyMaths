using System;
using Client.Components;
using Leopotam.Ecs;
using Random = UnityEngine.Random;

namespace Client.Systems
{
    public class CreateUIButtonSystem:IEcsRunSystem
    {
        private readonly EcsFilter<MathExpression> _mathExpression;
        private readonly EcsFilter<ButtonTextRef>.Exclude<RightAnswer, LooseAnswer> _answer;
        public void Run()
        {
            foreach (var math in _mathExpression)
            {
                ref var numberOne = ref _mathExpression.Get1(math).FirstNumber;
                ref var numberTwo = ref _mathExpression.Get1(math).SecondNumber;
                ref var oper = ref _mathExpression.Get1(math).Operation;
                float exp=0;
                switch (oper)
                {
                    case Operation.plus: exp = numberOne + numberTwo;
                        break;
                    case Operation.minus: exp = numberOne - numberTwo;
                        break;
                    case Operation.multiply: exp = numberOne * numberTwo;
                        break;
                    case Operation.divide: exp = numberOne / numberTwo;
                        break;
                }
                
                int i = Random.Range(0, 2);
                if (_answer.GetEntity(i).Has<RightAnswer>() || _answer.GetEntity(i).Has<LooseAnswer>())
                {
                     return;
                }
                _answer.GetEntity(Random.Range(0, 2)).Get<RightAnswer>().Right = exp;
                foreach (var answer in _answer)
                {
                    if(_answer.GetEntity(answer).Has<RightAnswer>()) break;
                    float ans = Random.Range(-1000, 1000);
                    while (ans==exp)
                    {
                       ans = Random.Range(-1000, 1000); 
                    }

                    _answer.GetEntity(answer).Get<LooseAnswer>().Loose = ans;
                }
            }
        }
    }
}