using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerComponent: MonoBehaviour {
    [SerializeField] private float abilityTimer = 1;
    [SerializeField] private bool abilityUsed = false;

    public float AbilityTimer { get => abilityTimer; set => abilityTimer = value; }
    public bool AbilityUsed { get => abilityUsed; set => abilityUsed = value; }

    public void Update() {
        if (AbilityUsed) {
            AbilityTimer -= Time.deltaTime;
            if (AbilityTimer <= 0) {
                OnAbilityReset();
            }
        }
    }

    protected virtual void OnAbilityReset() {
    }
}
