using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class DraggableServer : MonoBehaviour
    {
        public GameObject _currentDraggable;
        private void Awake()
        {
            Debug.Log("Draggable Server Awake");
        }
    }
}