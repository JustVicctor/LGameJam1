using LGameJam1.Scripts.Wave;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class WaveServer : MonoBehaviour
    {
        [SerializeField]
        public WaveDB waveDB;
        
        public int curWave = 0;
        
        private void Awake()
        {
            God.WaveS = this;
            DontDestroyOnLoad(this);
            Debug.Log("DB Server Awake");
        }

        public void ResetWaves()
        {
            curWave = 0;
        }

        public void UpWaves()
        {
            curWave++;
        }

        public Wave.Wave GetWave()
        {
            return waveDB.waves[curWave];
        }
    }
}