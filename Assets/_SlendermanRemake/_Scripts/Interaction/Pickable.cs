using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlendermanRemake.Interaction
{
    public abstract class Pickable : MonoBehaviour
    {
        private bool playerInTrigger;
        protected string tipText;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) { return; }
            TipText.Instance.SetTipText(tipText);
            playerInTrigger = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) { return; }
            TipText.Instance.SetTipText("");
            playerInTrigger = false;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.E) || !playerInTrigger) { return; }
            
            Pick();
            Destroy(gameObject);
        }

        public virtual void Pick()
        {
            TipText.Instance.SetTipText("");
        }
    }
}
