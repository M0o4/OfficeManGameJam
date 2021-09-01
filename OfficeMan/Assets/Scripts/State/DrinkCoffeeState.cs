using Character;
using UnityEngine;

namespace State
{
    public class DrinkCoffeeState : BaseState
    {
        public DrinkCoffeeState(PlayerStats.PlayerStats playerStats, IStationSwitcher stateSwitcher) : base(playerStats, stateSwitcher)
        {
        }

        public override void Start()
        {
            _playerStats.StartRecharging();
        }

        public override void Stop()
        {
            _playerStats.StopAllCoroutines();
        }
        
    }
}
