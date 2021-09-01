using UI;
using UnityEngine;

namespace PlayerStats
{
    public class WorkStat : PlayerStat
    {
        [SerializeField] private StatsSliderUI _workSlider;
        
        public override void SetValue(float value)
        {
            if (value != 0)
            {
                _value += value;
                _workSlider.SetSliderValue(_value);
            }
            
            if(_value >= _workSlider.MaxValue)
                VictoryScreen.Victory();
        }
    }
}
