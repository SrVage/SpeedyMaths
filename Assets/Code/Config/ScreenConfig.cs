using UnityEngine;

namespace Client.Config
{
    [CreateAssetMenu(menuName = "Create screen config")]
    public class ScreenConfig:ScriptableObject
    {
        public GameObject ChangeLevelScreen;
        public GameObject GameScreen;
    }
}