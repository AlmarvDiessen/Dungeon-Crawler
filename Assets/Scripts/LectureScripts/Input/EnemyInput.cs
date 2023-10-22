using UnityEngine;

namespace LectureScripts.Input
{
    public class EnemyInput : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        public Vector3 GetTargetDirection()
        {
            Vector3 direction = _target.position - transform.position;

            return direction != Vector3.zero ? direction.normalized : Vector3.zero;
        }
    }
}
