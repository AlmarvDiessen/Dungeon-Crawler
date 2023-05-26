using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    private bool giveDamage;

    private void OnTriggerEnter(Collider other)
    {
       IDamagable damagable = other.GetComponent<IDamagable>();

        if (giveDamage == true)
        {
            if (damagable != null)
            {
                damagable.TakeDamage(damage);
            }
        }
        giveDamage = false;
    }

    private void OnTriggerExit(Collider other)
    {
        giveDamage = true;
    }
}