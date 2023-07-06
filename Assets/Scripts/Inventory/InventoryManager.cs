using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY ALMAR

public class InventoryManager : MonoBehaviour {
    public Inventory inventory = new Inventory();
    public ItemInstance item;
    public Inventory Inventory { get => inventory; set => inventory = value; }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnItemUse() {
        Debug.Log("used");
        item = GetComponent<ItemInstance>();
        
    }

    public void OnItemHover() {
    }

    public void OnItemExit() {
    }

}
