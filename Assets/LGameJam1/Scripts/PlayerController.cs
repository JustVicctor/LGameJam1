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
            God.EventS.waveStarted();
        }
        
        private void OnWaveEnded()
        {
            God.StorageS.GetOverall(out uint atk, out var def);
            var wave = God.WaveS.GetWave();

            var atkTTK = (float)wave.WaveDef / (float)Math.Max(atk, 1);
            var usrTTK = (float)def / (float)Math.Max(wave.WaveAtk, 1);

            if (usrTTK > atkTTK)
            {
                God.SceneS.ShowWin();
                God.EventS.waveStarted();
            }
            else
            {
                God.SceneS.ShowEnd();
                God.EventS.waveStarted();
            }
        }

        private void OnWaveStarted()
        {
            God.EventS.atkItemChanged();
            God.EventS.defItemChanged();
            God.EventS.timerChanged();
        }
    }
}
