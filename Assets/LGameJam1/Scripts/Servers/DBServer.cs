using System;
using System.Linq;
using LGameJam1.Scripts.Station;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class DBServer : MonoBehaviour
    {
        public ResourceDB resourceDB;

        private void Awake()
        {
            God.DBS = this;
            DontDestroyOnLoad(this);
            Debug.Log("DB Server Awake");
        }

        public void GetResource(ResourceType resourceType, out Resource outResource)
        {
            outResource = new Resource
            {
                type = ResourceType.None
            };
            
            foreach (var item in resourceDB.resources.Where(item => item.type == resourceType))
            {
                outResource = item;
                return;
            }
        }
    }
}