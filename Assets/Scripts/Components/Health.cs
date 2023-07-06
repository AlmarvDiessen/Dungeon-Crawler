using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY ALMAR & PAULO

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int healthValue;

    public int getHealth { get => healthValue; set => healthValue = value; }

    public void TakeDamage(int pDamage)
    {
        healthValue -= pDamage;
    }

    public void SetHealth(int value) {
        healthValue = value;
    }

    public void HealHealth(int amount) {
        healthValue += amount;
    }
}

