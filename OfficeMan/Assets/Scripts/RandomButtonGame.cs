using System;
using System.Collections;
using Character;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class RandomButtonGame : MonoBehaviour
{
    [Header("UI")] [SerializeField] private StatsSliderUI _sliderUI;
    [SerializeField] private TextMeshProUGUI _letterText;

    [Header("Values")] [SerializeField] private float _timeSilderValue;
    [SerializeField] private float _stressChange;
    private float _timeSlider;
    private string _randomLetter;
    private bool _isGameStarted;
    
    private PlayerStats.PlayerStats _playerStats;



    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats.PlayerStats>();
        _timeSlider = _timeSilderValue;
    }

    private void Update()
    {
       if(_isGameStarted)
           Play();
    }

    public void StartGame()
    {
        _sliderUI.gameObject.SetActive(true);
        GetRandomButton();
        _sliderUI.Init(_timeSilderValue);
        _timeSlider = _timeSilderValue;
        _sliderUI.SetSliderValue(_timeSlider);
        _isGameStarted = true;
    }

    public void StopGame()
    {
        _isGameStarted = false;
        _sliderUI.gameObject.SetActive(false);
    }

    private void Play()
    {
        if (((KeyControl)Keyboard.current[_randomLetter]).wasPressedThisFrame)
        {
            Debug.Log("Correct");
            _timeSlider = _timeSilderValue;
            _sliderUI.SetSliderValue(_timeSlider);
            GetRandomButton();
        }

        _timeSlider -= Time.deltaTime;
        _sliderUI.SetSliderValue(_timeSlider);
        if (_timeSlider <= 0)
        {
            Debug.Log("Lost");
            _playerStats.Stress.SetValue(_stressChange);
            _timeSlider = _timeSilderValue;
            _sliderUI.SetSliderValue(_timeSlider);
            GetRandomButton();
        }
    }
    

    private void GetRandomButton()
    {
        _randomLetter = Utils.GetRandomCharA2Z().ToString().ToUpper();
        _letterText.text = _randomLetter;
        Debug.Log($"Random Letter: {_randomLetter}");
    }
}