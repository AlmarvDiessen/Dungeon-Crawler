using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY ALMAR

public class Entity : MonoBehaviour {
    [SerializeField] protected ScriptableObject data;
    [SerializeField] protected Health health;
    [SerializeField] protected string EntityName;
    [SerializeField] private GameObject dropItem;

    public GameObject DropItem { get => dropItem; set => dropItem = value; }
    public Health Health { get => health; set => health = value; }

    public void Awake() {

        Health = this.gameObject.AddComponent<Health>();
    }

}