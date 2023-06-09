using Assets.Scripts.Interfaces;
using UnityEngine;

// SCRIPT BY ALMAR & PAULO

public class Weapon : MonoBehaviour, IEquippable
{
    [SerializeField] private AnimationClip clip;
    [SerializeField] private int damageValue;

    public AnimationClip Clip { get => clip; set => clip = value; }
    public int DamageValue { get => damageValue; set => damageValue = value; }

    // add weapon stats
    public void Start()
    {
        //this.GetComponent<Animation>().enabled = true;
        //this.GetComponent<SwordSwing>().enabled = true;
        //Animator = parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    public virtual void Attack()
    {
    }

    public void EquipItem(IEquippable equipable) {

    }
}
