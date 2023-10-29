using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{

    public EnemyStateMachine state;
    // Start is called before the first frame update
    void Start()
    {
        Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Disable();
    }


    public void Disable() {
        if(state != null) {
            state.NavAgent.isStopped = true;
        }
    }
}
