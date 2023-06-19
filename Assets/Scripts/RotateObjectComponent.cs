using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectComponent : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float rotateUpSpeed;

    public float RotateSpeed { get => rotateSpeed; set => rotateSpeed = value; }
    public float RotateUpSpeed { get => rotateUpSpeed; set => rotateUpSpeed = value; }

    void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
        transform.Rotate(0, 0, RotateUpSpeed * Time.deltaTime);
    }
}
