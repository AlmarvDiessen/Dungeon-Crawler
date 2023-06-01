using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    [SerializeField] private GiveDamage giveDamage;

    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private void Awake() {
        if (data != null) {
            Initialize(data);
        }

        giveDamage = gameObject.AddComponent<GiveDamage>();

    }

    protected virtual void Initialize(ScriptableObject data) {

    }
}