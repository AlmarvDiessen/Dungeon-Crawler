using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY Almar

public class Sword : Weapon, IAttack {

    public float attackRange = 2f;
    [SerializeField] private Transform attackPoint;

    private void Start() {
        base.Start();
        DamageValue = 3;
    }

    private void Update() {
    }

    public void Attack() {
        attackPoint = Camera.main.transform;

        // Perform a box cast in the forward direction of the sword
        RaycastHit hit;
        if (Physics.BoxCast(attackPoint.transform.position, Vector3.one * 0.5f, attackPoint.transform.forward, out hit, transform.rotation, attackRange)) {
            // Check if the hit object has a HealthComponent
            Health hitHealth = hit.transform.GetComponent<Health>();
            if (hitHealth != null) {
                int damage = base.DamageValue;
                hitHealth.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.transform.position + attackPoint.transform.forward * (attackRange / 2), new Vector3(attackRange, 1, 1));
    }
}
