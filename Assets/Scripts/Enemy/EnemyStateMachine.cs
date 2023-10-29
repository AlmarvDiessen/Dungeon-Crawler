using Assets.Scripts.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour {

    //public List<EnemyState> allStates = new List<EnemyState>();

    public event Action<Vector3> OnChaseUpdate = delegate { };
    //public event Action OnChaseExit = delegate { };

    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Player player;
    [SerializeField] private EnemyClass enemy;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private EnemyState currentState;
    [SerializeField] private EnemyState patrolState;
    [SerializeField] private EnemyState chaseState;
    [SerializeField] private EnemyState dyingState;

    public EnemyState CurrentState { get => currentState; set => currentState = value; }
    public EnemyState PatrolState { get => patrolState; set => patrolState = value; }
    public EnemyState ChaseState { get => chaseState; set => chaseState = value; }
    public EnemyState DyingState{ get => dyingState; set => dyingState = value; }
    public Rigidbody Rb { get => rb; set => rb = value; }
    public EnemyClass Enemy { get => enemy; set => enemy = value; }
    public NavMeshAgent NavAgent { get => navAgent; set => navAgent = value; }

    public EnemyStateMachine(EnemyClass enemy, NavMeshAgent agent, Player player) {
        this.Enemy = enemy;
        this.player = player;
        NavAgent = agent;
    }

    public void Awake() {
        CurrentState = new EnemyState(Enemy, NavAgent, this.player);
        PatrolState = new PatrolState(Enemy, NavAgent, this.player);
        ChaseState = new ChaseState(Enemy, NavAgent, this.player);
        DyingState = new DieState(Enemy, NavAgent, this.player);
        

        currentState = patrolState;
        rb = GetComponent<Rigidbody>();
    }

    public void Update() {

        CurrentState.Update();

        if (currentState == chaseState) {
            //OnChaseUpdate();
        }
        //if(currentState == patrolState) {
        //    OnChaseExit();
        //}
    }

    public void ChangeState(EnemyState stateChange) {
        CurrentState.ExitState();
        CurrentState = stateChange;
        CurrentState.EnterState();
    }

    public void OnChaseActive() {
        OnChaseUpdate(Vector3.zero);

    }

    public void OnChaseDeactive() {
        //OnChaseExit();  
    }
}

