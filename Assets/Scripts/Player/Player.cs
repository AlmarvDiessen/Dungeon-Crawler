using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    [SerializeField] private DashComponent dash;
    [SerializeField] private BetterMovement playerMovement;
    [SerializeField] private int playerHealth;
    private void Awake() {
        playerHealth = 20;
    }

    private void Start() {
        dash = GetComponent<DashComponent>();
        playerMovement = GetComponent<BetterMovement>();

        health.SetHealth(playerHealth);

    }
    private void FixedUpdate() {
        playerMovement.Movement();
       
    }

    private void Update() {
        PlayerDash();
    }
    public void PlayerDash() {
        if(Input.GetKeyDown(KeyCode.LeftShift)&& dash.CanDash) {
           dash.Dash();
        }
    }
}