using LGameJam1.Scripts.Helpers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace LGameJam1.Scripts.UI.Workers
{
    public class DraggableComponent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Transform _parentAfterDrag;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (God.DraggableS._currentDraggable != null)
                return;
            God.DraggableS._currentDraggable = gameObject;
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
            var hitGo = SceneHelpers.RayCastToWorld();
            transform.SetParent(_parentAfterDrag);
        }
    }
}