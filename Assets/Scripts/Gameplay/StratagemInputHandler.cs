using StratagemHero.Input;
using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class StratagemInputHandler : MonoBehaviour
    {
        private static IInputConverter _directionConverter;

        private static IInputConverter DirectionConverter =>
            _directionConverter ??= new DirectionInputConverter(); // lazy init singleton

        [SerializeField] private InputMediator _inputMediator;
        [SerializeField] private StratagemMonoBehaviour _behaviour;

        private void OnEnable()
        {
            _inputMediator.DirectionInput += ConvertThenValidate;
            _inputMediator.CancelEvent += UnblockInput;
            _behaviour.ActivateFailed += BlockInput;
        }

        private void OnDisable()
        {
            _inputMediator.DirectionInput -= ConvertThenValidate;
            _inputMediator.CancelEvent -= UnblockInput;
            _behaviour.ActivateFailed -= BlockInput;
        }

        private bool _blockInput = false;

        private void BlockInput() => _blockInput = true;

        private void UnblockInput()
        {
            _blockInput = false;
            _behaviour.Reset();
        }

        private void ConvertThenValidate(Vector2 axis)
        {
            if (_blockInput) return;
            var direction = DirectionConverter.Convert(axis);
            if (direction == EDirection.Invalid) return;
            _behaviour.Input(direction);
        }
    }
}