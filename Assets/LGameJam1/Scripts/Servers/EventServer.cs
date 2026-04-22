using System;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class EventServer : MonoBehaviour
    {
        public event Action PlayerInited = delegate { };
        public event Action WorldInited = delegate { };

        private void Awake()
        {
            God.EventS = this;
            DontDestroyOnLoad(this);
            Debug.Log("Events Server Awake");
        }
    }
}
