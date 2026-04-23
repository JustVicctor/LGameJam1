using LGameJam1.Scripts.Station;
using TMPro;
using UnityEngine;

namespace LGameJam1.Scripts.UI.Storage
{
    public class ResourceUI : MonoBehaviour
    {
        public TMP_Text Text;
        public ResourceType ResourceType;

        private void FixedUpdate()
        {
            Text.text = God.StorageS.GetResourceCount(ResourceType).ToString();
        }
    }
}