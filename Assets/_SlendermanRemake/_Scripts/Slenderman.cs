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
            Debug.Log("slender appeared!");

            IEnumerator CheckRoutine(ThirdPersonController player)
            {
                while (true)
                {
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    transform.LookAt(player.transform);

                    if (distance < distanceToKill)
                    {
                        Debug.Log("Player killed");
                        StopAllCoroutines();
                    }

                    if (distance > distanceToEscape)
                    {
                        Debug.Log("Player escaped");
                        OnPlayerEscaped?.Invoke();
                        StopAllCoroutines();
                    }

                    yield return null;
                }
            }
        }
    }
}