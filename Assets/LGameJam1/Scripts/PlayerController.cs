using System;
using UnityEngine;

namespace LGameJam1.Scripts
{
    [DefaultExecutionOrder(10)]
    public class PlayerController : MonoBehaviour
    {
        public bool WinState = false;
        
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

            WinState = usrTTK > atkTTK;
            
            God.Hud.battleEnAtk.text = "АТК. " + wave.WaveAtk.ToString();
            God.Hud.battleEnDef.text = "DEF. " + wave.WaveDef.ToString();
            God.Hud.battleUsrAtk.text = "АТК. " + atk.ToString();
            God.Hud.battleUsrDef.text = "DEF. " + def.ToString();
            God.SceneS.ShowBattle();
        }

        private void OnWaveStarted()
        {
            God.StorageS.ClearStorage();
            WinState = false;
            God.SceneS.HideScreens();
            God.EventS.atkItemChanged();
            God.EventS.defItemChanged();
            God.EventS.timerChanged();
        }
    }
}
