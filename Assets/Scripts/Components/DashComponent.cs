using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashComponent : AddForceComponent {
    private TimerComponent timer;
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
        base.Start();
    }

    public void Update() {
        base.Update();
    }

    public override void AddForce(Vector3 direction) {
        direction = transform.forward;
        base.AddForce(direction);
    }

}
