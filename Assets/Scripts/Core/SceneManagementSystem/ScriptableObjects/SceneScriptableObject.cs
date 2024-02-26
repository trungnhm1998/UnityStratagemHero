using Core.Common;
using UnityEngine;

namespace Core.SceneManagementSystem.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scene Management/Scene Scriptable Object")]
    public class SceneScriptableObject : SerializableScriptableObject
    {
        public enum EType
        {
            Startup = 0,
            Gameplay = 1,

            GlobalManager = 2,
            GameplayManager = 3,
        }

        [field: SerializeField] public EType Type { get; private set; }
        [field: SerializeField] public SceneAssetReference SceneReference { get; private set; }
    }
}