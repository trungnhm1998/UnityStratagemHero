using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StratagemHero.Input
{
    public class InputMediator : ScriptableObject,
        InputActions.IUIActions
    {
        public event Action<Vector2> DirectionInput;

        private InputActions _inputActions;

        public InputActions InputActions
        {
            get
            {
                CreateInputInstanceIfNeeded();
                return _inputActions;
            }
        }

        private void CreateInputInstanceIfNeeded()
        {
            if (_inputActions != null) return;

            _inputActions = new InputActions();
            _inputActions.UI.SetCallbacks(this);
            
            _inputActions.UI.Enable();
        }

        private void OnEnable()
        {
            CreateInputInstanceIfNeeded();
        }

        private void OnDisable()
        {
            _inputActions.UI.Disable();
        }

        public void OnNavigate(InputAction.CallbackContext context)
        {
            DirectionInput?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnSubmit(InputAction.CallbackContext context) { }

        public void OnCancel(InputAction.CallbackContext context) { }

        public void OnPoint(InputAction.CallbackContext context) { }

        public void OnClick(InputAction.CallbackContext context) { }

        public void OnRightClick(InputAction.CallbackContext context) { }
    }
}