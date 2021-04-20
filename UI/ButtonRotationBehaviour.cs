using DG.Tweening;
using UnityEngine;

namespace CarGameScripts.UI
{
    public class ButtonRotationBehaviour : MonoBehaviour
    {
        [SerializeField] private float _interval;
        private Sequence _sequence;
        
        private void Start()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOShakeRotation(0.3f, 45.0f)).SetEase(Ease.Linear);
            _sequence.AppendInterval(_interval);
            _sequence.SetLoops(-1);
        }
        
        private void OnEnable()
        {
            _sequence.Play();
        }

        private void OnDisable()
        {
            _sequence.Pause();
        }

        private void OnDestroy()
        {
            _sequence = null;
        }
    }
}