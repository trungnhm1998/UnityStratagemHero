using UnityEngine;
using UnityEngine.Localization;

namespace StratagemHero.ScriptableObjects
{
    public enum EDirection
    {
        Invalid = -1,
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
    }

    [CreateAssetMenu(menuName = "Create Stratagem", fileName = "Stratagem", order = 0)]
    public class Stratagem : ScriptableObject
    {
        [SerializeField] private LocalizedString _stratagemName;
        public LocalizedString StratagemName => _stratagemName;

        [SerializeField] private EDirection[] _code;
        public EDirection[] Code => _code;
    }
}