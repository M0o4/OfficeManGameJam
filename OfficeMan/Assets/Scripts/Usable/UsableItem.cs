using System;
using Character;
using UnityEngine;

namespace Usable
{
    [RequireComponent(typeof(IUsable))]
    public class UsableItem : MonoBehaviour
    {
        private IUsable _usable;
        private PlayerInput _playerInput;

        private void Start()
        {
            _usable = GetComponent<IUsable>();
            _playerInput = FindObjectOfType<PlayerInput>();

            _playerInput.PlayerControls.Player.Interaction.performed += _usable.Use;
            _playerInput.PlayerControls.Player.Back.performed += _usable.StopUse;
        }
        
    }
}
