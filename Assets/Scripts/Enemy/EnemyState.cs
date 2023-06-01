
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy {
    public class EnemyState {
        public EnemyClass enemy;
        public GameObject player;
        public OntriggerComponent onTrigger;
        public NavMeshAgent agent;

        public EnemyState(EnemyClass pEnemy, NavMeshAgent pAgent, OntriggerComponent trigger) {
            enemy = pEnemy;
            onTrigger = trigger;
            agent = pAgent;
        }

        public virtual void Update() {

        }

        public void LookForPlayer() {

            if (onTrigger.GetGameObject != null) {
                player = onTrigger.GetGameObject;
                Debug.Log(player);

                if (player != null)
                    enemy.ChangeState(enemy.ChaseState);
                else
                    enemy.ChangeState(enemy.PatrolState);
            }
        }
    }

    public class PatrolState : EnemyState {
        public PatrolState(EnemyClass pEnemy, NavMeshAgent agent, OntriggerComponent gameObject) : base(pEnemy, agent, gameObject) {

        }
        public override void Update() {
            if (agent.remainingDistance < 1f) {
                SetNewDestination();
                LookForPlayer();
            }
        }

        public void SetNewDestination() {
            Vector3 newDestination = enemy.transform.position;
            newDestination += enemy.WanderDistance * new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(newDestination, out hit, 3f, NavMesh.AllAreas))
                agent.SetDestination(hit.position);
        }
    }

    public class ChaseState : EnemyState {
        public ChaseState(EnemyClass pEnemy, NavMeshAgent agent, OntriggerComponent gameObject) : base(pEnemy, agent, gameObject) {
        }

        public override void Update() {
            Debug.Log("chasing");
            if(onTrigger.GetGameObject == null) {
                enemy.ChangeState(enemy.PatrolState);
            }

        }
    }
}
