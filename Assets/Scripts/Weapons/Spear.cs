using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    //damage
    //range

    //reference naar givedamage 

    //void Start()
    //{
    //    //givedamage.setdamage(damage)
    //}

    private void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Playing Spear Anim");
        //    Animator.SetBool("SpearStab", true);
        //    Animator.SetBool("SwordSwing", false);
        //}
        //Animator.SetBool("SwordSwing", false);
    }
}
