using System;
using UI;
using UnityEngine;

namespace PlayerStats
{
    public class EnergyStat : PlayerStat
    {
        [SerializeField] private StatsSliderUI _energySlider;
        [SerializeField] private Speak _noEnergySpeak;
        [SerializeField] private float _valueToSpeak = 2f;
        private bool _isNoEnergySpoke;

        private void Start()
        {
            _value = _energySlider.MaxValue;
        }

        public override void SetValue(float value)
        {
            if (value != 0)
            {
                if (_value + value > _energySlider.MaxValue)
                {
                    _value = _energySlider.MaxValue;
                    _energySlider.SetSliderValue(_energySlider.MaxValue);
                }
                
                _value += value;
                _energySlider.SetSliderValue(_value);
                
                if(_value <= 0)
                    GameOver.GameOverScreen("You fell asleep at your workplace.");
                
                if(_value <= _valueToSpeak && !_isNoEnergySpoke)
                {
                    _isNoEnergySpoke = true;
                    _noEnergySpeak.StartSpeak();
                }
            }
        }

        private bool IsValueFull() => _value >= _energySlider.MaxValue;
    }
}
