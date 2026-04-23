using System;
using LGameJam1.Scripts.Helpers;
using LGameJam1.Scripts.Station;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace LGameJam1.Scripts.UI.Workers
{
    public class DraggableComponent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Transform _parentAfterDrag;
        private StationComponent _curStation;

        private Vector3 _defaultLocation;

        private void OnEnable()
        {
            _defaultLocation = transform.position;
            God.EventS.waveStarted += OnWaveStarted;
        }

        private void OnDisable()
        {
            God.EventS.waveStarted -= OnWaveStarted;
        }

        private void OnWaveStarted()
        {
            transform.position = _defaultLocation;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            God.DraggableS._currentDraggable = gameObject;
            _parentAfterDrag = transform.parent;
            transform.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Mouse.current.position.ReadValue();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            God.DraggableS._currentDraggable = null;
            
            if (_curStation != null)
                _curStation.RemoveWorker(this);
            
            var hitGo = SceneHelpers.RayCastToWorld();
            if (hitGo != null)
            {
                var station = hitGo.GetComponent<StationComponent>();
                if (station != null)
                {
                    station.AddWorker(this);
                    _curStation = station;
                    return;
                }
            }
            transform.SetParent(_parentAfterDrag);
        }
    }
}