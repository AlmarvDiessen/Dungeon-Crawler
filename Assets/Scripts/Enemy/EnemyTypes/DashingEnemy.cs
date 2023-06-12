using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DashingEnemy : EnemyClass
{
    private DashComponent dashComponent;

    private void Start() {
        base.Start();
        dashComponent = gameObject.GetComponent<DashComponent>();
        dashComponent.Direction = transform.forward;
        StateMachine.OnChaseUpdate += dashComponent.Dash;
    }
}
