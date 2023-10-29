using UnityEngine;

namespace LectureScripts.Input.Conversions
{
    public class InputToDirection2D : MonoBehaviour, IInputConversion
    {
        public Vector3 Convert(Vector2 pInput)
        {
            return new Vector3(pInput.x, pInput.y, 0);
        }
    }
}