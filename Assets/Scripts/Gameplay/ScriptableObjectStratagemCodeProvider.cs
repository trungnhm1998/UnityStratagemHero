using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class ScriptableObjectStratagemCodeProvider : IStratagemCodeProvider
    {
        [field: SerializeField] public Stratagem StratagemSO { get; set; }
        public EDirection[] GetCode() => StratagemSO.Code;
    }
}