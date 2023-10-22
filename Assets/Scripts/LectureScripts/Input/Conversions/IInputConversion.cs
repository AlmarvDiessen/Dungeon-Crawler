using UnityEngine;

namespace LectureScripts.Input.Conversions
{
    public interface IInputConversion
    {
        Vector3 Convert(Vector2 pInput);
    }
}
