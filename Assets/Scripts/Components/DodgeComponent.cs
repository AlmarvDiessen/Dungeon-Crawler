using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeComponent : AddForceComponent {

    public void Start() {
        base.Start();
    }

    public override void AddForce(Vector3 direction, float upwardForce) {
        Direction = Random.insideUnitCircle * ForcePower;
        upwardForce = 0;
        base.AddForce(direction, upwardForce);
    }

}

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

