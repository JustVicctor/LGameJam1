using System.Collections.Generic;
using LGameJam1.Scripts.Station;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    [DefaultExecutionOrder(1)]
    public class StorageServer : MonoBehaviour
    {
        class StorageItem
        {
            public uint count = 0;
            public uint power = 0;
            public ResourceUsage usage = ResourceUsage.Def;
        }
        private Dictionary<ResourceType, StorageItem> storage;
            
        private void Awake()
        {
            God.StorageS = this;
            DontDestroyOnLoad(this);
            Debug.Log("DB Server Awake");
        }

        private void OnEnable()
        {
            storage = new Dictionary<ResourceType, StorageItem>();
            foreach (var res in God.DBS.resourceDB.resources)
            {
                var storageItem = new StorageItem
                {
                    count = 0,
                    power = res.usagePower,
                    usage = res.usage
                };
                storage[res.type] = storageItem;
            }
        }

        public void GetResourceCountAndValue(ResourceType resourceType, out uint count, out uint power)
        {
            count = 0;
            power = 0;
            
            if (storage.TryGetValue(resourceType, out var item))
            {
                power = item.power;
                count = item.count;
            }
        }

        public void AddResource(ResourceType resourceType, uint count)
        {
            storage[resourceType].count += count;
            if (storage[resourceType].usage == ResourceUsage.Atk)
                God.EventS.atkItemChanged();
            else
                God.EventS.defItemChanged();
        }

        private bool CheckResources(List<ResourceCount> resourceRecipe, uint count = 1)
        {
            foreach (var resource in resourceRecipe)
            {
                if (!storage.TryGetValue(resource.type, out var storageCount))
                    return false;
                if (storageCount.count < resource.count * count)
                    return false;
            }
            return true;
        }

        public bool TryGetResources(List<ResourceCount> resourceRecipe, uint count = 1)
        {
            if (!CheckResources(resourceRecipe, count))
                return false;
            
            foreach (var resource in resourceRecipe)
            {
                storage[resource.type].count -= resource.count * count;
            }
            return true;
        }
    }
}