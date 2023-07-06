using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY PAULO

public class Sword : Weapon {

    private void Start() {
        base.Start();
        DamageValue = 3;
    }

    private void Update() {
        Attack();
    }

    public override void Attack() {
    }
}
