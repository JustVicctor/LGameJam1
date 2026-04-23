using System;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    [DefaultExecutionOrder(-1)]
    public class EventServer : MonoBehaviour
    {
        public Action TickTime = delegate { };

        public Action atkItemChanged = delegate { };
        public Action defItemChanged = delegate { };

        public Action timerChanged = delegate { };

        public Action waveEnded = delegate { };
        public Action waveStarted = delegate { };

        public Action GameEnd = delegate { };
        public Action GameWin = delegate { };

        private void Awake()
        {
            God.EventS = this;
            DontDestroyOnLoad(this);
            Debug.Log("Events Server Awake");
        }
    }
}
