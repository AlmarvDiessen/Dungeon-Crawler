using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceComponent : TimerComponent {
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TimerComponent timer;
    [SerializeField] private bool canUse = true;
    [SerializeField] private bool isUsing = false;
    [SerializeField] private float forcePower;
    [SerializeField] private float forceUpPower;
    [SerializeField] private float cooldown;

    public Rigidbody Rb { get => rb; set => rb = value; }
    public bool CanUse { get => canUse; set => canUse = value; }
    public float ForcePower { get => forcePower; set => forcePower = value; }
    public float Cooldown { get => cooldown; set => cooldown = value; }
    public TimerComponent Timer { get => timer; set => timer = value; }
    public bool IsUsing { get => isUsing; set => isUsing = value; }
    public float ForceUpPower { get => forceUpPower; set => forceUpPower = value; }

    public void Start() {
        Rb = GetComponent<Rigidbody>();
        timer = GetComponent<TimerComponent>();
    }

    public virtual void AddForce(Vector3 direction, float upwardForce) {
        if (canUse && timer.AbilityUsed == false) {
            canUse = false;
            IsUsing = true;
            timer.AbilityUsed = true;
            Vector3 dashDirection = direction * forcePower + transform.up * ForceUpPower;
            Rb.AddForce(dashDirection, ForceMode.Impulse);
        }
    }

    protected override void OnAbilityReset() {
        AbilityTimer = cooldown;
        canUse = true;
        IsUsing = false;//
        AbilityUsed = false;
    }
}
