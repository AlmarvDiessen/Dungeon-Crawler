using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeComponent : TimerComponent {
    private List<Vector3> dodgeDirections = new List<Vector3>();
    [SerializeField] private Rigidbody rb;
    private Vector3 direction;

    [SerializeField] private bool canDodge = true;
    [SerializeField] private bool isDodging;
    [SerializeField] private float dodgePower;
    [SerializeField] private float cooldown;


    public bool CanDash { get => canDodge; set => canDodge = value; }
    public bool IsDashing { get => isDodging; set => isDodging = value; }
    public Vector3 Direction { get => direction; set => direction = value; }
    public Rigidbody Rb { get => rb; set => rb = value; }

    //private void Start() {
    //    Rb = GetComponent<Rigidbody>();

    //    dodgeDirections.Add(-transform.forward);
    //    dodgeDirections.Add(-transform.right);
    //    dodgeDirections.Add(-transform.right);
    //    dodgeDirections.Add(transform.right);
    //    dodgeDirections.Add(transform.right);
    //}

    //public void Dodge() {
    //    if (canDodge && AbilityUsed == false) {
    //        canDodge = false;
    //        AbilityUsed = true;
    //        Direction = dodgeDirections[Random.Range(0, (dodgeDirections.Count - 1))];
    //        Vector3 dashDirection = Direction * dodgePower + transform.up * 0;
    //        Rb.AddForce(dashDirection, ForceMode.Impulse);
    //    }
    //}

    //protected override void OnAbilityReset() {
    //    AbilityTimer = cooldown;
    //    canDodge = true;
    //    AbilityUsed = false;
    //}
}
