using LectureScripts.Health;
using UnityEngine;

namespace LectureScripts
{
    public class AttackOnCollision : MonoBehaviour
    {
        [SerializeField, Range(0,100)] private int _attackDamage = 50;
        
        private void OnCollisionEnter(Collision pCollision)
        {
            Debug.Log("Collision!");
            
            IHealth healthComponent = pCollision.gameObject.GetComponent<IHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(_attackDamage);
            }
            
            //pCollision.gameObject.GetComponent<IHealth>()?.TakeDamage(_attackDamage);
        }

    }
}
