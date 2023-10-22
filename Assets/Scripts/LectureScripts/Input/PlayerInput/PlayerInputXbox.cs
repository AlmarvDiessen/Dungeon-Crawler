using System;
using UnityEngine;

namespace LectureScripts.Input.PlayerInput
{
    public class PlayerInputXbox : MonoBehaviour, IPlayerInput
    {
        public event Action OnAttackInput = delegate {  };

        public Vector2 GetMovementInput()
        {
            Vector2 currentInput = Vector2.zero;
        
            currentInput.x = UnityEngine.Input.GetAxis("Horizontal");
            currentInput.y = UnityEngine.Input.GetAxis("Vertical");

            return currentInput == Vector2.zero ? currentInput : currentInput.normalized;
        }

        public void CheckAttackInput()
        {
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                OnAttackInput();
            }
        }
    }
}