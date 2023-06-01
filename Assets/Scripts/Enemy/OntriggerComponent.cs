using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerComponent : MonoBehaviour {
    private GameObject? gameObject;
    public GameObject GetGameObject { get => gameObject; }

    private void OnTriggerEnter(Collider other) {
        var damageable = other.GetComponent<IDamagable>();
        if (damageable != null)
            gameObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other) {
        gameObject = null;
        Debug.Log("null");
    }
}
