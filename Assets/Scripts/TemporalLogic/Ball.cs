using UnityEngine;

namespace UnityProject.TemporalLogic
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _jumpPower;
        [SerializeField] private float _minDirection;
        [SerializeField] private float _maxDirection;
        private float losesLeftToShowAdd = 5;
        private Vector3 startPosition;
        private Rigidbody rigidBody;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            rigidBody.AddForce(Vector3.right * SetRandomDirection(), ForceMode.Impulse);
            startPosition = transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Racket racket))
            {
                //_rigidBody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
                rigidBody.AddForce(new Vector3(1 * SetRandomDirection(),_jumpPower, 0), ForceMode.Impulse);
            }

            if (collision.gameObject.TryGetComponent(out LoseChecker lose))
            {
                transform.position = startPosition;
                
                //TODO: Вынести losesLeftToShowAdd в отдельный класс подсчета поражений
                losesLeftToShowAdd--;
                if(losesLeftToShowAdd <= 0)
                {
                    //Appodeal.show(Appodeal.REWARDED_VIDEO);
                    losesLeftToShowAdd = 5;
                }
            }

        }

        private float SetRandomDirection()
        {
            var randomDirection = Random.Range(_minDirection, _maxDirection);
            Debug.Log(randomDirection);
            return (randomDirection);
        }
    }
}
