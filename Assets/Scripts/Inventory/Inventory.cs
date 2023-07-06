using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY ALMAR

public class Inventory {
    [SerializeField] private List<ItemInstance> items = new();
    [SerializeField] private int maxItems = 10;
    [SerializeField] private int currentItemCount;

    public int CurrentItemCount {
        get { return currentItemCount; }
    }

    public List<ItemInstance> Items { get => items; set => items = value; }



    public bool AddItem(ItemInstance itemToAdd) {
        // Finds an empty slot if there is one
        for (int i = 0; i < items.Count; i++) {
            if (items[i] == null) {
                if (items.Count >= maxItems)
                    return false;

                items[i] = itemToAdd;
                currentItemCount += items.Count;
                return true;
            }
        }
        // Adds a new item if the inventory has space
        if (items.Count < maxItems) {
            items.Add(itemToAdd);
            currentItemCount += items.Count;
            return true;
        }
        Debug.Log("No space in the inventory");
        return false;
    }

    public void RemoveItem(ItemInstance itemToRemove) {
        items.Remove(itemToRemove);
    }
}
