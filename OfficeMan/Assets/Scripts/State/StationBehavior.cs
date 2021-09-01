using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;

namespace State
{
    public class StationBehavior : MonoBehaviour, IStationSwitcher
    {
        private PlayerStats.PlayerStats _playerStats;
        private BaseState _currentState;
        private Timer _timer;
        private List<BaseState> _allStates;

        private void Start()
        {
            _playerStats = FindObjectOfType<PlayerStats.PlayerStats>();
            _timer = FindObjectOfType<Timer>();

            _allStates = new List<BaseState>()
            {
                new WorkState(_playerStats, this, FindObjectOfType<RandomButtonGame>()),
                new RestState(_playerStats, this),
                new DrinkCoffeeState(_playerStats, this),
                new IdleState(_playerStats,this),
                new StopTimerState(_playerStats, this, _timer)
            };
            
            SwitchState<StopTimerState>();
        }

        public void Work()
        {
            _currentState.Work();
        }

        public void Rest()
        {
            _currentState.Rest();
        }

        public void Charging()
        {
            _currentState.Charging();
        }
        
        
        public void SwitchState<T>() where T : BaseState
        {
            var state = _allStates.FirstOrDefault(s => s is T);
            if (state == null) Debug.LogError("No state ");
            _currentState?.Stop();
            state.Start();
            _currentState = state;
        }
    }
}
