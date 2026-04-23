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
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
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
                }
            }
            else
            {
                transform.SetParent(_parentAfterDrag);
            }
        }
    }
}