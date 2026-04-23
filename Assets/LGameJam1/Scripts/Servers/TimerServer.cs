using System;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class TimerServer : MonoBehaviour
    {

        [SerializeField, Tooltip("In Seconds")]
        public float duration = 45;

        private bool active = false;
        private float timer = 0;
        
        [NonSerialized]
        public int tickAmount = 30;
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
            God.EventS.waveStarted += OnWaveStarted;
            God.EventS.waveEnded += OnWaveEnded;
        }

        private void OnDisable()
        {
            God.EventS.waveStarted -= OnWaveStarted;
            God.EventS.waveEnded -= OnWaveEnded;
        }

        private void OnWaveStarted()
        {
            var wave = God.WaveS.GetWave();
            tickAmount = wave.WaveTime;
            active = true;
            curTick = 0;
            God.EventS.timerChanged();
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
                    active = false;
                    God.WaveS.UpWaves();
                    God.EventS.waveEnded();
                }
                timer = 0;
            }
        }

        private void OnWaveEnded()
        {
            active = false;
        }

        public void ResetTimers()
        {
            curTick = 0;
        }
    }
}