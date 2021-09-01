using Character;
using UnityEngine;

namespace State
{
    public class IdleState : BaseState
    {
        public IdleState(PlayerStats.PlayerStats playerStats, IStationSwitcher stateSwitcher) : base(playerStats, stateSwitcher)
        {
        }

        public override void Start()
        {
            _playerStats.StartIdle();
        }

        public override void Stop()
        {
            _playerStats.StopAllCoroutines();
                
        }
    }
}
