using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceComponent : MonoBehaviour {
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TimerComponent timer;
    [SerializeField] private bool canUse = true;
    [SerializeField] private float forcePower;
    [SerializeField] private float cooldown;

    public Rigidbody Rb { get => rb; set => rb = value; }
    public bool CanUse { get => canUse; set => canUse = value; }
    public float ForcePower { get => forcePower; set => forcePower = value; }
    public float Cooldown { get => cooldown; set => cooldown = value; }
    public TimerComponent Timer { get => timer; set => timer = value; }

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        timer = GetComponent<TimerComponent>();
    }

    public virtual void AddForce(Vector3 direction) {
        if (canUse && timer.AbilityUsed == false) {
            canUse = false;
            timer.AbilityUsed = true;
            Vector3 dashDirection = transform.forward * forcePower + transform.up * 0;
            Rb.AddForce(dashDirection, ForceMode.Impulse);
        }
    }



}
