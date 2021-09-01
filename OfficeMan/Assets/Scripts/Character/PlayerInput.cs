using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    [RequireComponent(typeof(Movement))]
    public class PlayerInput : MonoBehaviour
    {
        public PlayerControls PlayerControls => _playerControls;
        public static bool IsCanMove { get; set; }
        
        private PlayerControls _playerControls;
        private Movement _movement;
        private Vector2 _input;

        #region MonoBehavior Methods
        private void Awake()
        {
            _playerControls = new PlayerControls();
        }

        private void Start()
        {
            IsCanMove = false;
            _movement = GetComponent<Movement>();
        }
        

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void Update()
        {
            if(IsCanMove)
                ProcessInput();
        }

        private void FixedUpdate()
        {
            Move();
        }
        
        private void OnDisable()
        {
            _playerControls.Disable();
        }
        #endregion
        
        private void ProcessInput()
        {
            _input = _playerControls.Player.Move.ReadValue<Vector2>();
        }

        private void Move()
        {
            _movement.Move(_input);
        }
    }
}
