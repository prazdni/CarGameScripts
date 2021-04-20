using DG.Tweening;
using UnityEngine;

namespace CarGameScripts.ContentDataSource.UI
{
    [CreateAssetMenu(fileName = "ScaleConfig", menuName = "Config/ScaleConfig")]
    public sealed class ScaleConfig : ScriptableObject
    {
        public Ease Ease;
        [Range(0f, 5f)] 
        public float Duration;
        public Vector2 Scale;
    }
}