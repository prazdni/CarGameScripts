using DG.Tweening;
using UnityEngine;

namespace CarGameScripts.ContentDataSource.UI
{
    [CreateAssetMenu(fileName = "ColorConfig", menuName = "Config/ColorConfig")]
    public class ColorConfig : ScriptableObject
    {
        public Ease Ease;
        [Range(0f, 5f)] 
        public float Duration;
        public Color Color;
    }
}