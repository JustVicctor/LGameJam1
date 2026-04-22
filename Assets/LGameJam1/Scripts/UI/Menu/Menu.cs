using LGameJam1.Scripts.Helpers;
using UnityEngine;

namespace LGameJam1.Scripts.UI.Menu
{
    public class Menu : MonoBehaviour
    {
        public void OnTutorButton()
        {
            // TODO: Open Tutor
        }
        
        public void OnStartButton()
        {
            SceneHelpers.MoveToGame();
        }
        
        public void OnContinueButton()
        {
            // TODO: Continue
        }
        
        public void OnExitButton()
        {
            // TODO: Exit
        }
    }
}
