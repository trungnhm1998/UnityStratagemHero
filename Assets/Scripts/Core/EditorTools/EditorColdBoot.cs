﻿using System.Collections;
using Core.Common;
using Core.Events.ScriptableObjects;
using Core.SceneManagementSystem.Events.ScriptableObjects;
using Core.SceneManagementSystem.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.EditorTools
{
    public class EditorColdBoot : MonoBehaviour
    {
        public SceneScriptableObject ThisScene => _thisSceneSO;
        [SerializeField] private SceneScriptableObject _thisSceneSO;
#if UNITY_EDITOR
        [SerializeField] private SceneScriptableObject _globalManagersSO;
        [SerializeField] private SceneAssetReference[] _additionalScenes;

        [SerializeField]
        private ScriptableObjectAssetReference<LoadSceneEventChannelSO> _editorColdBootEventChannelSO;

        [Header("Raise on")]
        [SerializeField] private VoidEventChannelSO _sceneLoadedEventChannelSO;

        private bool _isStartFromEditor;

        private void Awake()
        {
            _isStartFromEditor =
                !SceneManager.GetSceneByName(_globalManagersSO.SceneReference.editorAsset.name).isLoaded
                && !_globalManagersSO.SceneReference.OperationHandle.IsValid();
        }

        private IEnumerator Start()
        {
            if (_isStartFromEditor == false) yield break;
            yield return _globalManagersSO.SceneReference.LoadSceneAsync(LoadSceneMode.Additive);
            var coldBootEventAssetHandle = _editorColdBootEventChannelSO.LoadAssetAsync<LoadSceneEventChannelSO>();
            yield return coldBootEventAssetHandle;

            var coldBootEvent = coldBootEventAssetHandle.Result;
            foreach (var sceneAssetReference in _additionalScenes)
            {
                yield return sceneAssetReference.LoadSceneAsync(LoadSceneMode.Additive);
            }

            SetupGameplayManagerSceneOrNotifySceneLoaded(coldBootEvent);
        }

        private void SetupGameplayManagerSceneOrNotifySceneLoaded(LoadSceneEventChannelSO coldBootEvent)
        {
            if (_thisSceneSO == null)
            {
                _sceneLoadedEventChannelSO.RaiseEvent();
                return;
            }

            coldBootEvent.RaiseEvent(_thisSceneSO);
        }
#endif
    }
}