using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class InlineStratagemCodeProvider : MonoBehaviour, IModel
    {
        [SerializeField] private string _code;

        public int CodeIndex
        {
            get => _index;
            set => _index = value;
        }

        private int _index;
        private EDirection[] _cache;

        public EDirection[] Code
        {
            get
            {
                if (_cache != null) return _cache;
                var arrowNumbers = _code.Split(",");
                var code = new EDirection[arrowNumbers.Length];
                for (var i = 0; i < arrowNumbers.Length; i++)
                {
                    code[i] = (EDirection)int.Parse(arrowNumbers[i]);
                }

                _cache = code;

                return code;
            }
        }
    }
}