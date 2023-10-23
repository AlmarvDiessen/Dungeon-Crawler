using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claws : Weapon, IAttack {
    public float attackInterval = 2.0f; // Time interval between claw attacks
    public float attackRange = 1.5f;
    private float timeSinceLastAttack = 0f;
    private bool canAttack = true;

    private void Start() {
        DamageValue = 2;
    }
    void Update() {
        timeSinceLastAttack += Time.deltaTime;

        if (timeSinceLastAttack >= attackInterval) {
            canAttack = true;
        }
    }

    public void Attack() {
        if (canAttack) {
            // Perform the claw attack and deal damage to the target
            Debug.Log("Claw attack!");

            // Perform a box cast in the forward direction of the sword
            RaycastHit hit;
            if (Physics.BoxCast(transform.position + transform.forward * attackRange, Vector3.one, transform.forward, out hit, transform.rotation, 10f)) {
                // Check if the hit object has a HealthComponent
                Debug.Log(hit.collider.gameObject.name);
                Health hitHealth = hit.transform.GetComponent<Health>();
                if (hitHealth != null) {
                    int damage = base.DamageValue;
                    hitHealth.TakeDamage(damage);
                }
            }

            canAttack = false;
            timeSinceLastAttack = 0f;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + transform.forward * (attackRange * 1.5f), Vector3.one * 2f);
    }
}
