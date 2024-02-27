using DG.Tweening;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    public class StratagemActivatedVisualizer : MonoBehaviour
    {
        [SerializeField] private Color _activatedColor = Color.green;
        [SerializeField] private float _tweenTime = 0.2f;

        private StratagemCodeVisualizer _codeVisualizer;
        private StratagemMonoBehaviour _behaviour;

        private void Awake()
        {
            _behaviour = GetComponent<StratagemMonoBehaviour>();
            _codeVisualizer = GetComponent<StratagemCodeVisualizer>();
        }

        private void OnEnable() => _behaviour.Activated += PresentActivated;

        private void OnDisable() => _behaviour.Activated -= PresentActivated;

        private void PresentActivated()
        {
            foreach (var arrow in _codeVisualizer.Arrows)
            {
                arrow.DOKill();
                arrow
                    .DOColor(_activatedColor, _tweenTime)
                    .From(Color.white)
                    .SetLoops(4, LoopType.Yoyo)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() => { arrow.color = Color.white; });
            }
        }
    }
}