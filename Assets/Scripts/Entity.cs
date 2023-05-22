using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamagable
{
    private ScriptableObject data;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int pDamage) {

    }


    private void OnTriggerEnter(Collider other) {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable != null) {
          
        }
    }

    private void OnTriggerExit(Collider other) {
        
    }
}
