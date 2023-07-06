using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY PAULO

public class SpawnWall : MonoBehaviour
{
   public GameObject wall;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        Instantiate(wall, new Vector3(0, 1.1798f,0), new Quaternion(0,0,0,0));
    }
}
