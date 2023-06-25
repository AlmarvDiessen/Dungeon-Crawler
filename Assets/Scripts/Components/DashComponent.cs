using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashComponent : TimerComponent {
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashPower;
    [SerializeField] private float cooldown;
    private Vector3 direction;

    [SerializeField] private Rigidbody rb;

    public bool CanDash { get => canDash; set => canDash = value; }
    public bool IsDashing { get => isDashing; set => isDashing = value; }
    public Vector3 Direction { get => direction; set => direction = value; }
    public Rigidbody Rb { get => rb; set => rb = value; }

    public void Start() {
        Rb = GetComponent<Rigidbody>();
        
    }

    public virtual void Dash() {
        if (canDash && AbilityUsed == false) {
            canDash = false;
            AbilityUsed = true;
            Vector3 dashDirection = transform.forward * dashPower + transform.up * 0;
            Rb.AddForce(dashDirection, ForceMode.Impulse);
        }
    }

    protected override void OnAbilityReset() {
        AbilityTimer = cooldown;
        canDash = true;
        AbilityUsed = false;
    }
}
