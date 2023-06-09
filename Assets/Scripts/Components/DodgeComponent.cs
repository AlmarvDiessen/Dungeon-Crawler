using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeComponent : DashComponent
{
    private List <Vector3> dodgeDirections = new List<Vector3> ();

    private void Start() {
        base.Start();
        dodgeDirections.Add(-transform.forward);
        dodgeDirections.Add(-transform.right);
        dodgeDirections.Add(transform.right);
    }

    public override void Dash() {
        Direction = dodgeDirections[Random.Range(0, (dodgeDirections.Count - 1))];
        base.Dash();
    }
}
