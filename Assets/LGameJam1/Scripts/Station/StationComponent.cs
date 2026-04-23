using System;
using System.Collections.Generic;
using LGameJam1.Scripts.UI.Slider;
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
        
        public Sprite resourceImage;
        
        [NonSerialized]
        public List<DraggableComponent> Workers;

        private bool _isCrafted = false;
        
        private Resource _resource;
        private uint _curTickToCraft = 0;
        
        public SliderUI slider;

        private void Awake()
        {
            Workers = new List<DraggableComponent>();
        }

        private void OnEnable()
        {
            God.DBS.GetResource(resourceType, out _resource);
            God.EventS.TickTime += OnTickToCraft;
            God.EventS.waveStarted += OnWaveStarted;
            
            God.DraggableS._spirtesMap.Add(_resource.type, this);
        }

        private void OnWaveStarted()
        {
            ResetSelected();
            _isCrafted = false;
            _curTickToCraft = 0;
            slider.ResetSlider();
            slider.HideSlider();
            Workers.Clear();
        }

        private void OnDisable()
        {
            God.EventS.TickTime -= OnTickToCraft;
            God.EventS.waveStarted -= OnWaveStarted;
        }

        private void FixedUpdate()
        {
            if (_isCrafted)
                return;
            
            if (Workers.Count == 0)
                return;
            
            if (God.StorageS.TryGetResources(_resource.recipe, (uint)Workers.Count))
            {
                slider.ShowSlider();
                _isCrafted = true;
            }
        }

        private void ResetSelected()
        {
            if (God.DraggableS._currentOutline != null)
            {
                Destroy(God.DraggableS._currentOutline);
            }

            foreach (var res in God.DraggableS._currentResoruses)
            {
                Destroy(res);
            }
        }

        public void ShowCraft()
        {
            God.Hud.ShowCraftImage(craftImage);
            ResetSelected();

            var outline = new GameObject();
            var image = outline.AddComponent<SpriteRenderer>();
            image.sprite = outlineImage;
            image.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
            outline.transform.position = transform.position + Vector3.down * 0.1f;
            outline.transform.rotation = transform.rotation;
            outline.transform.localScale = transform.localScale;
            God.DraggableS._currentOutline = outline;

            foreach (var res in _resource.recipe)
            {
                var stationComponent = God.DraggableS._spirtesMap[res.type];
                var sprite = stationComponent.resourceImage;
                var go = stationComponent.gameObject;
                var spriteGO = new GameObject();
                var spriteRenderer = spriteGO.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;
                spriteRenderer.sortingOrder = go.GetComponent<SpriteRenderer>().sortingOrder + 1;
                spriteGO.transform.position = go.transform.position + Vector3.down * 0.05f;
                spriteGO.transform.rotation = go.transform.rotation;
                spriteGO.transform.localScale = go.transform.localScale;
                God.DraggableS._currentResoruses.Add(spriteGO);
            }
        }

        private void OnTickToCraft()
        {
            if (!_isCrafted)
                return;
            
            _curTickToCraft++;
            slider.SetSlider((float)_curTickToCraft / (float)_resource.tickToCraft);
            if (_curTickToCraft == _resource.tickToCraft)
            {
                _curTickToCraft = 0;
                slider.ResetSlider();
                slider.HideSlider();
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
            {
                _isCrafted = true;
                slider.ShowSlider();
            }
        }

        public void RemoveWorker(DraggableComponent draggableComponent)
        {
            Workers.Remove(draggableComponent);
            if (Workers.Count == 0)
            {
                slider.HideSlider();
                _isCrafted = false;
            }
        }
    }
}
