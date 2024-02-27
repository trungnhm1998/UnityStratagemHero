using System;
using StratagemHero.ScriptableObjects;

namespace StratagemHero.Gameplay
{
    public class StratagemBehaviour
    {
        public event Action Activated;
        public event Action ActivateFailed;
        public event Action NextInput;
        private readonly IModel _model;

        public StratagemBehaviour(IModel model) => _model = model;

        private EDirection[] Code => _model.Code;

        private int CodeIndex
        {
            get => _model.CodeIndex;
            set => _model.CodeIndex = value;
        }

        public void Input(EDirection direction)
        {
            if (Code[CodeIndex++] != direction)
            {
                ActivateFailed?.Invoke();
                CodeIndex = 0;
                return;
            }

            NextInput?.Invoke();
            if (CodeIndex < Code.Length - 1) return;
            Activated?.Invoke();
            CodeIndex = 0;
        }
    }
}