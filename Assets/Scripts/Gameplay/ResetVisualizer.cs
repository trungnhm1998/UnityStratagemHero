using DG.Tweening;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class ResetVisualizer : MonoBehaviour
    {
        private StratagemMonoBehaviour _behaviour;
        private StratagemCodeVisualizer _codeVisualizer;

        private void Awake()
        {
            _behaviour = GetComponent<StratagemMonoBehaviour>();
            _codeVisualizer = GetComponent<StratagemCodeVisualizer>();
        }

        private void OnEnable() => _behaviour.ResetEvent += PresentReset;

        private void OnDisable() => _behaviour.ResetEvent += PresentReset;

        private void PresentReset()
        {
            foreach (var arrow in _codeVisualizer.Arrows) arrow.DOColor(Color.white, 0.2f);
        }
    }
}