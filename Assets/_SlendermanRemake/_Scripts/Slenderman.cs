using Cinemachine;
using StarterAssets;
using System;
using System.Collections;
using UnityEngine;

namespace SlendermanRemake
{
    public class Slenderman : MonoBehaviour
    {
        private ThirdPersonController player;
        public event Action OnPlayerEscaped;

        private void Start()
        {
            player = FindAnyObjectByType<ThirdPersonController>();
        }

        private void Update()
        {
            float y = Terrain.activeTerrain.SampleHeight(transform.position);
            
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            transform.LookAt(player.transform.position);
        }

        private void OnBecameVisible()
        {
            StopAllCoroutines();
            StartCoroutine(PerformTimer(timer: 5f, callback: () => {
                GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
                player.Die();
            }));
        }

        private void OnBecameInvisible()
        {
            StopAllCoroutines();
            StartCoroutine(PerformTimer(timer: 10f, callback: () => {
                OnPlayerEscaped?.Invoke();
            }));
        }

        private IEnumerator PerformTimer(float timer, Action callback)
        {
            while (timer > 0f)
            {
                timer--;
                yield return new WaitForSeconds(1f);
            }

            callback?.Invoke();
        }
    }
}