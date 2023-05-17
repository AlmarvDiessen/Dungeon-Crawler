using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField] private List<IInteractable> itemsInRange = new List<IInteractable>();

    void Update() {

    
    }

    private void OnTriggerEnter(Collider other) {
        var interactable = other.GetComponent<IInteractable>();

        if (interactable != null && interactable.CanInteract()) {
            itemsInRange.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other) {
        var interactable = other.GetComponent<IInteractable>();

        if (itemsInRange.Contains(interactable)) {
            itemsInRange.Remove(interactable);
        }
    }
}
