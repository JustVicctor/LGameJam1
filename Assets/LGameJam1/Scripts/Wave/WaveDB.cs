using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace LGameJam1.Scripts.Wave
{
    [Serializable]
    public class Wave
    {
        public uint WaveAtk = 0;
        public uint WaveDef = 0;
        public int WaveTime = 0;
        [FormerlySerializedAs("HeroCount")] public int WorkerCount = 0;
    }
    
    [CreateAssetMenu(fileName = "WaveDB", menuName = "ScriptableObjects/WaveDB", order = 1)]
    public class WaveDB : ScriptableObject
    {
        public List<Wave> waves;
    }
}