using UnityEngine;

namespace LectureScripts.Movement
{
    public class MovementTranslate : MonoBehaviour, IMovement
    {
        //Fields
        [SerializeField] private float _movementSpeed;

        //Properties
        public float MovementSpeed => _movementSpeed;

        //Functions
        public void Move(Vector3 pDirection)
        {
            transform.Translate(pDirection * (_movementSpeed * Time.deltaTime));
        }
    }
}