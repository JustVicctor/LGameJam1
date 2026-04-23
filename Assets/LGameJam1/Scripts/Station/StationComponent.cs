using System;
using System.Collections.Generic;
using LGameJam1.Scripts.UI.Workers;
using UnityEngine;

namespace LGameJam1.Scripts.Station
{
    public class StationComponent : MonoBehaviour
    {
        public ResourceType resourceType;
        
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
            
            if (God.StorageS.TryGetResources(_resource.recipe))
            {
                _isCrafted = true;
            }
        }

        private void OnTickToCraft()
        {
            if (!_isCrafted)
                return;
            
            _curTickToCraft++;
            Debug.Log(_curTickToCraft);
            if (_curTickToCraft == _resource.tickToCraft)
            {
                _curTickToCraft = 0;
                DoCraft();
                Debug.Log("Crafted");
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
