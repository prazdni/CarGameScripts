using CarGameScripts.ContentDataSource.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CarGameScripts.UI
{
    public class ButtonScaleBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] private ScaleConfig _pointerDownScale;

        [SerializeField] private ScaleConfig _pointerUpScale;

        private void OnDestroy()
        {
            transform.DOKill();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!transform) 
                return;
            
            transform.DOKill();

            transform.DOScale(new Vector3(_pointerDownScale.Scale.x, _pointerDownScale.Scale.y, 
                _pointerDownScale.Scale.x), _pointerDownScale.Duration).SetEase(_pointerDownScale.Ease);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!transform) 
                return;
            
            transform.DOKill();

            transform.DOScale(new Vector3(_pointerUpScale.Scale.x, _pointerUpScale.Scale.y, 
                _pointerUpScale.Scale.x), _pointerUpScale.Duration).SetEase(_pointerUpScale.Ease);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!transform) 
                return;
            
            transform.DOKill();

            transform.DOScale(new Vector3(_pointerUpScale.Scale.x, _pointerUpScale.Scale.y, 
                _pointerUpScale.Scale.x), _pointerUpScale.Duration).SetEase(_pointerUpScale.Ease);
        }
    }
}