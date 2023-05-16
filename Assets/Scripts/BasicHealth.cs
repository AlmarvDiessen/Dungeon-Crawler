using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private int currentHealth;


    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int pDamage) {
        currentHealth -= pDamage;
    }
}
