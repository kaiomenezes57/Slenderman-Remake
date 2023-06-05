using UnityEngine;

namespace SlendermanRemake.Audio
{
    public class PlayerGasp : MonoBehaviour
    {
        [SerializeField] FMODUnity.EventReference eventReference;

        private void Start()
        {
            SlendermanHandler.OnSlenderAppears += OnSlenderAppears;
        }

        private void OnSlenderAppears()
        {
            FMODUnity.RuntimeManager.PlayOneShot(eventReference, transform.position);
        }

        private void OnDestroy()
        {
            SlendermanHandler.OnSlenderAppears -= OnSlenderAppears;
        }
    }
}
