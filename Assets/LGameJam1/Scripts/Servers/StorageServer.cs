using System.Collections.Generic;
using LGameJam1.Scripts.Station;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class StorageServer : MonoBehaviour
    {
        private Dictionary<ResourceType, uint> storage;
            
        private void Awake()
        {
            storage = new Dictionary<ResourceType, uint>();
            God.StorageS = this;
            DontDestroyOnLoad(this);
            Debug.Log("DB Server Awake");
        }
        
        public uint GetResourceCount(ResourceType resourceType)
        {
            if (storage.TryGetValue(resourceType, out var count))
            {
                return count;
            }

            return 0;
        }

        public void AddResource(ResourceType resourceType, uint count)
        {
            storage.TryAdd(resourceType, 0);
            storage[resourceType] += count;
        }

        public bool CheckResources(List<ResourceCount> resourceRecipe, uint count = 1)
        {
            foreach (var resource in resourceRecipe)
            {
                if (!storage.TryGetValue(resource.type, out var storageCount))
                    return false;
                if (storageCount < resource.count * count)
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
                storage[resource.type] -= resource.count * count;
            }
            return true;
        }
    }
}