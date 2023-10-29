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


        private bool attacked;
        private bool walking;
        public bool inAttackRange { get => attacked; set => attacked = value; }
        public bool Walking { get => walking; set => walking = value; }

        public EnemyState(EnemyClass pEnemy, NavMeshAgent pAgent, Player pPlayer) {
            enemy = pEnemy;
            agent = pAgent;
            player = pPlayer;
        }

        public virtual void Update() {

            if (enemy.Health.getHealth <= 0) {
                enemy.StateMachine.ChangeState(enemy.StateMachine.DyingState);
            }
        }

        public bool checkMovement() {
            if (agent.velocity.magnitude >= 0) {
                walking = true;
                return walking;
            }
            else {
                walking = false;
                return walking;
            }
        }

        public virtual void EnterState() {

        }

        public void ExitState() {

        }


    }

}

public class PatrolState : EnemyState {
    private Vector3 playerPos;

    public PatrolState(EnemyClass pEnemy, NavMeshAgent pAgent, Player pPlayer) : base(pEnemy, pAgent, pPlayer) {
        player = pPlayer;
    }

    public override void EnterState() {
        //test for enter or continious
    }

    public override void Update() {
        base.Update();
        playerPos = player.gameObject.transform.position;

        if (agent.remainingDistance < 1f) {
            if (enemy.StateMachine.CurrentState != enemy.StateMachine.ChaseState)
                SetNewDestination();
        }

        float distance = Vector3.Distance(enemy.transform.position, playerPos);
        if (LineOfSight())
            enemy.StateMachine.ChangeState(enemy.StateMachine.ChaseState);
    }

    private bool LineOfSight() {
        RaycastHit hit;
        if (Physics.Raycast(enemy.transform.position, playerPos - enemy.transform.position, out hit, enemy.DetectRange)) {
            Player player = hit.collider.GetComponent<Player>();
            if (player != null) {
                return true;
            }
            return false;
        }
        else
            return false;
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
        //jump.gameObject.GetComponent<AddForceComponent>();
        //dash.gameObject.GetComponent<AddForceComponent>();

    }

    public override void Update() {
        base.Update();

        ChasePlayer(player.transform);
        //addforcecomp.Addforce gebruiken
        foreach (AddForceComponent force in enemy.AddForceComponents) {

            if (force.GetType() == typeof(JumpComponent)) {
                force.AddForce(enemy.transform.forward, force.ForceUpPower);
            }
            force.AddForce(force.Direction, 0);
        }
    }

    public void ChasePlayer(Transform transform) {

        float offset = 3f;
        Vector3 playerPosistion = transform.position + (transform.forward * offset);
        agent.SetDestination(playerPosistion);
        enemy.transform.LookAt(transform);

        //if (/*playerPosistion != null && */distance <= enemy.DetectRange)


        float distance = Vector3.Distance(enemy.transform.position, playerPosistion);
        if (/*playerPosistion == null && */distance >= enemy.DetectRange)
            enemy.StateMachine.ChangeState(enemy.StateMachine.PatrolState);

        if (distance <= 2f) {
            inAttackRange = true;
        }
        else {
            inAttackRange = false;
        }


    }
}

public class DieState : EnemyState {

    public DieState(EnemyClass pEnemy, NavMeshAgent pAgent, Player pPlayer) : base(pEnemy, pAgent, pPlayer) {

    }

    public override void EnterState() {
        DyingState();
    }

    public override void Update() {
        base.Update();
    }

    public void DyingState() {
        inAttackRange = false;
        agent.isStopped = true;
    }
}




