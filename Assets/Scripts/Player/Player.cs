using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    [SerializeField] private DashComponent dash;
    [SerializeField] private BetterMovement playerMovement;
    private void Awake() {

    }

    private void Start() {
        dash = GetComponent<DashComponent>();
        playerMovement = GetComponent<BetterMovement>();

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