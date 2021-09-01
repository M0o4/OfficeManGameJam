using System;
using Character;
using State;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private AudioSource _bgMusic;
        [SerializeField] private TextMeshProUGUI _loseText;
        private StationBehavior _stationBehavior;

        private void Start()
        {
            _stationBehavior = FindObjectOfType<StationBehavior>();
            GameOver.onGameOver += DisplayGameOverScreen;
        }

        private void DisplayGameOverScreen(string message)
        {
            _gameOverPanel.SetActive(true);
            PlayerInput.IsCanMove = false;
            _loseText.text = message;
            _bgMusic.pitch = 0.5f;
            _stationBehavior.SwitchState<StopTimerState>();
        }

        private void OnDestroy()
        {
            GameOver.onGameOver -= DisplayGameOverScreen;
        }
    }
}
