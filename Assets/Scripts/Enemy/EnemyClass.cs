using Assets.Scripts;
using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class EnemyClass : Entity {
    [SerializeField] private GiveDamage giveDamage;
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Player player;

    [SerializeField] private EnemyState currentState;
    [SerializeField] private EnemyState patrolState;
    [SerializeField] private EnemyState chaseState;

    [SerializeField] private float detectRange;
    [SerializeField] private int damage;
    [SerializeField] private float wanderDistance;

    public EnemyState CurrentState { get => currentState; set => currentState = value; }
    public EnemyState PatrolState { get => patrolState; set => patrolState = value; }
    public EnemyState ChaseState { get => chaseState; set => chaseState = value; }
    public NavMeshAgent NavAgent { get => navAgent; set => navAgent = value; }
    public float WanderDistance { get => wanderDistance; set => wanderDistance = value; }
    public float DetectRange { get => detectRange; set => detectRange = value; }

    private void Start() {
        giveDamage = gameObject.AddComponent<GiveDamage>();
        NavAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        if (data != null) {
            Initialize(data);
        }

        currentState = new EnemyState(this, NavAgent,player);
        patrolState = new PatrolState(this, NavAgent,player);
        chaseState = new ChaseState(this, NavAgent, player);

        currentState = patrolState;
        currentState.EnterState();
    }

    private void Update() {
        currentState.Update();
    }

    private void Initialize(ScriptableObject data) {
        EnemyData enemyData = data as EnemyData;
        EntityName = enemyData.EnemyName;
        NavAgent.speed = enemyData.Speed;
        DetectRange = enemyData.DetectRange;
        giveDamage.SetDamage(damage = enemyData.Damage);
        health.SetHealth(enemyData.Health);
        WanderDistance = enemyData.WanderDistance;
    }

    public void ChangeState(EnemyState stateChange) {
        currentState.ExitState();
        CurrentState = stateChange;
        currentState.EnterState();
    }
}
