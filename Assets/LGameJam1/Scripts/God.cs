using LGameJam1.Scripts.Servers;
using UnityEngine;

namespace LGameJam1.Scripts
{
    public static class God
    {
        public static EventServer EventS;
        public static SceneServer SceneS;
        public static InputServer InputS;
        public static DraggableServer DraggableS;
        
        public static PlayerController Player;

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            var server = new GameObject("Servers");
            EventS = server.AddComponent<EventServer>();
            SceneS = server.AddComponent<SceneServer>();
            InputS = server.AddComponent<InputServer>();
            DraggableS = server.AddComponent<DraggableServer>();
        }
    }
}
