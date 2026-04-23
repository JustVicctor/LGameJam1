using LGameJam1.Scripts.Servers;
using LGameJam1.Scripts.UI.Hud;

namespace LGameJam1.Scripts
{
    public static class God
    {
        public static EventServer EventS;
        public static SceneServer SceneS;
        public static InputServer InputS;
        public static DraggableServer DraggableS;
        public static DBServer DBS;
        public static TimerServer TimerS;
        public static StorageServer StorageS;
        public static WaveServer WaveS { get; set; }
        
        public static PlayerController Player;
        public static HudUI Hud;
        public static WorkersServer WorkerS { get; set; }

        public static AudioServer AudioS;
    }
}
