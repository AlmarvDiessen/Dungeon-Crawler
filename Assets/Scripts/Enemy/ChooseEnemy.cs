using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY ALMAR

public class ChooseEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float X_pos;
    [SerializeField] private float Y_pos;
    [SerializeField] private float Z_pos;

    private void Awake()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        Instantiate(enemy,new Vector3(X_pos, Y_pos, Z_pos), Quaternion.identity);
    }
}
