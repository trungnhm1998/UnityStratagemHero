using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public interface IInputConverter
    {
        public EDirection Convert(Vector2 axis);
    }
}