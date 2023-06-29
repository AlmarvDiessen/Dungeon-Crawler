using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    [SerializeField] 

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
    }
}
