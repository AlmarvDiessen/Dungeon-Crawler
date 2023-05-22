using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Health health;

    private IDamagable damagable;

    private bool giveDamage;

    private void OnTriggerEnter(Collider other)
    {
        health = other.GetComponent<Health>();
        damagable = other.GetComponent<IDamagable>();

        if (giveDamage == true)
        {
            if (health && damagable != null)
            {
                health.TakeDamage(damage);
            }
        }
        giveDamage = false;
    }

    private void OnTriggerExit(Collider other)
    {
        giveDamage = true;
    }
}