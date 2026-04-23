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
            God.EventS.DayEnd += CheckStorage;
        }

        private void OnDisable()
        {
            God.EventS.DayEnd -= CheckStorage;
        }

        private void CheckStorage()
        {
        }

        private void Start()
        {
            God.EventS.GameStarted();
            God.EventS.timerChanged();
            God.EventS.atkItemChanged();
            God.EventS.defItemChanged();
            God.EventS.waveChanged();
        }
    }
}
