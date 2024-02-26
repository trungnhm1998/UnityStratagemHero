using StratagemHero.Input;
using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class StratagemInputHandler : MonoBehaviour
    {
        private static readonly IInputConverter DirectionConverter = new DirectionInputConverter();

        [SerializeField] private InputMediator _inputMediator;
        [SerializeField] private StratagemBehavior _behavior;

        private void OnEnable()
        {
            _inputMediator.DirectionInput += ConvertThenValidate;
        }

        private void OnDisable()
        {
            _inputMediator.DirectionInput -= ConvertThenValidate;
        }

        private void ConvertThenValidate(Vector2 axis)
        {
            var direction = DirectionConverter.Convert(axis);
            if (direction == EDirection.Invalid) return;
            _behavior.Input(direction);
        }
    }
}