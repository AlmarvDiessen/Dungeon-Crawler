using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Entity : MonoBehaviour, IKillable {
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