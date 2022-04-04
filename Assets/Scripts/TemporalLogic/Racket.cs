using UnityEngine;

namespace UnityProject.TemporalLogic
{
    public class Racket : MonoBehaviour
    {  
        [Header("Rotates racket to one radian (-0.5, 0.5)")]
        [SerializeField] [Range(0.01f, 1f)] private float _interpolationStep;
        [SerializeField] [Range(1f, 30f)] private float _anglePerMeter;
        private Vector3 _racketDefaultPosition;
        private Vector3 _racketDefaultRotationEuler;
        private Vector3 _touchDefaultPosition;
        private Camera _gameCamera;

        private void Start()
        {
            _racketDefaultPosition = transform.position;
            _racketDefaultRotationEuler = transform.rotation.eulerAngles;
            _gameCamera = Camera.main;
            
            if (_gameCamera != null) 
                _touchDefaultPosition = _gameCamera.ScreenToWorldPoint(new Vector3(_gameCamera.pixelWidth, 0, 0));
        }

        private void Update()
        {
            HandleTouch();
        }

        private void HandleTouch()
        {
            var pathFactor = transform.position.x / _touchDefaultPosition.x;
            
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                var distanceCameraToRacket = Vector3.Distance(transform.position, _gameCamera.transform.position);
                var touchPosDistanceClipping = new Vector3(touch.position.x, touch.position.y, distanceCameraToRacket);
                var touchToCameraNearClipping = _gameCamera.ScreenToWorldPoint(touchPosDistanceClipping);

                if (touch.phase == TouchPhase.Moved) {
                    MoveAndRotate(touchToCameraNearClipping.x, pathFactor, 1);
                }
            }

            if (Input.touchCount == 0)
            {
                MoveAndRotate(_racketDefaultPosition.x, pathFactor, _interpolationStep);
            }
        }

        private void MoveAndRotate(float newPositionX, float pathFactor, float lerpInterpolation)
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
