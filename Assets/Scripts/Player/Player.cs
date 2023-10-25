using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// SCRIPT BY ALMAR

public class Player : Entity, IKillable {

    [SerializeField] private AddForceComponent dash;
    [SerializeField] private BetterMovement playerMovement;
    [SerializeField] private EquipmentManager equipmentManager;
    [SerializeField] private int playerHealth;


    private void Awake() {
        base.Awake();
        playerHealth = 20;
    }

    private void Start() {
        dash = GetComponent<DashComponent>();
        playerMovement = GetComponent<BetterMovement>();
        equipmentManager = GetComponent<EquipmentManager>();

        Health.Initialize(playerHealth, playerHealth);
        health.onHealthZero += Die;

    }
    private void FixedUpdate() {
        playerMovement.Movement();


    }
    public void Die() {
        //show game over screen
        Debug.Log("player dies");
        SceneManager.LoadScene(2);//GameOver
    }


    private void Update() {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
{
            if (equipmentManager.Weapon != null) {
                equipmentManager.Weapon.Attack();
            }
        }
    }
}