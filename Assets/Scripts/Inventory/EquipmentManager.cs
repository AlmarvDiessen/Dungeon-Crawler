using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {
    [SerializeField] private Weapon equippedWeapon;
    [SerializeField] private GameObject equipped;
    [SerializeField] private Transform hand = null;

    [SerializeField] private List<Weapon> weaponsOnGround = new List<Weapon>();

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //check if item is equippable
        if (Input.GetButtonDown("Interact")) {

            EquipWeapon();
        }
    }

    private void EquipWeapon() {

        if (weaponsOnGround.Count != 0) {

            Weapon weaponOnGround = weaponsOnGround[0];
            GameObject weaponInfo = weaponOnGround.gameObject;
            if (equipped != null)
                UnequipWeapon();

            Destroy(weaponOnGround.gameObject);
            weaponsOnGround.Remove(weaponOnGround);

            equipped = Instantiate(weaponInfo.gameObject, hand);
            equipped.GetComponent<Weapon>().enabled = true;
            equipped.transform.localPosition = Vector3.zero;
            equipped.transform.localRotation = Quaternion.identity;
            equippedWeapon = equipped.GetComponent<Weapon>();
        }
    }

    private void UnequipWeapon() {

        if (equipped != null) {
            Destroy(equipped);
            GameObject dropEquipped = Instantiate(equippedWeapon.gameObject, transform.position, Quaternion.identity);
            dropEquipped.GetComponentInChildren<RotateUiComponent>().enabled = true;
            dropEquipped.GetComponent<RotateObjectComponent>().enabled = true;
            dropEquipped.GetComponent<RotateObjectComponent>().RotateSpeed = 100f;
            equipped = null;
            equippedWeapon = null;
        }
    }

    private void OnTriggerEnter(Collider other) {
        Weapon equippable = other.GetComponent<IEquippable>() as Weapon;
        if (equippable != null) {
            weaponsOnGround.Add(equippable);
        }
    }

    private void OnTriggerExit(Collider other) {
        Weapon equippable = other.GetComponent<IEquippable>() as Weapon;
        if (equippable != null) {
            weaponsOnGround.Remove(equippable);
        }
    }
}