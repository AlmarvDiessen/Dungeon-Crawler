using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour {
    public Health health;
    public Entity entity;
    void Start() {
        health = gameObject.GetComponent<Health>();
        entity = gameObject.GetComponent<Entity>();
    }

    // Update is called once per frame  
    void Update() {
        Kill();
    }

    void Kill() {
        if (health.getHealth <= 0) {
            if (entity.DropItem != null) {
                Instantiate(entity.DropItem, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);

        }
    }
}
    