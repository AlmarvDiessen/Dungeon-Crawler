using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    private void Start()
    {
        base.Start();
    }

    private void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Playing Spear Anim");
        //    Animator.SetBool("SwordSwing", true);
        //    Animator.SetBool("SpearStab", false);
        //}
        //Animator.SetBool("SpearStab", false);
    }
}
