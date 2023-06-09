using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumpingEnemy : EnemyClass {
    private JumpComponent jumpComponent;
    private NavMeshAgent navMeshAgent;

    private void Start() {
        base.Start();
        jumpComponent = gameObject.GetComponent<JumpComponent>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        StateMachine.OnChaseUpdate += jumpComponent.Jump;

        //subscribe
        //Unsubscribe        StateMachine.OnChaseUpdate -= jumpComponent.Jump;
    }


    private void Update() {

    }
}
