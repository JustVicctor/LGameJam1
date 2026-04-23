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

        private void Start()
        {
            God.EventS.GameStarted();
        }
    }
}
