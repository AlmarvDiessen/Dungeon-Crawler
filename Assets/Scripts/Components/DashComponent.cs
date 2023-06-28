using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashComponent : AddForceComponent {

    public void Start() {
        base.Start();
    }

    public override void AddForce(Vector3 direction, float upwardForce) {
        direction = transform.forward;
        upwardForce = 0;
        base.AddForce(direction, upwardForce);
    }
}
