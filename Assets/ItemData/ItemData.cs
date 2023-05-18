using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public GameObject itemModel;
    public Sprite icon;
    public int damage;
    public float attackSpeed;
    public float defense;
    public bool canInteract;
}
