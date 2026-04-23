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
            God.EventS.GameStarted += OnGameStarted;
            God.EventS.GameEnded += OnGameEnded;
            God.EventS.waveStarted += OnWaveStarted;
        }

        private void OnDisable()
        {
            God.EventS.GameStarted -= OnGameStarted;
            God.EventS.GameEnded -= OnGameEnded;
            God.EventS.waveStarted -= OnWaveStarted;
        }

        private void OnWaveStarted()
        {
            var wave = God.WaveS.GetWave();
            tickAmount = wave.WaveTime;
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
                    God.EventS.waveEnded();
                    curTick = 0;
                    God.WaveS.UpWaves();
                }
                timer = 0;
            }
        }
        
        public void OnGameStarted()
        {
            active = true;
        }

        public void OnGameEnded()
        {
            active = false;
        }
    }
}