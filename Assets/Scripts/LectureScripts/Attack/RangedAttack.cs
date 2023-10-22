using UnityEngine;

namespace LectureScripts.Attack
{
    public class RangedAttack : MonoBehaviour, IAttack
    {
        //Projectile _projectilePrefab
        //float _fireSpeed;
        
        public void Attack()
        {
            Debug.Log("Perform RangedAttack!");
            //Create a copy of _projectilePrefab
            
            //Calculate projectile velocity based on direction and _fireSpeed
            
            //Add calculated velocity to new projectile
        }
        
        
        /* The projectile will check for collision check against IDamageable component(s)
         * This way you can use the same RangedAttack for every object which fires projectile in this way
         * 
         * 
         * 
         */
    }
}