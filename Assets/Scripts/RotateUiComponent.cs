using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RotateUiComponent : MonoBehaviour {
    [SerializeField] private TextMeshPro ui;
    [SerializeField] private Camera cam;
    [SerializeField] private float detectDistance;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (cam != null) {
            float distance = Vector3.Distance(gameObject.transform.position, cam.transform.position);
            if (distance <= detectDistance) {
                ui.GetComponent<TextMeshPro>().enabled = true;
                RotateUI();
            }

            if (distance >= detectDistance)
                ui.GetComponent<TextMeshPro>().enabled = false;
        }
    }

    public void RotateUI() {
        if(cam == null) {
            
            
        }

        Vector3 direction = gameObject.transform.position - cam.transform.position;
        ui.transform.rotation = Quaternion.LookRotation(direction);
    }
}
