using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumpDashingEnemy : EnemyClass
{
    private JumpComponent jumpComponent;
    private DashComponent dashComponent;
    private NavMeshAgent navMeshAgent;

    private void Start() {
        base.Start();
        jumpComponent = gameObject.GetComponent<JumpComponent>();
        dashComponent = gameObject.GetComponent<DashComponent>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        StateMachine.OnChaseUpdate += dashComponent.Dash;
        StateMachine.OnChaseUpdate += jumpComponent.Jump;
        

        //subscribe
        //Unsubscribe        StateMachine.OnChaseUpdate -= jumpComponent.Jump;
    }


}
