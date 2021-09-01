using System;
using System.Collections;
using UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startTime;
    [SerializeField] private float _endTime;
    [SerializeField] private float _changeTimeValue;
    private float _time;
    private TimerUI _timerUI;
    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private void Start()
    {
        _timerUI = FindObjectOfType<TimerUI>();
        _time = _startTime;
        _timerUI.DisplayTime(_time);
    }

    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return _waitForSeconds;
            _time += _changeTimeValue;
            _timerUI.DisplayTime(_time);
            if(_time >= _endTime)
            {
                GameOver.GameOverScreen("The working day is over");
            }
        }
    }
}
