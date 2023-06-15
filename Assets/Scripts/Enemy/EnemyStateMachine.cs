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

    public event Action OnChaseUpdate = delegate { };
    //public event Action OnChaseExit = delegate { };

    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Player player;
    [SerializeField] private EnemyClass enemy;

    [SerializeField] private EnemyState currentState;
    [SerializeField] private EnemyState patrolState;
    [SerializeField] private EnemyState chaseState;

    public EnemyState CurrentState { get => currentState; set => currentState = value; }
    public EnemyState PatrolState { get => patrolState; set => patrolState = value; }
    public EnemyState ChaseState { get => chaseState; set => chaseState = value; }

    public EnemyStateMachine(EnemyClass enemy, NavMeshAgent agent, Player player) {
        this.enemy = enemy;
        this.player = player;
        navAgent = agent;
    }

    public void Awake() {
        CurrentState = new EnemyState(enemy, navAgent, this.player);
        PatrolState = new PatrolState(enemy, navAgent, this.player);
        ChaseState = new ChaseState(enemy, navAgent, this.player);

        currentState = patrolState;
    }

    public void Update() {

        CurrentState.Update();

        if (currentState == chaseState) {
            OnChaseUpdate();
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
        OnChaseUpdate();

    }

    public void OnChaseDeactive() {
        //OnChaseExit();  
    }
}

