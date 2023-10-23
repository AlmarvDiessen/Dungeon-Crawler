using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public Health health;

    void Start()
    {
        health = gameObject.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Kill();
    }

    void Kill()
    {
        if (health.getHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
