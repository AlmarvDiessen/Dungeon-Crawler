﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

// SCRIPT BY ALMAR

namespace Assets.Scripts {
    // class for the first person camera movement using mouse. this is attached to the camera object
    public class PlayerCamera : MonoBehaviour {
        // get camera gameobject
        [SerializeField] private new Camera camera;
        // get player gameobject
        [SerializeField] private GameObject player;
        // get the mouse sensitivity
        [SerializeField, Range(0.1f, 1000f)]
        private float mouseSensitivity = 100f;
        // get the x rotation
        [SerializeField] private float xRotation = 0f;
        [SerializeField] private Rigidbody rb;

        // Start is called before the first frame update
        void Start() {
            rb = GetComponent<Rigidbody>();
            // lock the cursor to the center of the screen
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void FixedUpdate() {
            // get the mouse x and y axis
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // rotate the camera on the x axis
            xRotation -= mouseY;
            // clamp the rotation
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            // rotate the camera
            camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            // rotate the player on the y axis
            player.transform.Rotate(Vector3.up * mouseX);

            float rotate = player.transform.rotation.y;
        }
    }
}
