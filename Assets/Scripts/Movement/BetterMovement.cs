﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts {
    public class BetterMovement : MonoBehaviour {

        public float speed = 10f;
        Rigidbody rb;
        Vector3 PlayerMovementInput;

        private void Start() {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            Movement();
        }

        private void Movement() {
            PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            Vector3 movement = transform.TransformDirection(PlayerMovementInput) * speed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
    }
}