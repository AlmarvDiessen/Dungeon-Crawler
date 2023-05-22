using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Health))]
public class EnemyController : Entity {

    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Health EnemyHealth;

    [SerializeField] private float wanderDistance = 4f;


    void Start() {

        if (navAgent == null) {
            navAgent = GetComponent<NavMeshAgent>();
        }

        if (enemyData != null) {
            LoadEnemy(enemyData);
        }
    }

    private void LoadEnemy(EnemyData data) {

        foreach (Transform child in this.transform) {
            if (Application.isEditor)
                DestroyImmediate(child.gameObject);
            else
                DestroyImmediate(child.gameObject);
        }

        GameObject visual = Instantiate(data.EnemyModel);
        visual.transform.SetParent(this.transform);
        visual.transform.localPosition = Vector3.zero;
        visual.transform.rotation = Quaternion.identity;

        if (navAgent == null)
            navAgent = GetComponent<NavMeshAgent>();

        this.navAgent.speed = data.Speed;

        EnemyHealth = GetComponent<Health>();
        EnemyHealth.SetHealth(data.Health);
    }

    void Update() {

        if (enemyData == null)
            return;

        if (navAgent.remainingDistance < 1f)
            SetNewDestination();
    }

    private void SetNewDestination() {
        Vector3 newDestination = transform.position;
        newDestination += wanderDistance * new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(newDestination, out hit, 3f, NavMesh.AllAreas))
            navAgent.SetDestination(hit.position);
    }
}
