using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// SCRIPT BY ALMAR

public class RotateUiComponent : MonoBehaviour {
    [SerializeField] private TextMeshPro ui;
    [SerializeField] private Camera cam;
    [SerializeField] private float detectDistance;
    [SerializeField] private float grabDistance;

    void Start() {
        ui = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update() {
        if (cam != null) {
            float distance = Vector3.Distance(gameObject.transform.position, cam.transform.position);
            if (distance <= detectDistance) {
                ui.enabled = true;
                RotateUI();
            }

            if (distance >= detectDistance)
                ui.enabled = false;


            if (distance <= grabDistance)
                ui.color = Color.green;
            else
                ui.color = Color.white;
        }
    }

    public void RotateUI() {
        if (cam == null)
            return;

        Vector3 direction = gameObject.transform.position - cam.transform.position;
        ui.transform.rotation = Quaternion.LookRotation(direction);
        
    }
}
