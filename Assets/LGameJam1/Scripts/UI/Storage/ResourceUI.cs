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
            God.StorageS.GetResourceCountAndValue(ResourceType, out uint count, out var power);
            Text.text = count.ToString();
        }
    }
}