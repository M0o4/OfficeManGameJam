using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StatsSliderUI : MonoBehaviour
    {
        public float MaxValue => _slider.maxValue;
        [SerializeField] private Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();
        }

        public void Init(float value)
        {
            _slider.maxValue = value;
        }
        
        public void SetSliderValue(float value)
        {
            _slider.value = value;
        }
    }
}
