using UnityEngine;

namespace SlendermanRemake.Trigger
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class GameTrigger : MonoBehaviour
    {
        [SerializeField] protected bool destroyAfterUse = true;

        private void Start()
        {
            if (TryGetComponent(out BoxCollider collider))
            {
                collider.enabled = true;
                collider.isTrigger = true;
                return;
            }

            Debug.LogError($"Trigger \"{name}\" doesn't have an box collider");
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) { return; }
            TriggerAction();

            if (destroyAfterUse) 
            { 
                Destroy(gameObject); 
            }
        }

        protected abstract void TriggerAction();
    }
}
