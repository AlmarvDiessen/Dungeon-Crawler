using Assets.Scripts.Interfaces;
using UnityEngine;

// SCRIPT BY ALMAR & PAULO

public class Weapon : MonoBehaviour, IEquippable
{
    [SerializeField] private AnimationClip clip;
    [SerializeField] private int damageValue;

    public AnimationClip Clip { get => clip; set => clip = value; }
    public int DamageValue { get => damageValue; set => damageValue = value; }

    public void Start()
    {

    }

    public void Attack()
    {

    }

    public void EquipItem(IEquippable equipable) {

    }
}
