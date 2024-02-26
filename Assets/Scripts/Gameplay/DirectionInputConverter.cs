using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class DirectionInputConverter : IInputConverter
    {
        public EDirection Convert(Vector2 axis)
        {
            return axis.x switch
            {
                > 0 => EDirection.Right,
                < 0 => EDirection.Left,
                _ => axis.y switch
                {
                    > 0 => EDirection.Up,
                    < 0 => EDirection.Down,
                    _ => EDirection.Invalid
                }
            };
        }
    }
}