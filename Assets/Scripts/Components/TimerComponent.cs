using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerComponent {
    [SerializeField] private float abilityTimer = 1;
    [SerializeField] private bool abilityUsed = false;
    private float cooldown;
    private bool canUse = true;

    public float AbilityTimer { get => abilityTimer; set => abilityTimer = value; }
    public bool AbilityUsed { get => abilityUsed; set => abilityUsed = value; }
    public float Cooldown1 { get => cooldown; set => cooldown = value; }
    public bool CanUse { get => canUse; set => canUse = value; }

    public void checkCooldown(float abilityTime) {
        if (AbilityUsed) {
            AbilityTimer -= Time.deltaTime;
            if (AbilityTimer <= 0) {
                OnAbilityReset(abilityTime);
            }
        }
    }

    protected virtual void OnAbilityReset(float cooldown) {
        AbilityTimer = cooldown;
        CanUse = true;
        AbilityUsed = false;
    }
}
