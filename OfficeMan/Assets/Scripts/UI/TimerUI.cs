using System.Globalization;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timer;

        public void DisplayTime(float timeToDisplay)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            _timer.text = $"{minutes:00}:{seconds:00}";
        }
    }
}
