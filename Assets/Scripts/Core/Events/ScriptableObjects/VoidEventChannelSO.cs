using Core.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Core/Events/Void Event Channel")]
    public class VoidEventChannelSO : SerializableScriptableObject
    {
        public UnityAction EventRaised;

        public void RaiseEvent()
        {
            OnRaiseEvent();
        }

        private void OnRaiseEvent()
        {
            if (EventRaised == null)
            {
                Debug.LogWarning($"Event was raised on {name} but no one was listening.");
                return;
            }

            EventRaised.Invoke();
        }
    }
}