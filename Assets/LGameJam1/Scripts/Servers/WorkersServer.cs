using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class WorkersServer : MonoBehaviour
    {
        int workerCount = 0;
        
        private void Awake()
        {
            God.WorkerS = this;
            DontDestroyOnLoad(this);
            Debug.Log("Worker Server Awake");
        }

        private void OnEnable()
        {
            God.EventS.waveStarted += OnWaveStarted;
        }

        private void OnDisable()
        {
            God.EventS.waveStarted -= OnWaveStarted;
        }

        private void OnWaveStarted()
        {
            var wave = God.WaveS.GetWave();
            workerCount = wave.WorkerCount;
            God.Hud.ShowWorkers(workerCount);
        }
    }
}