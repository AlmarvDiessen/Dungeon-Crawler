using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumpComponent : MonoBehaviour
{

    [SerializeField] private bool canJump = true;
    [SerializeField] private bool isJumping;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpCooldown;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject ground = null;


    public bool CanJump { get => canJump; set => canJump = value; }
    public bool IsJumping { get => isJumping; set => isJumping = value; }
    public GameObject Ground { get => ground; set => ground = value; }

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }


    public void Jump() {
        Debug.Log("jumping");
        CanJump = false;
        IsJumping = true;
        Vector3 jumpDirection = transform.forward * 0 + transform.up * jumpPower;
        rb.AddForce(jumpDirection, ForceMode.Impulse);
        StartCoroutine(JumpCoolDown());
    }

    private IEnumerator JumpCoolDown() {
        yield return new WaitForSeconds(jumpTime);
        IsJumping = false;
        yield return new WaitForSeconds(jumpCooldown);
        CanJump = true;
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject currentGround = Ground;
        OnCollisionStay(collision);

    }

    private void OnCollisionStay(Collision collision) {
        //check if we hit something from below or side
        ContactPoint[] contactPoints = collision.contacts;
        float currentHit = -1;

        for (int i = 0; i < collision.contactCount; i++) {
            float nextHit = Vector3.Dot(contactPoints[i].normal, Vector3.up);
            if (nextHit >= currentHit) {
                Ground = contactPoints[i].otherCollider.gameObject;
            }
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (Ground == collision.gameObject) Ground = null;
    }
}
