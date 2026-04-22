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
    }
}
