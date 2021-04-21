using System;
using CarGameScripts.ContentDataSource.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CarGameScripts.UI
{
    public class ButtonColorBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] private ColorConfig _colorConfig;
        
        [SerializeField] private Image _image;
        private Sequence _sequence;

        private void Awake()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(_image.DOColor(_colorConfig.Color, _colorConfig.Duration)).SetEase(_colorConfig.Ease);
            _sequence.Append(_image.DOColor(_image.color, _colorConfig.Duration)).SetEase(_colorConfig.Ease);
            _sequence.SetLoops(-1);
            _sequence.OnComplete(() => _sequence = null);
            _sequence.Pause();
        }

        private void OnDestroy()
        {
            _sequence.Complete();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _sequence.Play();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _sequence.Rewind();
            _sequence.OnRewind(() => _sequence.Pause());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _sequence.Rewind();
            _sequence.OnRewind(() => _sequence.Pause());
        }
    }
}