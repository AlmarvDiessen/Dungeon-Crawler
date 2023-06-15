
using Assets.Scripts.Enemy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace Assets.Scripts.Enemy {
    public class EnemyState {
        public EnemyClass enemy;
        public Player player;
        public NavMeshAgent agent;

        public EnemyState(EnemyClass pEnemy, NavMeshAgent pAgent, Player pPlayer) {
            enemy = pEnemy;
            agent = pAgent;
            player = pPlayer;
        }
        public virtual void Update() {

        }

        public virtual void EnterState() {

        }

        public void ExitState() {

        }
    }
}

public class PatrolState : EnemyState {
    private GameObject playerPos;

    public PatrolState(EnemyClass pEnemy, NavMeshAgent pAgent, Player pPlayer) : base(pEnemy, pAgent, pPlayer) {
        player = pPlayer;
    }

    public override void EnterState() {
        //test for enter or continious
        playerPos = player.gameObject;
    }

    public override void Update() {
        if (agent.remainingDistance < 1f) {
            if (enemy.StateMachine.CurrentState != enemy.StateMachine.ChaseState)
                SetNewDestination();
        }

            float distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (distance <= enemy.DetectRange)
            enemy.StateMachine.ChangeState(enemy.StateMachine.ChaseState);
    }

    public void SetNewDestination() {
        Vector3 newDestination = enemy.transform.position;
        newDestination += enemy.WanderDistance * new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(newDestination, out hit, 3f, NavMesh.AllAreas)) {
            agent.SetDestination(hit.position);
            //LookForPlayer();
        }
    }
}

public class ChaseState : EnemyState {
    // private GameObject playerPos;

    public ChaseState(EnemyClass pEnemy, NavMeshAgent pAgent, Player pPlayer) : base(pEnemy, pAgent, pPlayer) {


    }
    public override void EnterState() {
        enemy.transform.LookAt(player.transform);
    }

    public override void Update() {
        ChasePlayer(player.transform);
    }

    public void ChasePlayer(Transform transform) {

        Vector3 playerPosistion = transform.position;
        agent.SetDestination(playerPosistion);

        //if (/*playerPosistion != null && */distance <= enemy.DetectRange)


        float distance = Vector3.Distance(enemy.transform.position, playerPosistion);
        if (/*playerPosistion == null && */distance >= enemy.DetectRange)
            enemy.StateMachine.ChangeState(enemy.StateMachine.PatrolState);

    }
}

