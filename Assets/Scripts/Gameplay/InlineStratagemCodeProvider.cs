using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class InlineStratagemCodeProvider : MonoBehaviour, IStratagemCodeProvider
    {
        [SerializeField] private string _code;
        
        public EDirection[] GetCode()
        {
            var arrowNumbers = _code.Split(",");
            var code = new EDirection[arrowNumbers.Length];
            for (var i = 0; i < arrowNumbers.Length; i++)
            {
                code[i] = (EDirection)int.Parse(arrowNumbers[i]);
            }
            return code;
        }
    }
}