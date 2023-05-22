using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemInstance))]
public class ItemController : MonoBehaviour, IInteractable {
    // Start is called before the first frame update

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
        
        inventoryManager = player.GetComponentInChildren<InventoryManager>();
        inventoryManager.inventory.AddItem(item);
        Destroy(gameObject);
    }
}
