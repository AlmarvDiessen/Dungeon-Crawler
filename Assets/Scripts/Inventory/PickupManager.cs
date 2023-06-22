using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour {

    [SerializeField] private List<IInteractable> itemsInRange = new List<IInteractable>();
    [SerializeField] ItemController ItemController;
    public Inventory inventory = new Inventory();
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] private int itemCount;


    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject InventoryUI;

    private void Awake() {
        inventoryManager = GetComponent<InventoryManager>();
    }
    void Update() {
        if (Input.GetButtonDown("Interact") && itemsInRange.Count > 0) {
            var interactable = itemsInRange[0];
            if (ItemController != null) {
                ItemController.Interact(gameObject);
                itemCount = inventoryManager.Inventory.CurrentItemCount;
                itemsInRange.Remove(interactable);
            }
            UpdateInventory();
        }
    }

    private void UpdateInventory() {
        ItemInstance item = inventoryManager.Inventory.Items.LastOrDefault();
        GameObject child;
        child = Instantiate(itemPrefab, InventoryUI.transform);
        child.AddComponent<ItemInstance>();
        ItemInstance currentItem = child.GetComponent<ItemInstance>();
        currentItem.ItemData = item.ItemData;
        Image[] itemImage = child.GetComponentsInChildren<Image>();
        itemImage.Last().sprite = item.ItemData.Icon;

    }


    /// <summary>
    /// getting the component of Interface IInteractable when colliding with a ontrigger.
    /// making sure that iteractable is not null and can be interacted with.
    /// to then add it to the list of items in range of the player to be picked up.
    /// </summary>
    /// <param name="other"></param>

    private void OnTriggerEnter(Collider other) {
        var interactable = other.GetComponent<IInteractable>();
        ItemController = other.GetComponent<ItemController>();
        if (interactable != null) {
            itemsInRange.Add(interactable);
        }
    }
    /// <summary>
    /// when leaving the trigger just removing the ability to interact with it.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other) {
        var interactable = other.GetComponent<IInteractable>();
        if (itemsInRange.Contains(interactable)) {
            itemsInRange.Remove(interactable);
        }
    }
}
