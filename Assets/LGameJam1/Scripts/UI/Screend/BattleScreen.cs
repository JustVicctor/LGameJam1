using UnityEngine;

namespace LGameJam1.Scripts.UI.Screend
{
    public class BattleScreen : MonoBehaviour
    {
        public void OnClick()
        {
            God.SceneS.HideScreens();
            if (God.Player.WinState)
            {
                God.SceneS.ShowWin();
            }
            else
            {
                God.SceneS.ShowEnd();
            }
        }
    }
}