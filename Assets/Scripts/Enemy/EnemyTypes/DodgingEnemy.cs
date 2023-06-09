using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : EnemyClass
{
    private DodgeComponent dodgeComponent;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        dodgeComponent = gameObject.GetComponent<DodgeComponent>();
        StateMachine.OnChaseUpdate += dodgeComponent.Dash;
    }

}
