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

        public void ClearStorage()
        {
            foreach (var kvp in storage)
            {
                kvp.Value.count = 0;
            }
        }

        public void GetOverall(out uint atk, out uint def)
        {
            {
                God.StorageS.GetResourceCountAndValue(ResourceType.Stone, out uint stoneCount, out uint stonePower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Tools, out uint toolCount, out uint toolPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Ore, out uint oreCount, out uint orePower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Ingots, out uint ingotCount, out uint ingotPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Weapon, out uint weaponCount, out uint weaponPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Bow, out uint bowCount, out uint bowPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Spell, out uint spellCount, out uint spellPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Rune, out uint runeCount, out uint runePower);

                atk =
                    stoneCount * stonePower +
                    toolCount * toolPower +
                    oreCount * orePower +
                    ingotCount * ingotPower +
                    weaponCount * weaponPower +
                    bowCount * bowPower +
                    spellCount * spellPower +
                    runeCount * runePower;
            }

            {
                God.StorageS.GetResourceCountAndValue(ResourceType.Wood, out uint stoneCount, out uint stonePower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Planks, out uint toolCount, out uint toolPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Shield, out uint oreCount, out uint orePower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Leather, out uint ingotCount, out uint ingotPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Clothes, out uint weaponCount, out uint weaponPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Armor, out uint bowCount, out uint bowPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Mana, out uint spellCount, out uint spellPower);
                God.StorageS.GetResourceCountAndValue(ResourceType.Golem, out uint runeCount, out uint runePower);

                def =
                    stoneCount * stonePower +
                    toolCount * toolPower +
                    oreCount * orePower +
                    ingotCount * ingotPower +
                    weaponCount * weaponPower +
                    bowCount * bowPower +
                    spellCount * spellPower +
                    runeCount * runePower;
            }
        }
    }
}