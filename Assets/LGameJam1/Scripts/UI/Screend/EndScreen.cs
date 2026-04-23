using LGameJam1.Scripts.Helpers;
using UnityEngine;

namespace LGameJam1.Scripts.UI.Screend
{
    public class EndScreen : MonoBehaviour
    {
        public void OnClick()
        {
            SceneHelpers.MoveToMenu();
        }
    }
}