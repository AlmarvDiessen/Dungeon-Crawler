using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private GiveDamage giveDamage;

    [SerializeField] private float speed;
    [SerializeField] private float detectRange;
    [SerializeField] private int damage;

    private void Awake() {
        giveDamage = gameObject.AddComponent<GiveDamage>();

        if(data != null) {
            initialize(data);
        }

    }

    protected override void initialize(ScriptableObject data) {
        EnemyData enemyData = data as EnemyData;
        EntityName = enemyData.EnemyName;
        speed = enemyData.Speed;
        detectRange = enemyData.DetectRange;
        giveDamage.SetDamage(damage = enemyData.Damage);
        health.SetHealth(enemyData.Health);
    }
}
