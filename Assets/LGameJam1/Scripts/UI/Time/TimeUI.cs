using TMPro;
using UnityEngine;

namespace LGameJam1.Scripts.UI.Time
{
    public class TimeUI : MonoBehaviour
    {
        [SerializeField]
        public TMP_Text timeText;

        private void OnEnable()
        {
            God.EventS.TickTime += OnTickTime;
        }

        private void OnDisable()
        {
            God.EventS.TickTime -= OnTickTime;
        }

        private void OnTickTime()
        {
            timeText.text = (God.TimerS.tickAmount - God.TimerS.curTick).ToString();
        }
    }
}
