using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY PAULO

public class RotateObjectComponent : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    public float RotateSpeed { get => rotateSpeed; set => rotateSpeed = value; }

    void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
    }
}
