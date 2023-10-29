using System;

namespace LectureScripts.Health
{
    public interface IHealth
    {
        event Action<float> OnHealthChange;
        
        int Health { get; }
        int MaxHealth { get; }
        string IconName { get; }
        
        void TakeDamage(int pDamageValue);
        void Heal(int pHealValue);
    }
}
