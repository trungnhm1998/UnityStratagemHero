using Core.Events.ScriptableObjects;
using Core.SceneManagementSystem.ScriptableObjects;
using UnityEngine;

namespace Core.SceneManagementSystem.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scene Management/Events/Load Scene Event Channel")]
    public class LoadSceneEventChannelSO : GenericEventChannelSO<SceneScriptableObject>
    {
        protected override void OnRaiseEvent(SceneScriptableObject sceneScriptableObject)
        {
            if (sceneScriptableObject == null)
            {
                Debug.LogWarning("A request for loading scene has been made, but no scene was provided.");
                return;
            }

            base.OnRaiseEvent(sceneScriptableObject);
        }
    }
}