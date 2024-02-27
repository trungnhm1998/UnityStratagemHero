using System;
using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class StratagemMonoBehaviour : MonoBehaviour
    {
        public event Action Activated;
        public event Action ActivateFailed;
        public event Action NextInput;

        public void Input(EDirection direction) => _behaviour.Input(direction);

        private StratagemBehaviour _behaviour;

        private void Awake()
        {
            _behaviour = new StratagemBehaviour(GetComponent<IModel>());
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
    }
}