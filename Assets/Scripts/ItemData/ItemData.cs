using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject {

    // Variables
    [SerializeField] private string itemName;
    [SerializeField] private GameObject itemModel;
    [SerializeField] private Sprite icon;
    [SerializeField] private int damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float defense;
    [SerializeField] private bool canInteract;

    // Properties
    public string ItemName { get => itemName; set => itemName = value; }
    public GameObject ItemModel { get => itemModel; set => itemModel = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public int Damage { get => damage; set => damage = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float Defense { get => defense; set => defense = value; }
    public bool CanInteract { get => canInteract; set => canInteract = value; }

}
