using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Objects
{
    public enum LevelDifficult
    {
        Easy = 0,
        Medium = 1,
        High = 2
    }
    public class ChangeLevelButton:MonoBehaviourEntity
    {
        [SerializeField] private LevelDifficult _levelDifficult;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<LevelDifficultButton>().CurrentDifficult = _levelDifficult;
        }
    }
}