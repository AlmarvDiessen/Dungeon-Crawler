using System;
using UnityEngine;

namespace LectureScripts.Input.PlayerInput
{
    public interface IPlayerInput
    {
        //Events
        event Action OnAttackInput;
        
        //Functions
        Vector2 GetMovementInput();

        void CheckAttackInput();
    }
}