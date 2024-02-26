using System;
using StratagemHero.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace StratagemHero.Gameplay
{
    [RequireComponent(typeof(HorizontalLayoutGroup))]
    public class StratagemVisualizer : MonoBehaviour
    {
        [SerializeField] private GameObject _arrowPrefab;

        private EDirection[] _code = Array.Empty<EDirection>();
        private GameObject[] _arrows = Array.Empty<GameObject>();

        private void Start()
        {
            _code = GetComponent<IStratagemCodeProvider>().GetCode();
            _arrows = new GameObject[_code.Length];

            for (var i = 0; i < _code.Length; i++)
            {
                _arrows[i] = Instantiate(_arrowPrefab, transform);
                _arrows[i].transform.localRotation = Quaternion.Euler(0, 0, (int)_code[i] * 90 * -1);
            }
        }

        public void Show() => InternalShow();

        private void InternalShow(bool isShow = true)
        {
            foreach (var arrow in _arrows)
            {
                arrow.SetActive(isShow);
            }
        }

        public void Hide() => InternalShow(false);
    }
}