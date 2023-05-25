using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour {
    [SerializeField] private bool IsActive;
    [SerializeField] private Canvas canvas;


    private void Start() {
        canvas = GetComponentInChildren<Canvas>();
    }
    void Update() {
        if (Input.GetButtonDown("tab")) {
            Cursor.lockState = CursorLockMode.None;

            if (!IsActive) {
                canvas.GetComponentInChildren<Canvas>().enabled = true;
                IsActive = true;
                    }
            else {
                canvas.GetComponentInChildren<Canvas>().enabled = false;
                Cursor.lockState = CursorLockMode.Locked;       
                IsActive = false;
            }
        }
    }
}
