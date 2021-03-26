using UnityEngine;

namespace Game.Wheels
{
    internal class Wheel : MonoBehaviour
    {
        [SerializeField] private float _scale;
        
        public void Move(float value)
        {
            transform.Rotate(0, 0, value * _scale);
        }
    }
}