using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private bool _isFacingRightAtStart;
        private SpriteRenderer _renderer;
        private Rigidbody2D _rb2d;
        private bool _isFacingRight;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _rb2d = GetComponent<Rigidbody2D>();
            _isFacingRight = _isFacingRightAtStart;
        }

        public void Move(Vector2 movement)
        {
            _rb2d.MovePosition(_rb2d.position + movement * (_moveSpeed * Time.fixedDeltaTime));
            
            if(movement.x > 0 && !_isFacingRight)
                Flip();
            else if(movement.x < 0 && _isFacingRight)
                Flip();
        }

        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            _renderer.flipX = !_isFacingRight;
        }
    }
}
