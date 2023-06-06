using Cinemachine;
using UnityEngine;

namespace SlendermanRemake.Trigger
{
    public class InteriorTrigger : GameTrigger
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        private CinemachineFreeLook _mainCamera;

        private void Start()
        {
            _mainCamera = FindObjectOfType<CinemachineFreeLook>();
        }

        protected override void TriggerAction()
        {
            _mainCamera.enabled = false;
            _camera.enabled = true;
        }

        protected override void TriggerExit()
        {
            _mainCamera.enabled = true;
            _camera.enabled = false;
        }
    }
}
