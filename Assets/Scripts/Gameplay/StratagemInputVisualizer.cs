using DG.Tweening;
using UnityEngine;

namespace StratagemHero.Gameplay
{
    [RequireComponent(typeof(StratagemCodeVisualizer))]
    public class StratagemInputVisualizer : MonoBehaviour
    {
        [SerializeField] private Color _correctInputColor = Color.yellow;
        [SerializeField] private float _tweenTime = 0.2f;

        private StratagemMonoBehaviour _behaviour;
        private IModel _model;
        private StratagemCodeVisualizer _codeVisualizer;

        private void Awake()
        {
            _behaviour = GetComponent<StratagemMonoBehaviour>();
            _model = GetComponent<IModel>();
            _codeVisualizer = GetComponent<StratagemCodeVisualizer>();
        }

        private void OnEnable() => _behaviour.NextInput += HighlightDirectionIndex;

        private void OnDisable() => _behaviour.NextInput -= HighlightDirectionIndex;

        private void HighlightDirectionIndex()
        {
            _codeVisualizer.Arrows[_model.CodeIndex]
                .DOColor(_correctInputColor, _tweenTime);
        }
    }
}