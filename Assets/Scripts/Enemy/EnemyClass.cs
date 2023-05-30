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
    [SerializeField] private SphereCollider detectCollider;
    [SerializeField] private OntriggerComponent other;

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
    public OntriggerComponent Other { get => other; set => other = value; }

    private void Start() {
        giveDamage = gameObject.AddComponent<GiveDamage>();
        Other = GetComponent<OntriggerComponent>();
        NavAgent = GetComponent<NavMeshAgent>();

        if (data != null) {
            initialize(data);
        }

        currentState = new EnemyState(this, NavAgent);
        patrolState = new PatrolState(this, NavAgent);
        chaseState = new ChaseState(this, NavAgent,Other);
        currentState = patrolState;
    }

    private void Update() {
        currentState.Update();
    }

    protected override void initialize(ScriptableObject data) {
        EnemyData enemyData = data as EnemyData;
        EntityName = enemyData.EnemyName;
        NavAgent.speed = enemyData.Speed;
        detectCollider.radius = enemyData.DetectRange;
        giveDamage.SetDamage(damage = enemyData.Damage);
        health.SetHealth(enemyData.Health);
        WanderDistance = enemyData.WanderDistance;
    }

    public void ChangeState(EnemyState stateChange) {
        CurrentState = stateChange;
    }
}
