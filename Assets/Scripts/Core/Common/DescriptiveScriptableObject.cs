using UnityEngine;

namespace Core.Common
{
    public abstract class DescriptiveScriptableObject : ScriptableObject
    {
        [SerializeField, TextArea(maxLines: 10, minLines: 3)] private string _description;
        
    }
}