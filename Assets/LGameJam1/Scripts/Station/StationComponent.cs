using System;
using System.Collections.Generic;
using LGameJam1.Scripts.UI.Workers;
using UnityEngine;
using UnityEngine.UI;

namespace LGameJam1.Scripts.Station
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class StationComponent : MonoBehaviour
    {
        public ResourceType resourceType;

        public Image craftImage;

        public Sprite outlineImage;
        
        [NonSerialized]
        public List<DraggableComponent> Workers;

        private bool _isCrafted = false;
        
        private Resource _resource;
        private uint _curTickToCraft = 0;

        private void Awake()
        {
            Workers = new List<DraggableComponent>();
        }

        private void OnEnable()
        {
            God.DBS.GetResource(resourceType, out _resource);
            God.EventS.TickTime += OnTickToCraft;
        }

        private void OnDisable()
        {
            God.EventS.TickTime -= OnTickToCraft;
        }

        private void FixedUpdate()
        {
            if (_isCrafted)
                return;
            
            if (Workers.Count == 0)
                return;
            
            if (God.StorageS.TryGetResources(_resource.recipe, (uint)Workers.Count))
            {
                _isCrafted = true;
            }
        }

        public void ShowCraft()
        {
            God.Hud.ShowCraftImage(craftImage);
            if (God.DraggableS._currentSelected != null)
                Destroy(God.DraggableS._currentSelected);
            var outline = new GameObject();
            var image = outline.AddComponent<SpriteRenderer>();
            image.sprite = outlineImage;
            image.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
            outline.transform.position = transform.position;
            outline.transform.rotation = transform.rotation;
            outline.transform.localScale = transform.localScale * 1f;
            God.DraggableS._currentSelected = outline;
        }

        private void OnTickToCraft()
        {
            if (!_isCrafted)
                return;
            
            _curTickToCraft++;
            if (_curTickToCraft == _resource.tickToCraft)
            {
                _curTickToCraft = 0;
                DoCraft();
            }
        }

        private void DoCraft()
        {
            God.StorageS.AddResource(_resource.type, _resource.craftCount * (uint)Workers.Count);
            _isCrafted = false;
        }

        public void AddWorker(DraggableComponent draggableComponent)
        {
            Workers.Add(draggableComponent);
            if (_curTickToCraft != 0)
                _isCrafted = true;
        }

        public void RemoveWorker(DraggableComponent draggableComponent)
        {
            Workers.Remove(draggableComponent);
            if (Workers.Count == 0)
                _isCrafted = false;
        }
    }
}
