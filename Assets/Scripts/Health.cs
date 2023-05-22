using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    private void Update()
    {
        OnDestroy();
    }

    private void OnDestroy()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetHealth(int value) {
        health = value;
    }
}
