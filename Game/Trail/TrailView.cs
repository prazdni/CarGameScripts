using System;
using JoostenProductions;
using Tools;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Trail
{
    internal class TrailView : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private TrailRenderer _trailRenderer;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        public void Init()
        {
            UpdateManager.SubscribeToUpdate(Move);
        }
        
        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        public void Move()
        {
            if (Input.touchCount > 0)
            {
                _trailRenderer.enabled = true;
                transform.position = _camera.ScreenToWorldPoint(Input.touches[0].position) + Vector3.forward;
            }
            else
            {
                _trailRenderer.enabled = false;
            }
            
            #if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                transform.position = _camera.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            }
            #endif
            
        }
    }
}