using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY ALMAR

public class ItemController : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ItemInstance item;
    public ItemData ItemData {
        get { return itemData; }
    }

    public bool allowInteract {
        get { return itemData.CanInteract; }
    }

    void Start() {
        if (itemData != null) {
            LoadItem(itemData);
        }
    }
    private void LoadItem(ItemData itemData) {
        GameObject visual = Instantiate(itemData.ItemModel);
        visual.transform.SetParent(this.transform);
        visual.transform.position = (this.transform.position);
        visual.transform.rotation = Quaternion.identity;
    }

    public void Interact(GameObject player) {
        //can the item be interacted with?
        if (!allowInteract)
            return;
        item = new ItemInstance(itemData);

        inventoryManager = player.GetComponentInChildren<InventoryManager>();
        inventoryManager.Inventory.AddItem(item);
        Destroy(gameObject);
    }
}
