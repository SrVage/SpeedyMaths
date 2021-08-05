using UnityEngine;

namespace Client.Config
{
    [CreateAssetMenu(menuName = "Create expression")]
    public class ExpressionsConfig:ScriptableObject
    {
        public GameObject _prefab;
    }
}