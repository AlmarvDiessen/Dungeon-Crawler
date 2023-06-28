using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{

    private void Start() {
        base.Start();
        DamageValue = 5;
    }

    private void Update() {
        Attack();
    }

    public override void Attack() {
    }
}
