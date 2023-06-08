using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : EnemyClass {
    [SerializeField] JumpComponent jumpComponent;

    private void Start() {
        base.Start();
        jumpComponent.GetComponent<JumpComponent>();
        //subscribe
        StateMachine.OnChaseUpdate += jumpComponent.Jump;
        //Unsubscribe        StateMachine.OnChaseUpdate -= jumpComponent.Jump;

    }


    private void Update() {

    }
}
