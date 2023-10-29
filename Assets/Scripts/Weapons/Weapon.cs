using Assets.Scripts.Interfaces;
using UnityEngine;

public class Weapon : MonoBehaviour, IEquippable
{
    [SerializeField] private AnimationClip clip;
    [SerializeField] private int damageValue;
    public AnimationClip Clip { get => clip; set => clip = value; }
    public int DamageValue { get => damageValue; set => damageValue = value; }

    public void Start()
    {
        //this.GetComponent<Animation>().enabled = true;
        //this.GetComponent<SwordSwing>().enabled = true;
        //Animator = parent.GetComponent<Animator>();
      
    }

    
    public void EquipItem(IEquippable equipable) {

    }
}
