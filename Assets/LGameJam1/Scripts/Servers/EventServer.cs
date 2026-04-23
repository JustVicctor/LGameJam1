using System;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    [DefaultExecutionOrder(-1)]
    public class EventServer : MonoBehaviour
    {
        public Action GameStarted = delegate { };
        public Action GameEnded = delegate { };
        
        public Action TickTime = delegate { };
        public Action DayEnd = delegate { };
        
        
        public Action atkItemChanged = delegate { };
        public Action defItemChanged = delegate { };
        
        public Action timerChanged = delegate { };
        
        public Action waveChanged = delegate { };
        public Action waveEnded = delegate { };
        public Action waveStarted = delegate { };

        private void Awake()
        {
            God.EventS = this;
            DontDestroyOnLoad(this);
            Debug.Log("Events Server Awake");
        }
    }
}
