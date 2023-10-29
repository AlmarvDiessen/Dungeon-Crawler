using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable {
    public delegate void HealthChangeHandler(int currentHealth, int maxHealth);
    public delegate void HealthZeroDelegate();
    public event HealthChangeHandler onHealthChange;
    public SkinnedMeshRenderer mesh;



    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public HealthZeroDelegate onHealthZero { get; set; }
    public int getHealth { get => currentHealth; set => currentHealth = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    public void Initialize(int currentHealth, int maxHealth) {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        try {
            mesh = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        }
        catch (Exception ex) {
            Debug.Log(ex.Message);
        }
    }

    public void TakeDamage(int pDamage) {
        currentHealth = math.clamp(currentHealth - pDamage, 0, maxHealth);
        onHealthChange?.Invoke(currentHealth, maxHealth);
        if (currentHealth <= 0) {
            onHealthZero?.Invoke();
        }
    }
    public IEnumerator ChangeColor() {
        if (mesh != null) {
            yield return new WaitForSeconds(0.2f);
            mesh.material.color = Color.red;
            yield return new WaitForSeconds(0.4f);
            mesh.material.color = Color.white;
        }
        else {
            yield return null;
        }
    }
    public void SetHealth(int value) {
        currentHealth = value;
    }

    public void HealHealth(int amount) {
        currentHealth += amount;
    }
}

