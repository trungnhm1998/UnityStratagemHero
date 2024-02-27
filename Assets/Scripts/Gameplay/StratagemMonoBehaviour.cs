using System;
using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    /// <summary>
    /// Act as presenter
    /// </summary>
    public class StratagemMonoBehaviour : MonoBehaviour
    {
        public event Action Activated;
        public event Action ActivateFailed;
        public event Action NextInput;
        public event Action ResetEvent;

        public void Input(EDirection direction) => _behaviour.Input(direction);

        private StratagemBehaviour _behaviour;
        private IModel _model; // act as state

        private void Awake()
        {
            _model = GetComponent<IModel>();
            _behaviour = new StratagemBehaviour(_model);
            _behaviour.ActivateFailed += OnActivateFailed;
            _behaviour.Activated += OnActivated;
            _behaviour.NextInput += OnNextInput;
        }

        private void OnNextInput()
        {
            NextInput?.Invoke();
        }

        private void OnActivated()
        {
            Activated?.Invoke();
        }

        private void OnActivateFailed()
        {
            ActivateFailed?.Invoke();
        }

        private void OnDestroy()
        {
            _behaviour.ActivateFailed -= OnActivateFailed;
            _behaviour.Activated -= OnActivated;
            _behaviour.NextInput -= OnNextInput;
        }

        public void Reset() => OnReset();

        private void OnReset()
        {
            ResetEvent?.Invoke();
            _model.CodeIndex = 0;
        }
    }
}