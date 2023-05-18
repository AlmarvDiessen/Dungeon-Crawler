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
        get { return itemData.canInteract; }
    }

    void Start() {
        if (itemData != null) {
            LoadItem(itemData);
        }

    }
    private void LoadItem(ItemData itemData) {
        GameObject visual = Instantiate(itemData.itemModel);
        visual.transform.SetParent(this.transform);
        visual.transform.position = (this.transform.position);
        visual.transform.rotation = Quaternion.identity;
        CanInteract(itemData.canInteract);
    }

    public void Interact(GameObject player) {
        if (!allowInteract)
            return;

        inventoryManager = player.GetComponentInChildren<InventoryManager>();
        inventoryManager.inventory.AddItem(item);
        Destroy(gameObject);
    }

    public bool CanInteract(bool value) {
        return value;
    }

}
