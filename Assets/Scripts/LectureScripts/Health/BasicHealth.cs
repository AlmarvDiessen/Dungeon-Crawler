using System;
using UnityEngine;

namespace LectureScripts.Health
{
    public class BasicHealth : MonoBehaviour, IHealth
    {
        public event Action<float> OnHealthChange = delegate {  };

        //Fields
        [SerializeField] private int _maxHealth = 100;
        private int _health = 0;

        //Properties
        public int Health => _health;
        public int MaxHealth => _maxHealth;
        public string IconName => "HeartIcon";

        //Unity Event Functions
        private void Start()
        {
            _health = _maxHealth;
        }
        
        public void TakeDamage(int pDamageValue)
        {
            Debug.Assert(pDamageValue > 0);
            _health -= pDamageValue;
            OnHealthChange((float)_health / _maxHealth);
        }

        public void Heal(int pHealValue)
        {
            Debug.Assert(pHealValue > 0);
            _health += pHealValue;
            OnHealthChange((float)_health / _maxHealth);
        }
    }
}
