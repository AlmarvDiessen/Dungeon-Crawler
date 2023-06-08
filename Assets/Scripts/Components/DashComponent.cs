using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashComponent : MonoBehaviour
{
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;

    [SerializeField] private Rigidbody rb;

    public bool CanDash { get => canDash; set => canDash = value; }
    public bool IsDashing { get => isDashing; set => isDashing = value; }

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    public void Dash() {
        Debug.Log("dashing");
        canDash = false;
        IsDashing = true;
        Vector3 dashDirection = transform.forward * dashPower + transform.up * 0;
        rb.AddForce(dashDirection, ForceMode.Impulse);
        StartCoroutine(DashCooldown());
    }

    private IEnumerator DashCooldown() {
        yield return new WaitForSeconds(dashTime);
        IsDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
