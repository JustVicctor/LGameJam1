using System;
using UnityEngine;

namespace LGameJam1.Scripts
{
    [DefaultExecutionOrder(10)]
    public class PlayerController : MonoBehaviour
    {
        private void Awake()
        {
            God.Player = this;
            Debug.Log("Player Controller Awake");
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
        
        private void Start()
        {
            God.EventS.GameStarted();
            God.EventS.timerChanged();
            God.EventS.atkItemChanged();
            God.EventS.defItemChanged();
            God.EventS.waveStarted();
        }
        
        private void OnWaveEnded()
        {
            God.TimerS.enabled = false;
            
            God.StorageS.GetOverall(out uint atk, out var def);
            var wave = God.WaveS.GetWave();

            var atkTTK = wave.WaveDef / Math.Max(atk, 1);
            var usrTTK = def / Math.Max(wave.WaveAtk, 1);

            if (usrTTK > atkTTK)
                God.SceneS.ShowWin();
            else
                God.SceneS.ShowEnd();
        }

        private void OnWaveStarted()
        {
        }
    }
}
