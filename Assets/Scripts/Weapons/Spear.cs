using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY PAULO

public class Spear : Weapon, IAttack
{
    private float attackRange = 3.5f;
    [SerializeField] private Transform attackPoint;

    private void Start() {
        base.Start();
        DamageValue = 5;
    }

    private void Update() {
    }

    public void Attack() {
        Debug.Log("Thrusting with the spear");
        attackPoint = Camera.main.transform;
        // Perform a raycast in the forward direction of the spear
        RaycastHit hit;
        if (Physics.Raycast(attackPoint.transform.position, attackPoint.transform.forward, out hit, attackRange)) {
            // Check if the hit object has a HealthComponent
            Debug.Log(hit.collider.name);
            Health hitHealth = hit.transform.GetComponent<Health>();
            if (hitHealth != null) {
                int damage = base.DamageValue;
                hitHealth.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        if(attackPoint != null)
        Gizmos.DrawRay(attackPoint.transform.position, attackPoint.transform.forward * attackRange);
    }
}
