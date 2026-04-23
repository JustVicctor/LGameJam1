using System;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class TimerServer : MonoBehaviour
    {
        [SerializeField]
        public int tickAmount = 30;

        [SerializeField, Tooltip("In Seconds")]
        public float duration = 60;

        private bool active = false;
        private float timer = 0;
        
        [NonSerialized]
        public int curTick = 0;
        
        private void Awake()
        {
            God.TimerS = this;
            DontDestroyOnLoad(this);
            Debug.Log("DB Server Awake");
        }

        private void OnEnable()
        {
            God.EventS.GameStarted += Active;
            God.EventS.GameEnded += Deactive;
        }

        private void OnDisable()
        {
            God.EventS.GameStarted -= Active;
            God.EventS.GameEnded -= Deactive;
        }

        private void Update()
        {
            if (!active)
                return;
            
            timer += Time.deltaTime;
            if (timer >= duration/tickAmount)
            {
                God.EventS.timerChanged();
                God.EventS.TickTime();
                curTick++;
                if (curTick >= tickAmount)
                {
                    God.EventS.DayEnd();
                    curTick = 0;
                }
                timer = 0;
            }
        }
        
        public void Active()
        {
            active = true;
        }

        public void Deactive()
        {
            active = false;
        }
    }
}