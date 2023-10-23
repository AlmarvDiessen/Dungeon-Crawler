using System;
using UnityEngine;

namespace LectureScripts.Health
{
    public class ArmorHealth : MonoBehaviour, IHealth
    {
        //Events
        public event Action<float> OnHealthChange = delegate {  };
        
        //Fields
        [SerializeField] private int _armor;
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private Sprite _UIIcon;
        
        private int _health = 0;

        //Properties
        public int Health => _health;
        public int MaxHealth => _maxHealth;
        public Sprite UIIcon => _UIIcon;
        public string IconName => "ShieldIcon";

        //Unity Event Functions
        private void Start()
        {
            Debug.Assert(_armor > 0);
            Debug.Assert(_maxHealth > 0);
            
            _health = _maxHealth;
        }
        
        public void TakeDamage(int pDamageValue)
        {
            Debug.Assert(pDamageValue > 0);

            int reducedDamage = pDamageValue - _armor;

            if (reducedDamage > 0)
            {
                _health -= reducedDamage;
                OnHealthChange((float)_health / _maxHealth);
            }
        }

        public void Heal(int pHealValue)
        {
            Debug.Assert(pHealValue > 0);
            _health += pHealValue;
            OnHealthChange(pHealValue);
        }
    }
}
