using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY ALMAR

[CreateAssetMenu]
public class EnemyData : ScriptableObject {

    // Variables
    [SerializeField] private string enemyName;
    [SerializeField] private GameObject enemyModel;
    [SerializeField] private int health = 20;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float wanderDistance = 4f;
    [SerializeField] private float detectRange = 10f;
    [SerializeField] private int damage = 1;

    // Properties
    public string EnemyName { get => enemyName; set => enemyName = value; }
    public GameObject EnemyModel { get => enemyModel; set => enemyModel = value; }
    public int Health { get => health; set => health = value; }
    public float Speed { get => speed; set => speed = value; }
    public float DetectRange { get => detectRange; set => detectRange = value; }
    public int Damage { get => damage; set => damage = value; }
    public float WanderDistance { get => wanderDistance; set => wanderDistance = value; }
}
