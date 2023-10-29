using UnityEngine;

namespace LectureScripts.Constructor
{
    public class ConstructorComponent : MonoBehaviour
    {
        private float _field1 = 1.0f;
        private int _field2 = 255;
        private Vector3 _field3 = new Vector3(1,2,3);
        
        public void Initialize(float pParameter1, int pParameter2, Vector3 pParameter3)
        {
            _field1 = pParameter1;
            _field2 = pParameter2;
            _field3 = pParameter3;
        }
    }
}