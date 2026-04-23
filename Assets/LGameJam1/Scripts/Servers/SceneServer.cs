using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class SceneServer : MonoBehaviour
    {
        private void Awake()
        {
            God.SceneS = this;
            DontDestroyOnLoad(this);
            Debug.Log("Scene Server Awake");
        }

        public void ShowWin()
        {
            God.Hud.WinScreen.gameObject.SetActive(true);
        }

        public void ShowEnd()
        {
            God.Hud.EndScreen.gameObject.SetActive(true);
        }
        
        public void ShowBattle()
        {
            God.Hud.BattleScreen.gameObject.SetActive(true);
        }

        public void HideScreens()
        {
            God.Hud.BattleScreen.gameObject.SetActive(false);
            God.Hud.WinScreen.gameObject.SetActive(false);
            God.Hud.EndScreen.gameObject.SetActive(false);
        }
    }
}
