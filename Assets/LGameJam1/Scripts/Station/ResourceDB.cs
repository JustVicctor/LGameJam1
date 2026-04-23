using System;
using System.Collections.Generic;
using UnityEngine;

namespace LGameJam1.Scripts.Station
{
    [Serializable]
    public enum ResourceType
    {
        None,
        Wood,
        Stone
    }

    [Serializable]
    public struct ResourceCount
    {
        public ResourceType type;
        public uint count;
    }

    [Serializable]
    public enum ResourceUsage
    {
        Atk,
        Def
    }
    
    [Serializable]
    public struct Resource
    {
        public ResourceType type;
        public ResourceUsage usage;
        public uint usagePower;
        public uint tickToCraft;
        public Texture2D texture;
        public List<ResourceCount> recipe;
        public uint craftCount;
    }

    [CreateAssetMenu(fileName = "ResourceDB", menuName = "ScriptableObjects/ResourceDB", order = 1)]
    public class ResourceDB : ScriptableObject
    {
        public List<Resource> resources;
    }
}