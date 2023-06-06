using UnityEngine;

namespace SlendermanRemake.Interaction
{
    public class BatteryCharger : Pickable
    {
        private void Start()
        {
            tipText = "press \"E\" to pick and use battery charger";
        }

        public override void Pick()
        {
            int amount = Random.Range(20, 40);
            FindObjectOfType<Battery>().ChargeBattery(amount);

            base.Pick();
        }

        private void OnBecameInvisible()
        {
            Debug.Log($"Sumiu");
        }

        private void OnBecameVisible()
        {
            Debug.Log($"Apareceu");
        }
    }
}