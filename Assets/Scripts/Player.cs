using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    [SerializeField] Entity entity;
    // Start is called before the first frame update
    void Start() {
         entity = GetComponent<Entity>();

    }

    // Update is called once per frame
    void Update() {

    }

}
