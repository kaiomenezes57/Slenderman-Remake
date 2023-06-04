using UnityEngine;

namespace SlendermanRemake
{
    public class FlashlightHandler : MonoBehaviour
    {
        private FlashlightIntensity initialIntensity = FlashlightIntensity.Weak;

        private void Start()
        {
            SetLightIntensity(initialIntensity);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.F)) { return; }
            initialIntensity = GetNextIntensity(initialIntensity);
            SetLightIntensity(initialIntensity);
        }

        public void SetLightIntensity(FlashlightIntensity flashlightIntensity)
        {
            Light smartphoneLight = GetComponentInChildren<Light>();
            smartphoneLight.intensity = (int)flashlightIntensity;
        }

        private FlashlightIntensity GetNextIntensity(FlashlightIntensity current)
        {
            switch (current)
            {
                case FlashlightIntensity.Off:
                    return FlashlightIntensity.Weak;

                case FlashlightIntensity.Weak:
                    return FlashlightIntensity.Medium;

                case FlashlightIntensity.Medium:
                    return FlashlightIntensity.Hard;

                case FlashlightIntensity.Hard:
                    return FlashlightIntensity.Off;
            }

            return FlashlightIntensity.Weak;
        }
    }

    public enum FlashlightIntensity { Off = 0, Weak = 1, Medium = 3, Hard = 5 }
}
