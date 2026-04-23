using LGameJam1.Scripts.Wave;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class WaveServer : MonoBehaviour
    {
        [SerializeField]
        public WaveDB waveDB;
        
        private void Awake()
        {
            God.WaveS = this;
            DontDestroyOnLoad(this);
            Debug.Log("DB Server Awake");
        }
    }
}