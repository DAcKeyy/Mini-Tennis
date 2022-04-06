using System;
using UnityEngine;
using UnityEngine.Events;

namespace UnityProject.Actors
{
    public class Racket : MonoBehaviour
    {  
        [SerializeField] [Range(0.01f, 1f)] private float _interpolationStep = .1f;
        [SerializeField] [Range(1f, 30f)] private float _anglePerMeter = 8f;
        [SerializeField] private UnityEvent _collided;
        private Vector3 _racketDefaultPosition;
        private Vector3 _racketDefaultRotationEuler;
        private Camera _gameCamera;

        private void Start()
        {
            _racketDefaultPosition = transform.position;
            _racketDefaultRotationEuler = transform.rotation.eulerAngles;
            _gameCamera = Camera.main;
        }

        private void Update()
        {
            HandleTouch();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _collided.Invoke();
        }

        private void HandleTouch()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                var distanceCameraToRacket = Vector3.Distance(transform.position, _gameCamera.transform.position);
                var touchPosDistanceClipping = new Vector3(touch.position.x, touch.position.y, distanceCameraToRacket);
                var touchToCameraNearClipping = _gameCamera.ScreenToWorldPoint(touchPosDistanceClipping);

                if (touch.phase == TouchPhase.Moved) {
                    MoveAndRotate(touchToCameraNearClipping.x, 1);
                }
            }

            if (Input.touchCount == 0)
            {
                MoveAndRotate(_racketDefaultPosition.x, _interpolationStep);
            }
        }

        private void MoveAndRotate(float newPositionX, float lerpInterpolation)
        {
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(newPositionX, _racketDefaultPosition.y, _racketDefaultPosition.z), 
                lerpInterpolation);
            
            transform.eulerAngles = new Vector3(
                _racketDefaultRotationEuler.x,
                _racketDefaultRotationEuler.y,
                _racketDefaultRotationEuler.z + (_anglePerMeter * (newPositionX - _racketDefaultPosition.x)));
                
        }
    }
}
