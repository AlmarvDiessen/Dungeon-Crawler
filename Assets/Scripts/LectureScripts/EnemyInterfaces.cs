using System.IO;
using LectureScripts.Health;
using LectureScripts.Input;
using LectureScripts.Movement;
using LectureScripts.UI;
using UnityEngine;

namespace LectureScripts
{
    public class EnemyInterfaces : MonoBehaviour
    {
        private EnemyInput _input;
        private IMovement _movement;

        private IHealth _health;
        private HealthBarUI _healthBarUI;

        private void Awake()
        {
            _input = GetComponent<EnemyInput>();
            _movement = GetComponent<IMovement>();
            
            _health = GetComponent<IHealth>();
            _healthBarUI = GetComponentInChildren<HealthBarUI>();

            Sprite sprite = Resources.Load<Sprite>(_health.IconName);
            Debug.Assert(sprite != null);
            _healthBarUI.Icon = sprite;

            _health.OnHealthChange += _healthBarUI.UpdateHealthBar;
        }

        private void Update()
        {
            HandleMovement();
            //UpdateHealthUI();
        }

        private void HandleMovement()
        {
            Vector3 direction = _input.GetTargetDirection();
            
            _movement.Move(direction);
        }
        
        private void UpdateHealthUI()
        {
            float t = (float)_health.Health / _health.MaxHealth;
            Debug.Log(t);

            _healthBarUI.UpdateHealthBar(t);
        }
    }
}
