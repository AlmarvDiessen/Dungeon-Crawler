using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY PAULO

public class Spear : Weapon, IAttack
{

    private void Start() {
        base.Start();
        DamageValue = 5;
    }

    private void Update() {
        Attack();
    }

    public void Attack() {

    }
}
