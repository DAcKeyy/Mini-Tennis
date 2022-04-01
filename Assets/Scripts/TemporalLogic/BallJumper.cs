using UnityEngine;


public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _minDirection;
    [SerializeField] private float _maxDirection;
    private float _losesLeftToShowAdd = 5;
    private Vector3 _startPosition;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.AddForce(Vector3.right * SetRandomDirection(), ForceMode.Impulse);
        _startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out RacketMover racket))
        {
            //_rigidBody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _rigidBody.AddForce(new Vector3(1 * SetRandomDirection(),_jumpPower, 0), ForceMode.Impulse);
        }

        if (collision.gameObject.TryGetComponent(out LoseCheker lose))
        {
            transform.position = _startPosition;
            _losesLeftToShowAdd--;
            if(_losesLeftToShowAdd <= 0)
            {
                //Appodeal.show(Appodeal.REWARDED_VIDEO);
                _losesLeftToShowAdd = 5;
            }
        }

    }

    private float SetRandomDirection()
    {
        float randomDirection = Random.Range(_minDirection, _maxDirection);
        Debug.Log(randomDirection);
        return (randomDirection);
    }
}