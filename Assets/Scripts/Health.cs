using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;

    public int getHealth { get => health; set => health = value; }

    public void TakeDamage(int pDamage)
    {
        health -= pDamage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetHealth(int value) {
        health = value;
    }
}

