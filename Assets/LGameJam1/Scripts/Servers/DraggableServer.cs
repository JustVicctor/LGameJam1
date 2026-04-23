using System;
using System.Collections.Generic;
using LGameJam1.Scripts.Station;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class DraggableServer : MonoBehaviour
    {
        [NonSerialized]
        public GameObject _currentDraggable;

        [NonSerialized]
        public GameObject _currentOutline;
        
        public List<GameObject> _currentResoruses;

        public Dictionary<ResourceType, StationComponent> _spirtesMap;
        
        private void Awake()
        {
            _spirtesMap = new Dictionary<ResourceType, StationComponent>();
            _currentResoruses = new List<GameObject>();
            God.DraggableS = this;
            DontDestroyOnLoad(this);
            Debug.Log("Draggable Server Awake");
        }
    }
}