using UI;
using UnityEngine;

namespace PlayerStats
{
    public class StressStat : PlayerStat
    {
        [SerializeField] private StatsSliderUI _stresslider;
        [SerializeField] private Speak _stressedSpeak;
        [SerializeField] private float _valueToSpeak = 7f;
        private bool _isStressedSpoke;
        
        public override void SetValue(float value)
        {
            if(value != 0)
            {
                if (_value + value <= 0)
                {
                    _value = 0;
                    _stresslider.SetSliderValue(_value);
                }
                
                _value += value;
                _stresslider.SetSliderValue(_value);
                if(_value >= _stresslider.MaxValue)
                    GameOver.GameOverScreen("You burned out and can't work anymore.");
                if (_value >= _valueToSpeak && !_isStressedSpoke)
                {
                    _isStressedSpoke = true;
                    _stressedSpeak.StartSpeak();
                }
            }
        }
        
    }
}
