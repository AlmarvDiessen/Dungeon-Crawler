using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLookWithCam : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject weaponCamera;

    void Start()
    {
        //weaponCamera.transform.rotation = playerCamera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        weaponCamera.transform.rotation = playerCamera.transform.rotation;

    }
}
