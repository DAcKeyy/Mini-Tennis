using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityProject.Actors.Collectables;
using UnityProject.Data.Tags_Layers;
using UnityProject.Extensions;
using UnityProject.SceneManagement;
using Random = UnityEngine.Random;

namespace UnityProject.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _jumpPower;
        [MinMaxSlider(-3f, 3f)] public Vector2 _force;
        [SerializeField] private UnityEvent _bounced;
        private Rigidbody _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            
            _rigidBody.AddForce(Vector3.right * GetRandomForce(), ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out Collectable collectable)) 
                collectable.Collect();
            
            if (other.gameObject.CompareTag(ProjectTags.LOOSE_TAG))
                Gameplay.Instance.Lose();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _bounced.Invoke();
            
            if(collision.gameObject.TryGetComponent(out Racket racket))
                _rigidBody.AddForce(new Vector3(1 * GetRandomForce(),_jumpPower, 0), ForceMode.Impulse);
        }

        private float GetRandomForce()
        {
            return Random.Range(_force.Minimum(), _force.Maximum());
        }
    }
}
