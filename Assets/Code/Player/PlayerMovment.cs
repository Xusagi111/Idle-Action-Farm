using UnityEngine;

namespace Assets.Code
{
    public class PlayerMovment : MonoBehaviour
    {
        [Range(1f, 100f)]
        [SerializeField] private int _speedPlayer = 10;


        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Joystick _joystick;

        private Animator _playerAnimator;
        private const float LerpTRotatePlayer = 0.1f;
        
        private void Start()
        {
            _playerAnimator = GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            float Horizontal = _joystick.Horizontal;
            float Vertical = _joystick.Vertical;
            _rigidbody.velocity = new Vector3(Horizontal * _speedPlayer, 0, _joystick.Vertical * _speedPlayer);
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                if (_rigidbody.velocity != Vector3.zero)
                {
                    Quaternion LookRotatePlayer = Quaternion.LookRotation(_rigidbody.velocity);
                    transform.rotation = Quaternion.Lerp(transform.rotation, LookRotatePlayer, LerpTRotatePlayer);
                }
                _playerAnimator.SetBool("isMove", true);
            }
            else
            {
                _playerAnimator.SetBool("isMove", false);
            }
        }
    }
}