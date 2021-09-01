using System;
using Character;
using State;
using UnityEngine;

namespace UI
{
    public class VictoryScreenUI : MonoBehaviour
    {
        [SerializeField] private GameObject _victoryPanel;
        private StationBehavior _stationBehavior;
        
        private void Start()
        {
            _stationBehavior = FindObjectOfType<StationBehavior>();
            VictoryScreen.OnVictory += DisplayVictoryScreen;
        }

        private void DisplayVictoryScreen()
        {
            _victoryPanel.SetActive(true);
            PlayerInput.IsCanMove = false;
            _stationBehavior.SwitchState<StopTimerState>();
        }

        private void OnDestroy()
        {
            VictoryScreen.OnVictory -= DisplayVictoryScreen;
        }
    }
}
