using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour {

    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private EnemyData data;
    [SerializeField] private float wanderDistance = 4f;


    void Start() {

        if(navAgent == null) {
            navAgent = GetComponent<NavMeshAgent>();
        }

        if (data != null) {
            LoadEnemy(data);
        }
    }

    private void LoadEnemy(EnemyData data) {

        foreach (Transform child in this.transform) {
            if (Application.isEditor)
                DestroyImmediate(child.gameObject);
            else
                DestroyImmediate(child.gameObject);
        }

        GameObject visual = Instantiate(data.enemyModel);
        visual.transform.SetParent(this.transform);
        visual.transform.localPosition = Vector3.zero;
        visual.transform.rotation = Quaternion.identity;

        if(navAgent == null)
            navAgent = GetComponent<NavMeshAgent>();

        this.navAgent.speed = data.speed;
       
    }

    void Update() {

        if (data == null)
            return;

        if(navAgent.remainingDistance < 1f)
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
