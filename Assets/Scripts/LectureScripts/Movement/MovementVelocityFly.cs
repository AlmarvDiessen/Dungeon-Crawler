using UnityEngine;

namespace LectureScripts.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementVelocityFly : MonoBehaviour, IMovement
    {
        //Fields
        [SerializeField] private float _movementSpeed;

        private Rigidbody _rigidbody;
        
        //Properties
        public float MovementSpeed => _movementSpeed;

        public void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.useGravity = false;
        }
        
        //Functions
        public void Move(Vector3 pDirection)
        {
            _rigidbody.velocity = pDirection * _movementSpeed;
        }
    }
}