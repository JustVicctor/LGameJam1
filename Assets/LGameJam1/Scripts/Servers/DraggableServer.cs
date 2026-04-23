using System;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class DraggableServer : MonoBehaviour
    {
        [NonSerialized]
        public GameObject _currentDraggable;

        [NonSerialized]
        public GameObject _currentOutline;
        [NonSerialized]
        public GameObject _currentSelected;
        
        private void Awake()
        {
            God.DraggableS = this;
            DontDestroyOnLoad(this);
            Debug.Log("Draggable Server Awake");
        }
    }
}