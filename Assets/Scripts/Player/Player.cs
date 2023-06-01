using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    [SerializeField] private GiveDamage giveDamage;
    [SerializeField]private ScriptableObject data;

    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private void Awake() {
        if (data != null) {
            initialize(data);
        }

        giveDamage = gameObject.AddComponent<GiveDamage>();

    }

    protected virtual void initialize(ScriptableObject data) {

    }
}