using UnityEngine;

namespace LectureScripts.Attack
{
    public class MeleeAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private int _attackDamage;
        
        public void Attack()
        {
            Debug.Log("Perform MeleeAttack!");
            
            //Boxcast in front of the player
            
            //Check if all objects hit in boxcast have IDamageable interfaces on them
            
            //For each IDamagaable, reduce their health with _attackDamage
        }
    }
}