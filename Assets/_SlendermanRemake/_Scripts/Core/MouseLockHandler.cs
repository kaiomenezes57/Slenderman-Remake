using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlendermanRemake.Core
{
    public class MouseLockHandler : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
