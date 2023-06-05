using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlendermanRemake
{
    public partial class SlendermanHandler : MonoBehaviour
    {
        [SerializeField] FMODUnity.EventReference jumpscareAudioEvent;
        [SerializeField] private Slenderman slenderman;
        [SerializeField] private List<int> appearChances = new();
        public static event Action OnSlenderAppears;

        private readonly float interval = 25f;
        private int currentIndex;

        private void Start()
        {
            slenderman.gameObject.SetActive(false);
            slenderman.OnPlayerEscaped += PerformDisappear;
            
            StartCoroutine(AppearRoutine());
        }

        private void PerformAppear()
        {
            StopAllCoroutines();

            ThirdPersonController player = FindObjectOfType<ThirdPersonController>();
            slenderman.transform.position = GetSlendermanSpawnPoint(player.transform);
            slenderman.gameObject.SetActive(true);

            OnSlenderAppears?.Invoke();
            FMODUnity.RuntimeManager.PlayOneShot(jumpscareAudioEvent, player.transform.position);
        }

        private void PerformDisappear()
        {
            slenderman.gameObject.SetActive(false);
            StartCoroutine(AppearRoutine());
        }


        private IEnumerator AppearRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(interval);
                if (RandomizeSpawnByChance()) { PerformAppear(); }
            }
        }
       
        private void OnDestroy()
        {
            slenderman.OnPlayerEscaped -= PerformDisappear;
        }
    }

    public partial class SlendermanHandler
    {
        public void IncreaseAppearChance()
        {
            StopAllCoroutines();

            if (appearChances.Count > (currentIndex + 1)) { currentIndex++; }
            StartCoroutine(AppearRoutine());
        }

        private bool RandomizeSpawnByChance()
        {
            int randomNumber = UnityEngine.Random.Range(0, 100);
            return randomNumber <= appearChances[currentIndex];
        }

        private Vector3 GetSlendermanSpawnPoint(Transform playerPosition)
        {
            float randomRange = 5f;
            float forwardOffset = 20f;

            Vector3 playerPos = playerPosition.position;
            Vector3 spawnPos = playerPos + (playerPosition.right * UnityEngine.Random.Range(-randomRange, randomRange)) + (playerPosition.forward * forwardOffset);
           
            Debug.Log($"you = {playerPosition} | slender = {spawnPos}");
            return spawnPos;
        }
    }
}
