using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public interface IModel
    {
        public EDirection[] Code { get; }
        public int CodeIndex { get; set; }
    }

    public class StratagemModel : MonoBehaviour, IModel
    {
        public int CodeIndex { get; set; }

        public void Reset()
        {
            CodeIndex = 0;
        }

        [SerializeField] private string _code;

        private EDirection[] _cacheCode;

        public EDirection[] Code
        {
            get
            {
                if (_cacheCode != null) return _cacheCode;

                var arrowNumbers = _code.Split(",");
                var code = new EDirection[arrowNumbers.Length];
                for (var i = 0; i < arrowNumbers.Length; i++) code[i] = (EDirection)int.Parse(arrowNumbers[i]);

                _cacheCode = code;
                return code;
            }
        }
    }
}