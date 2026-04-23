using UnityEngine;

namespace LGameJam1.Scripts.UI.Screend
{
    public class WinScreen : MonoBehaviour
    {
        public void OnClick()
        {
            God.WaveS.UpWaves();
            God.EventS.waveStarted();
        }
    }
}