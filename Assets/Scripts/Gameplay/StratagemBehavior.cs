using System;
using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class StratagemBehavior : MonoBehaviour
    {
        public event Action Activated;
        public event Action ActivateFailed;

        public EDirection[] Code { get; private set; }

        private int _codeIndex = 0;
        public int CurrentIndex => _codeIndex;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            Code = GetComponent<IStratagemCodeProvider>().GetCode();
            _codeIndex = 0;
        }

        public void Input(EDirection direction)
        {
            if (Code[_codeIndex] != direction)
            {
                _codeIndex = 0;
                ActivateFailed?.Invoke();
                return;
            }

            _codeIndex++;
            if (_codeIndex < Code.Length) return;
            Activated?.Invoke();
            _codeIndex = 0;
        }
    }
}