using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicJump : MonoBehaviour {

    [SerializeField] private float jumpPower;
    [SerializeField] private bool jump = false;
    [SerializeField] private GameObject ground = null;
    [SerializeField] private Rigidbody rb;

    private bool isGrounded => ground != null;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (isGrounded) {
            jump = (Input.GetKey(KeyCode.Space));
        }
    }

    private void FixedUpdate() {
        Jumping();
    }

    private void Jumping() {
        if (jump && ground != null) {
            rb.AddForce(transform.up * jumpPower);
        }

    }

    private void OnCollisionEnter(Collision collision) {
        GameObject currentGround = ground;
        OnCollisionStay(collision);

    }

    private void OnCollisionStay(Collision collision) {
        //check if we hit something from below or side
        ContactPoint[] contactPoints = collision.contacts;
        float currentHit = -1;

        for (int i = 0; i < collision.contactCount; i++) {
            float nextHit = Vector3.Dot(contactPoints[i].normal, Vector3.up);
            if (nextHit >= currentHit) {
                ground = contactPoints[i].otherCollider.gameObject;
            }
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (ground == collision.gameObject) ground = null;
    }
}
