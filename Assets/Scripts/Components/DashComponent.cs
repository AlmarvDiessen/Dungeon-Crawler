using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashComponent : MonoBehaviour {
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashTimer = 8;
    [SerializeField] private float dashCooldown;
    private Vector3 direction;

    [SerializeField] private Rigidbody rb;

    public bool CanDash { get => canDash; set => canDash = value; }
    public bool IsDashing { get => isDashing; set => isDashing = value; }
    public Vector3 Direction { get => direction; set => direction = value; }
    public Rigidbody Rb { get => rb; set => rb = value; }

    public void Start() {
        Rb = GetComponent<Rigidbody>();
        Direction = transform.forward;
    }
    public virtual void Dash() {
        dashTimer -= Time.deltaTime;
        if (canDash && isDashing == false) {
            canDash = false;
            IsDashing = true;
            Vector3 dashDirection = Direction * dashPower + transform.up * 0;
            Rb.AddForce(dashDirection, ForceMode.Impulse);
        }

        if (dashTimer <= 0) {
            dashTimer = 8f;
            canDash = true;
            isDashing = false;
        }
    }
}
