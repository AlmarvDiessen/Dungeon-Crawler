using UnityEngine;

namespace LectureScripts
{
    public class Billboard : MonoBehaviour
    {
        //Fields
        private Camera _mainCamera;

        //Properties
        public Camera MainCam
        {
            get => _mainCamera;
            set => _mainCamera = value;
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            Debug.Assert(_mainCamera != null);
        }

        private void Update()
        {
            //transform.LookAt(_mainCamera.transform.position, Vector3.up);

            Vector3 lookDirection = transform.position - _mainCamera.transform.position;
            transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
    }
}