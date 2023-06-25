using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class JumpComponent : TimerComponent {

    [SerializeField] private bool canJump = true;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private float jumpPower;
    [SerializeField] private float cooldown;

    private Rigidbody rb;
    private NavMeshAgent agent;
    [SerializeField]private GameObject ground = null;
    public bool CanJump { get => canJump; set => canJump = value; }
    public GameObject Ground { get => ground; set => ground = value; }

    private void Start() {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Jump() {
        if (ground != null && CanJump && AbilityUsed == false) {
            TurnAgentOff();
            CanJump = false;
            AbilityUsed = true;
            Vector3 jumpDirection = transform.forward * 0 + transform.up * jumpPower;
            rb.AddForce(jumpDirection, ForceMode.Impulse);
            Debug.Log("jumped");
        }

        if (ground == null) {
            isJumping = true;
        }
        else {
            isJumping = false;
        }
    }

    protected override void OnAbilityReset() {
        AbilityTimer = cooldown;
        canJump = true;
        AbilityUsed = false;
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject currentGround = Ground;
        OnCollisionStay(collision);
        agent.nextPosition = gameObject.transform.position;
        TurnAgentOn();
    }

    private void TurnAgentOff() {
        agent.updatePosition = false;
        agent.updateRotation = false;
        agent.isStopped = true;
    }
    private void TurnAgentOn() {
        agent.updatePosition = true;
        agent.updateRotation = true;
        agent.isStopped = false;
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
    //StartCoroutine(JumpCoolDown());
    //StartCoroutine(GroundCheck());
    //private IEnumerator JumpCoolDown() {
    //    yield return new WaitForSeconds(jumpCooldown);
    //    CanJump = true;
    //}

    //private IEnumerator GroundCheck() {
    //    while (ground == null) {
    //        yield return null;
    //    }
    //    yield return new WaitForSeconds(0.5f);
    //    if (ground != null)
    //        TurnAgentOn();
    //}
}
