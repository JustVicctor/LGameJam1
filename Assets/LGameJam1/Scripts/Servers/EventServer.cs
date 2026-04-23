using System;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    [DefaultExecutionOrder(-1)]
    public class EventServer : MonoBehaviour
    {
        public Action GameStarted = delegate { };
        public Action TickTime = delegate { };
        public Action GameEnded = delegate { };

        private void Awake()
        {
            God.EventS = this;
            DontDestroyOnLoad(this);
            Debug.Log("Events Server Awake");
        }
    }
}
