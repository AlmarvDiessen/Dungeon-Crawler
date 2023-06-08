using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DashingEnemy : EnemyClass
{
    [SerializeField] private DashComponent dashComponent;



    private void Update() {
        //CurrentState.Update();

        //if(CurrentState == ChaseState && dashComponent.CanDash) {
        //    dashComponent.Dash();
        //}
    }
}
