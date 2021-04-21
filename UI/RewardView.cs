using System;
using System.Collections.Generic;
using DG.Tweening;
using Profile;
using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace CarGameScripts.UI
{
    public class RewardView : MonoBehaviour, IView
    {
        [SerializeField] private Button _buttonClosePopup;
        [SerializeField] private float _duration = 0.3f;
        [SerializeField] private TextBehaviour _text;
        [SerializeField] private RectTransform _reward;
        [SerializeField] private List<RectTransform> _rectTransforms;
        private bool _isActive;

        private void Start()
        {
            _buttonClosePopup.onClick.AddListener(OnRewardOpen);
            _reward.gameObject.SetActive(_isActive);

            AnimationHide(0.0f);
        }

        private void OnDestroy()
        {
            _buttonClosePopup.onClick.RemoveAllListeners();
        }

        private void OnRewardOpen()
        {
            _isActive = !_isActive;

            if (_isActive)
            {
                _text.ChangeText("Close Reward");
                Show();
            }
            else
            {
                _text.ChangeText("Open Reward");
                Hide();
            }
        }

        public void Show()
        {
            AnimationShow(_duration);
        }

        public void Hide()
        {
            AnimationHide(_duration);
        }

        private void AnimationShow(float duration)
        {
            var sequence = DOTween.Sequence();
            sequence.OnStart(() => _reward.gameObject.SetActive(true));
            sequence.Append(_reward.DOAnchorMax(Vector3.one, duration));
            sequence.Join(_reward.DOAnchorMin(Vector3.zero, duration));
            _rectTransforms.ForEach(r => sequence.Join(r.DOScale(1.0f, duration)));
            
            sequence.OnComplete(() => sequence = null);
        }
        
        private void AnimationHide(float duration)
        {
            var sequence = DOTween.Sequence();
      
            sequence.Append(_reward.DOAnchorMax(Vector3.one / 2, duration));
            sequence.Join(_reward.DOAnchorMin(Vector3.one / 2, duration));
            _rectTransforms.ForEach(r => sequence.Join(r.DOScale(0.0f, duration)));
            sequence.OnComplete(() =>
            {
                sequence = null;
                _reward.gameObject.SetActive(false);
            });
        }
    }
}