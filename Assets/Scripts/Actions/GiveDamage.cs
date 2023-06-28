using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    [SerializeField] private int damageValue;
    private bool giveDamage;


    private void OnTriggerEnter(Collider other)
    {
       IDamagable damagable = other.GetComponent<IDamagable>();

        if (giveDamage == true)
        {
            if (damagable != null)
            {
                damagable.TakeDamage(damageValue);
            }
        }
        giveDamage = false;
    }

    public void SetDamage(int value) {
        damageValue = value;
    }

    private void OnTriggerExit(Collider other)
    {
        giveDamage = true;
    }
}