using DG.Tweening;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace CarGameScripts.Reward
{
    public class InstallView : MonoBehaviour, IInitialize<DailyRewardController>
    {
        [SerializeField] private DailyRewardView _dailyRewardView;
        [SerializeField] private Button _popupButton;
        private Vector3 _localScale;

        public void Init(DailyRewardController initObject)
        {
            initObject.Init(_dailyRewardView);
            _localScale = transform.localScale;
        }

        public void SetPopupButtonInteractable(bool isInteractable)
        {
            _popupButton.interactable = isInteractable;
            _popupButton.transform.DOKill();

            if (isInteractable)
            {
                _popupButton.transform.DOScale(_localScale, 0.5f);
            }
            else
            {
                _popupButton.transform.DOScale(0.0f, 0.5f);
            }
        }
    }
}