using UnityEngine;
using UnityEngine.UI;

namespace LGameJam1.Scripts.UI.Slider
{
    public class SliderUI : MonoBehaviour
    {
        public Image slider;

        public void HideSlider()
        {
            gameObject.SetActive(false);
        }
        
        public void ShowSlider()
        {
            gameObject.SetActive(true);
        }
        
        public void ResetSlider()
        {
            slider.fillAmount = 0;
        }

        public void SetSlider(float value)
        {
            slider.fillAmount = value;
        }
        
    }
}