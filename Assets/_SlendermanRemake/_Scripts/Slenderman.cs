using StarterAssets;
using System;
using System.Collections;
using UnityEngine;

namespace SlendermanRemake
{
    public class Slenderman : MonoBehaviour
    {
        [SerializeField] private float distanceToKill;
        [SerializeField] private float distanceToEscape;
        public event Action OnPlayerEscaped;

        private void OnEnable()
        {
            StartCoroutine(CheckRoutine(FindObjectOfType<ThirdPersonController>()));

            IEnumerator CheckRoutine(ThirdPersonController player)
            {
                while (true)
                {
                    float distance = Vector3.Distance(transform.position, player.transform.position);

                    if (distance < distanceToKill)
                    {
                        StopAllCoroutines();
                    }

                    if (distance > distanceToEscape)
                    {
                        StopAllCoroutines();
                        OnPlayerEscaped?.Invoke();
                    }

                    yield return null;
                }
            }
        }
    }
}