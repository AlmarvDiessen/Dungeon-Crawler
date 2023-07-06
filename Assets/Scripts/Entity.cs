using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY ALMAR

public class Entity : MonoBehaviour, IKillable {
    [SerializeField] protected ScriptableObject data;
    [SerializeField] protected Health health;
    [SerializeField] protected string EntityName;
    [SerializeField] private GameObject dropItem;

    public GameObject DropItem { get => dropItem; set => dropItem = value; }


    public void Awake() {
        
        health = this.gameObject.AddComponent<Health>();
    }

    public virtual void Kill() {

    }
}
