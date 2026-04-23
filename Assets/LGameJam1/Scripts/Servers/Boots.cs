using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class Boots : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}