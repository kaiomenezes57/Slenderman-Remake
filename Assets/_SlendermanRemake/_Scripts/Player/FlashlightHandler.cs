using UnityEngine;

namespace SlendermanRemake
{
    public class FlashlightHandler : MonoBehaviour
    {
        public event System.Action<bool> OnIntensityChange;
        private FlashlightIntensity _currentIntensity;
        private bool _canUse = true;

        private void Start()
        {
            Battery battery = FindObjectOfType<Battery>();
            SetLightIntensity(FlashlightIntensity.Medium);

            battery.OnBatteryCharge += () => {
                if (_currentIntensity == FlashlightIntensity.Off) 
                {
                    SetLightIntensity(FlashlightIntensity.Weak);
                    _canUse = true;
                }
            };

            battery.OnBatteryDown += () => {
                SetLightIntensity(FlashlightIntensity.Off);
                _canUse = false;
            };
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.F) || !_canUse) { return; }
            SetLightIntensity(GetNextIntensity(_currentIntensity));
        }

        private void SetLightIntensity(FlashlightIntensity flashlightIntensity)
        {
            Light smartphoneLight = GetComponentInChildren<Light>();
            smartphoneLight.intensity = (int)flashlightIntensity;
            _currentIntensity = flashlightIntensity;
            
            bool condition = _currentIntensity != FlashlightIntensity.Off;
            OnIntensityChange?.Invoke(condition);
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
            
                default:
                    break;
            }

            return FlashlightIntensity.Weak;
        }
    }

    public enum FlashlightIntensity { Off = 0, Weak = 1, Medium = 3, Hard = 5 }
}
