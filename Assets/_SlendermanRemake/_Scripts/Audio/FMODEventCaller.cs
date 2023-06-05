using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SlendermanRemake
{
    public class FMODEventCaller : MonoBehaviour
    {
        public void Call(string eventName)
        {
            FMODUnity.RuntimeManager.PlayOneShot(eventName, transform.position);
        }
    }
}
