using System;
using UnityEngine;
using UnityEngine.Events;
using UnityProject.Data.Collectables;

namespace UnityProject.Actors.Collectables
{
    [RequireComponent(typeof(Collider))]
    public abstract class Collectable : MonoBehaviour
    {
        public Action<CollectableItem> Collected;
        [SerializeField] private CollectableItem _item;
        [SerializeField] private UnityEvent _collected;

        public void Reset()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        public virtual void Collect()
        {
            _collected.Invoke();
            Collected?.Invoke(_item);    
            Destroy(gameObject);
        }
    }
}