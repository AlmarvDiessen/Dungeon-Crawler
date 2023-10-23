using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseItem : MonoBehaviour, IInteractable {
    // Start is called before the first frame update
    [SerializeField] private string itemName;

    public bool CanInteract() {
        return true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Interact(GameObject player) {
        throw new System.NotImplementedException();
    }
}
