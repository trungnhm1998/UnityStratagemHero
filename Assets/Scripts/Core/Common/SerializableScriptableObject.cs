using Core.EditorTools.Attributes.ReadOnlyAttribute;
using UnityEditor;
using UnityEngine;

namespace Core.Common
{
    public class SerializableScriptableObject : DescriptiveScriptableObject
    {
        [SerializeField, ReadOnly] private string _guid;
        public string Guid => _guid;

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            var assetPath = AssetDatabase.GetAssetPath(this);
            _guid = AssetDatabase.AssetPathToGUID(assetPath);
        }
#endif
    }
}