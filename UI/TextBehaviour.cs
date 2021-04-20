using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CarGameScripts.UI
{
    public class TextBehaviour : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField, Range(0.0f, 5.0f)] private float _duration;
        [SerializeField] private Ease _ease;

        public void ChangeText(string text)
        {
            _text.DOKill();
            
            _text.DOText(text, _duration).SetEase(_ease);
        }
    }
}