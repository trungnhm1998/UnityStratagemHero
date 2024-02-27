using DG.Tweening;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    [RequireComponent(typeof(StratagemCodeVisualizer))]
    public class StratagemActivateFailedVisualizer : MonoBehaviour
    {
        [SerializeField] private Color _errorColor = Color.red;
        [SerializeField] private float _tweenTime = 0.2f;
        
        private StratagemCodeVisualizer _codeVisualizer;
        private StratagemMonoBehaviour _behaviour;
        private IModel _model;

        private void Awake()
        {
            _behaviour = GetComponent<StratagemMonoBehaviour>();
            _codeVisualizer = GetComponent<StratagemCodeVisualizer>();
            _model = GetComponent<IModel>();
        }

        private void OnEnable() => _behaviour.ActivateFailed += PresentActivateFailed;

        private void OnDisable() => _behaviour.ActivateFailed -= PresentActivateFailed;

        private void PresentActivateFailed()
        {
            var index = 0;
            do
            {
                var arrow = _codeVisualizer.Arrows[index];
                arrow.color = Color.white;
                arrow
                    .DOColor(_errorColor, _tweenTime)
                    .From(Color.white)
                    .SetLoops(4, LoopType.Yoyo)
                    .SetEase(Ease.InOutFlash);

                index++;
            } while (index < _model.CodeIndex);
        }
    }
}