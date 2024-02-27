using UnityEngine;
using UnityEngine.UI;

namespace StratagemHero.Gameplay
{
    [RequireComponent(typeof(StratagemVisualizer))]
    public class StratagemInputVisualizer : MonoBehaviour
    {
        private StratagemMonoBehaviour _behaviour;
        private IModel _model;
        private StratagemVisualizer _visualizer;

        private void Awake()
        {
            _behaviour = GetComponent<StratagemMonoBehaviour>();
            _model = GetComponent<IModel>();
            _visualizer = GetComponent<StratagemVisualizer>();
        }

        private void OnEnable()
        {
            _behaviour.NextInput += HighlightDirectionIndex;
        }

        private void OnDisable()
        {
            _behaviour.NextInput -= HighlightDirectionIndex;
        }

        private void HighlightDirectionIndex()
        {
            var arrowGo = _visualizer.Arrows[_model.CodeIndex - 1];
            var image = arrowGo.GetComponent<Image>();
            image.color = Color.yellow;
        }
    }
}