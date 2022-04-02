using UnityEngine;

namespace UnityProject.TemporalLogic
{
    public class Racket : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxRotationAngle;
        private Vector3 defaultPosition;
        private Vector3 pathLenght;
        private Camera gameCamera;

        private void Start()
        {
            defaultPosition = transform.position;
            
            gameCamera = Camera.main;
            
            if (gameCamera != null) 
                pathLenght = gameCamera.ScreenToWorldPoint(new Vector3(gameCamera.pixelWidth, 0, 0));
        }

        private void Update()
        {
            var pathFactor = transform.position.x / pathLenght.x;
            
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                var touchPosition = gameCamera.ScreenToWorldPoint(touch.position);
                print(touch.position);
                if (touch.phase == TouchPhase.Moved)
                {
                    MoveAndRotate(touchPosition.x, pathFactor, 1);
                }
            }

            if (Input.touchCount == 0)
            {
                MoveAndRotate(defaultPosition.x, pathFactor, _speed);
            }
        }

        private void MoveAndRotate(float newPositionX, float pathFactor, float lerpInterpolation)
        {
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(newPositionX, defaultPosition.y, defaultPosition.z), 
                lerpInterpolation);
            
            //transform.rotation = Quaternion.Euler(0f, 0f, _maxRotationAngle * pathFactor);
        }
    }
}
