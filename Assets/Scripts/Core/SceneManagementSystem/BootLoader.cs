using System.Collections;
using Core.SceneManagementSystem.Events.ScriptableObjects;
using Core.SceneManagementSystem.ScriptableObjects;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Core.SceneManagementSystem
{
    public class BootLoader : MonoBehaviour
    {
        [SerializeField] private GlobalManagersSceneScriptableObject _globalManagerSceneSO;
        [SerializeField] private SceneScriptableObject _startupSceneSO;

        [SerializeField] private AssetReferenceT<LoadSceneEventChannelSO> _loadStartupEvent;

        private IEnumerator Start()
        {
            yield return _globalManagerSceneSO.SceneReference.LoadSceneAsync(LoadSceneMode.Additive);
            var loadStartupEventOpHandle = _loadStartupEvent.LoadAssetAsync();
            yield return loadStartupEventOpHandle;
            loadStartupEventOpHandle.Result.RaiseEvent(_startupSceneSO);
            SceneManager.UnloadSceneAsync(0);
        }
    }
}