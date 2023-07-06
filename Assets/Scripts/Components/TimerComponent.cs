using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// SCRIPT BY ALMAR

public class TimerComponent : MonoBehaviour {
    [SerializeField] private float abilityTimer = 1;
    [SerializeField] private bool abilityUsed = false;
    [SerializeField] private bool canUse = true;
    [SerializeField] private float cooldown;
    public float Cooldown { get => cooldown; set => cooldown = value; }


    public float AbilityTimer { get => abilityTimer; set => abilityTimer = value; }
    public bool AbilityUsed { get => abilityUsed; set => abilityUsed = value; }
    public bool CanUse { get => canUse; set => canUse = value; }

    public void Update() {
        if (AbilityUsed) {
            AbilityTimer -= Time.deltaTime;
            if (AbilityTimer <= 0) {
                OnAbilityReset();
            }
        }
    }

    protected virtual void OnAbilityReset() {
        AbilityTimer = Cooldown;
        CanUse = true;
        AbilityUsed = false;
    }
}
