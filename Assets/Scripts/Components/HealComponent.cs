using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY ALMAR

public class HealComponent : MonoBehaviour, IEffects
{
    [SerializeField] private int healAmount;
    private int minHealAmount;
    private int maxHealAmount;
    [SerializeField] private Health health;
    void Start()
    {
        healAmount = Random.Range(minHealAmount, maxHealAmount);
    }

    public void ApplyEffect() {
        Debug.Log("test");
        health.HealHealth(healAmount);
    }
}
 