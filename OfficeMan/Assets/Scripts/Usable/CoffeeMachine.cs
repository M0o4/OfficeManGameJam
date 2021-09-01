using State;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = Character.PlayerInput;

namespace Usable
{
    public class CoffeeMachine : MonoBehaviour,IUsable
    {
        public bool Used { get; set; }
        [SerializeField] private GameObject _useButton;
        [SerializeField] private Speak _speak;
        private StationBehavior _stationBehavior;
        private bool _isPlayerEnter;
        private bool _firstTime = true;

        private void Start()
        {
            _stationBehavior = FindObjectOfType<StationBehavior>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerInput>() != null)
            {
                _useButton.SetActive(true);
                _isPlayerEnter = true;
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<PlayerInput>() != null)
            {
                _useButton.SetActive(false);
                _isPlayerEnter = false;
                _stationBehavior.SwitchState<IdleState>();
                Used = false;
            }
        }

        public void Use(InputAction.CallbackContext ctx)
        {
            if (_isPlayerEnter)
            {
                _useButton.SetActive(false);
                if(!_firstTime)
                    _stationBehavior.SwitchState<DrinkCoffeeState>();
                else
                {
                    _firstTime = false;
                    _speak.StartSpeak();
                }
                Used = true;
            }
        }

        public void StopUse(InputAction.CallbackContext ctx)
        {
            _stationBehavior.SwitchState<IdleState>();
            Used = false;
        }
    }
}
