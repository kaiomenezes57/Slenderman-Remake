using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SlendermanRemake
{
    public class Battery : MonoBehaviour
    {
        [Header("Setup")]
        [Range(1, 10)] [SerializeField] private int batteryMultiplier;
        [Range(40, 100)] [SerializeField] private int batteryRandomMinValue;

        public event System.Action OnBatteryDown;
        public event System.Action OnBatteryCharge;
        private Slider _slider;

        private readonly int _maxBattery = 100;
        private float _currentBattery;

        private void Start()
        {
            FindObjectOfType<FlashlightHandler>().OnIntensityChange += (state) => {
                StopAllCoroutines();
                if (state) { StartCoroutine(BatteryRoutine()); }
            };

            _currentBattery = Random.Range(batteryRandomMinValue, _maxBattery);
            
            _slider = GetComponent<Slider>();
            _slider.maxValue = _maxBattery;
            _slider.value = _currentBattery;
            
            StartCoroutine(BatteryRoutine());
        }

        private IEnumerator BatteryRoutine()
        {
            while (_currentBattery > 0f)
            {
                _currentBattery -= Time.deltaTime * batteryMultiplier;
                _slider.value = _currentBattery;
                yield return null;
            }

            _currentBattery = 0f;
            _slider.value = _currentBattery;
            OnBatteryDown?.Invoke();
        }

        public void ChargeBattery(int amount)
        {
            _currentBattery += amount;
            _slider.value = _currentBattery;
            OnBatteryCharge?.Invoke();
        }
    }
}
