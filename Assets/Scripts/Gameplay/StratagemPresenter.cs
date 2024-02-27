using StratagemHero.Input;
using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class StratagemPresenter : MonoBehaviour, IModel
    {
        public int CodeIndex { get; set; }

        private EDirection[] _cacheCode;

        public EDirection[] Code
        {
            get
            {
                if (_cacheCode != null) return _cacheCode;

                var arrowNumbers = _code.Split(",");
                var code = new EDirection[arrowNumbers.Length];
                for (var i = 0; i < arrowNumbers.Length; i++)
                {
                    code[i] = (EDirection)int.Parse(arrowNumbers[i]);
                }

                _cacheCode = code;
                return code;
            }
        }

        private static IInputConverter _directionConverter;

        private static IInputConverter DirectionConverter =>
            _directionConverter ??= new DirectionInputConverter(); // lazy init singleton

        [SerializeField] private string _code;
        [SerializeField] private InputMediator _inputMediator;

        private StratagemBehaviour _behaviour;

        private void Start()
        {
            _behaviour = new StratagemBehaviour(this);
        }

        private void OnEnable() => _inputMediator.DirectionInput += ConvertThenValidate;

        private void OnDisable() => _inputMediator.DirectionInput -= ConvertThenValidate;

        private void ConvertThenValidate(Vector2 axis) => _behaviour.Input(DirectionConverter.Convert(axis));
    }
}