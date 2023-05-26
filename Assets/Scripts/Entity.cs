using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Entity : MonoBehaviour {
    [SerializeField] protected ScriptableObject data;
    [SerializeField] protected Health health;
    [SerializeField] protected string EntityName;


    private void Awake() {
        
        health = this.gameObject.AddComponent<Health>();
    }


    protected virtual void initialize(ScriptableObject data) {

    }

}
