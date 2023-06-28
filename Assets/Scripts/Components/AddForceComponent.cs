using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AddForceComponent : TimerComponent {
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TimerComponent timer;
    [SerializeField] private bool isUsing = false;
    [SerializeField] private float forcePower;
    [SerializeField] private float forceUpPower;
    [SerializeField] private Vector3 direction;

    public Rigidbody Rb { get => rb; set => rb = value; }
    public float ForcePower { get => forcePower; set => forcePower = value; }
    public TimerComponent Timer { get => timer; set => timer = value; }
    public bool IsUsing { get => isUsing; set => isUsing = value; }
    public float ForceUpPower { get => forceUpPower; set => forceUpPower = value; }
    public Vector3 Direction { get => direction; set => direction = value; }

    public void Start() {
        Rb = GetComponent<Rigidbody>();
    }

    public virtual void AddForce(Vector3 direction, float upwardForce) {
        if (timer.CanUse && timer.AbilityUsed == false) {
            Direction = direction;
            timer.CanUse = false;
            IsUsing = true;
            timer.AbilityUsed = true;
            Vector3 dashDirection = Direction * forcePower + transform.up * ForceUpPower;
            Rb.AddForce(dashDirection, ForceMode.Impulse);
        }
    }
    public virtual void AddForce(Vector3 direction, float upwardForce, NavMeshAgent agent) {
        if (timer.CanUse && timer.AbilityUsed == false) {
            agent.updatePosition = false;
            agent.updateRotation = false;
            agent.isStopped = true;
            timer.CanUse = false;
            IsUsing = true;
            timer.AbilityUsed = true;
            Vector3 dashDirection = direction * forcePower + transform.up * ForceUpPower;
            Rb.AddForce(dashDirection, ForceMode.Impulse);
        }
    }

    protected override void OnAbilityReset() {
        base.OnAbilityReset();
        IsUsing = false;//

    }
}
