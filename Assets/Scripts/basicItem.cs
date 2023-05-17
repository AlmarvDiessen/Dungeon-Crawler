using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicItem : MonoBehaviour, IInteractable {
    // Start is called before the first frame update


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

    public void Interact() {
        throw new System.NotImplementedException();
    }

}
