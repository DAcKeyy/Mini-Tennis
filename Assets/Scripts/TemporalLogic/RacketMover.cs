using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxRotationAngle;
    private Vector3 _defaultPostion;
    private Vector3 _pathLengt;

    private void Start()
    {
        _defaultPostion = transform.position;
        _pathLengt = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth, 0, 0 ));
    }

    private void FixedUpdate()
    {
        float pathPercent = transform.position.x / _pathLengt.x * 100;
        Vector3 touchPosition;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Moved)
            {
                MoveAndRotate(touchPosition.x, pathPercent, 1);
                //transform.position = new Vector3((transform.position.x + touch.deltaPosition.x * _speed) , transform.position.y, transform.position.z);
            }
        }

        if (Input.touchCount == 0)
        {
            MoveAndRotate(_defaultPostion.x, pathPercent, _speed);
        }
    }

    private void MoveAndRotate(float newPositionX, float pathPercent, float speed)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(newPositionX, _defaultPostion.y, _defaultPostion.z), speed);
        transform.rotation = Quaternion.Euler(0, 0, _maxRotationAngle * pathPercent / 100);
    }
}
