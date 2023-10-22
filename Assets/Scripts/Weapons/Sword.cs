using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY PAULO

public class Sword : Weapon, IAttack {

    private void Start() {
        base.Start();
        DamageValue = 3;
    }

    private void Update() {
        Attack();
    }

    public void Attack() {
    }
}
