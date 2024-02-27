using System;
using StratagemHero.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace StratagemHero.Gameplay
{
    [RequireComponent(typeof(HorizontalLayoutGroup))]
    public class StratagemCodeVisualizer : MonoBehaviour
    {
        [SerializeField] private GameObject _arrowPrefab;

        private EDirection[] _code = Array.Empty<EDirection>();
        private Image[] _arrows = Array.Empty<Image>();
        private IModel _model;
        public Image[] Arrows => _arrows;

        private void Start()
        {
            _code = GetComponent<IModel>().Code;
            _arrows = new Image[_code.Length];

            for (var i = 0; i < _code.Length; i++)
            {
                var arrowUI = Instantiate(_arrowPrefab, transform);
                _arrows[i] = arrowUI.GetComponent<Image>();
                _arrows[i].transform.localRotation = Quaternion.Euler(0, 0, (int)_code[i] * 90 * -1); // clockwise
            }
        }
    }
}