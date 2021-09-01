using System.Collections;
using Character;
using UnityEngine;

namespace State
{
    public class WorkState : BaseState
    {
        private readonly RandomButtonGame _randomButton;
        
        public WorkState(PlayerStats.PlayerStats playerStats, IStationSwitcher stateSwitcher, RandomButtonGame randomButton) : base(playerStats, stateSwitcher)
        {
            _randomButton = randomButton;
        }

        public override void Start()
        {
            Work();
        }

        public override void Stop()
        {
            PlayerInput.IsCanMove = true;
            _playerStats.StopAllCoroutines();
            _randomButton.StopGame();
        }

        public override void Work()
        {
            PlayerInput.IsCanMove = false;
            _playerStats.StartWork();
            _randomButton.StartGame();
        }
    }
}
