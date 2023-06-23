using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IEquippable
{
    // add weapon stats
    void Start()
    {
        this.GetComponent<Animation>().enabled = true;
        this.GetComponent<SwordSwing>().enabled = true;
        this.GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipItem(IEquippable equipable) {

    }
}
