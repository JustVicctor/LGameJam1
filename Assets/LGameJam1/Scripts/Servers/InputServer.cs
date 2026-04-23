using LGameJam1.Scripts.Helpers;
using LGameJam1.Scripts.Station;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LGameJam1.Scripts.Servers
{
    public class InputServer : MonoBehaviour
    {
        private PlayerControls _controls;

        private void Awake()
        {
            God.InputS = this;
            DontDestroyOnLoad(this);
            Debug.Log("Input Server Awake");
        }

        private void OnEnable()
        {
            _controls = new PlayerControls();
            _controls.Gameplay.Click.performed += OnClick;
            _controls.Gameplay.Enable();
        }

        private void OnDisable()
        {
            _controls.Gameplay.Click.performed -= OnClick;
            _controls.Gameplay.Enable();
        }

        private void OnClick(InputAction.CallbackContext obj)
        {
            if (God.DraggableS._currentDraggable != null)
                return;
            
            var go = SceneHelpers.RayCastToWorld();
            if (go != null)
            {
                var station = go.GetComponent<StationComponent>();
                if (station != null)
                    station.ShowCraft();
            }
        }
    }
}