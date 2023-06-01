using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int healthValue;

    public int getHealth { get => healthValue; set => healthValue = value; }

    public void TakeDamage(int pDamage)
    {
        healthValue -= pDamage;
        if (healthValue <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetHealth(int value) {
        healthValue = value;
    }
}

