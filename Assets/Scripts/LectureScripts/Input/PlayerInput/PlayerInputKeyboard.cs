using System;
using UnityEngine;

namespace LectureScripts.Input.PlayerInput
{
    public class PlayerInputKeyboard : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private KeyCode _forwardKey = KeyCode.W;
        [SerializeField] private KeyCode _leftKey = KeyCode.A;
        [SerializeField] private KeyCode _backwardKey = KeyCode.S;
        [SerializeField] private KeyCode _rightKey = KeyCode.D;

        public event Action OnAttackInput = delegate { };
        [SerializeField] private KeyCode _attackKey = KeyCode.Space;
        
        public Vector2 GetMovementInput()
        {
            Vector2 currentInput = Vector2.zero;

            if (UnityEngine.Input.GetKey(_leftKey))
                currentInput.x--;

            if (UnityEngine.Input.GetKey(_rightKey))
                currentInput.x++;

            if (UnityEngine.Input.GetKey(_forwardKey))
                currentInput.y++;

            if (UnityEngine.Input.GetKey(_backwardKey))
                currentInput.y--;

            return currentInput == Vector2.zero ? currentInput : currentInput.normalized;
        }

        public void CheckAttackInput()
        {
            if (UnityEngine.Input.GetKeyDown(_attackKey))
            {
                OnAttackInput();
            }
        }
    }
}