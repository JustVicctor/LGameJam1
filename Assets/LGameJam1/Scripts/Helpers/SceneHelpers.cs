using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace LGameJam1.Scripts.Helpers
{
    public static class SceneHelpers
    {
        public static void MoveToGame()
        {
            SceneManager.LoadScene("Game");
        }

        public static void MoveToMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public static GameObject RayCastToWorld()
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            
            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Clicked on: " + clickedObject.name);
                return clickedObject;
            }
            return null;
        }
    }
}
