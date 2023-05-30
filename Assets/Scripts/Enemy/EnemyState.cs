
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy {
    public class EnemyState {
        public EnemyClass enemy;

        public EnemyState(EnemyClass pEnemy, NavMeshAgent agent) {
            enemy = pEnemy;
        }

        public virtual void Update() {

        }

        public void LookForPlayer() {
            //add player ref
            enemy.ChangeState(enemy.ChaseState);
        }
    }

    public class PatrolState : EnemyState {
        public PatrolState(EnemyClass pEnemy, NavMeshAgent agent) : base(pEnemy, agent) {

        }
        public override void Update() {
            if (enemy.NavAgent.remainingDistance < 1f)
                LookForPlayer();
                SetNewDestination();
        }

        public void SetNewDestination() {
            Vector3 newDestination = enemy.transform.position;
            newDestination += enemy.WanderDistance * new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(newDestination, out hit, 3f, NavMesh.AllAreas))
                enemy.NavAgent.SetDestination(hit.position);
        }
    }

    public class ChaseState : EnemyState {
        public ChaseState(EnemyClass pEnemy, NavMeshAgent agent) : base(pEnemy, agent) {
        }
    }
}
