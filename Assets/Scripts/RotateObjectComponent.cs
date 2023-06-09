using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectComponent : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
