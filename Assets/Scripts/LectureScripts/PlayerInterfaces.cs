using LectureScripts.Attack;
using LectureScripts.Health;
using LectureScripts.Input.Conversions;
using LectureScripts.Input.PlayerInput;
using UnityEngine;

using LectureScripts.Movement;
using LectureScripts.UI;

namespace LectureScripts
{
    public class PlayerInterfaces : MonoBehaviour
    {
        //Fields
        private IPlayerInput _input;
        private IInputConversion _inputConversion;
        private IMovement _movement;

        private IHealth _health;
        private HealthBarUI _healthBarUI;

        private IAttack _attack;

        //Unity event Functions
        private void Awake()
        {
            //Search for all references
            _input = GetComponent<IPlayerInput>();
            _inputConversion = GetComponent<IInputConversion>();
            _movement = GetComponent<IMovement>();
            _health = GetComponent<IHealth>();
            _attack = GetComponent<IAttack>();
            
            _healthBarUI = GetComponentInChildren<HealthBarUI>();

            //Update type specific health icon
            Sprite sprite = Resources.Load<Sprite>(_health.IconName);
            Debug.Assert(sprite != null);
            _healthBarUI.Icon = sprite;

            _health.OnHealthChange += _healthBarUI.UpdateHealthBar;
            _input.OnAttackInput += _attack.Attack;
        }

        private void Update()
        {
            HandleMovement();
            _input.CheckAttackInput();

            //UpdateHealthUI();
        }

        private void HandleMovement()
        {
            Vector2 movementInput = _input.GetMovementInput();
            Vector3 movementDirection = _inputConversion.Convert(movementInput);

            _movement.Move(movementDirection);
        }
    }
}