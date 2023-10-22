using Assets.Scripts;
using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

// SCRIPT BY ALMAR

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class EnemyClass : Entity {
    [SerializeField] private GiveDamage giveDamage;
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Player player;
    [SerializeField] private List<AddForceComponent> addForceComponents = new List<AddForceComponent>();
    [SerializeField] private AnimationComponent animation;
    //EnemyStateMachine
    private EnemyStateMachine stateMachine;

    [SerializeField] private float detectRange;
    [SerializeField] private int damage;
    [SerializeField] private float wanderDistance;

    public NavMeshAgent NavAgent { get => navAgent; set => navAgent = value; }
    public float WanderDistance { get => wanderDistance; set => wanderDistance = value; }
    public float DetectRange { get => detectRange; set => detectRange = value; }
    public EnemyStateMachine StateMachine { get => stateMachine; set => stateMachine = value; }
    public List<AddForceComponent> AddForceComponents { get => addForceComponents; set => addForceComponents = value; }

    public void Awake() {
        base.Awake();
    }

    public void Start() {
        giveDamage = gameObject.AddComponent<GiveDamage>();
        NavAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        stateMachine = GetComponent<EnemyStateMachine>();
        animation = GetComponentInChildren<AnimationComponent>();
        
        if (data != null) {
            Initialize(data);
        }
    }

    public void Update() {
        stateMachine.Update();
    }

    private void Initialize(ScriptableObject data) {
        EnemyData enemyData = data as EnemyData;
        EntityName = enemyData.EnemyName;
        NavAgent.speed = enemyData.Speed;
        DetectRange = enemyData.DetectRange;
        giveDamage.SetDamage(damage = enemyData.Damage);
        Health.SetHealth(enemyData.Health);
        WanderDistance = enemyData.WanderDistance;
    }
}
