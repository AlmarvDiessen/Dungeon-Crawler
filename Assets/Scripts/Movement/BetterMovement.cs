using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

// SCRIPT BY ALMAR

namespace Assets.Scripts {
    public class BetterMovement : MonoBehaviour {

        [SerializeField] private float speed = 10f;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private DashComponent dash;
        [SerializeField] private Vector3 PlayerMovementInput;

        private void Start() {
            rb = GetComponent<Rigidbody>();
            dash = GetComponent<DashComponent>();
        }
        public void Movement() {
            if (!dash.IsUsing) {
                PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

                Vector3 movement = transform.TransformDirection(PlayerMovementInput) * speed;
                rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
            }
        }
    }
}
