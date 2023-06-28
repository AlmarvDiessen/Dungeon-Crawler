using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{

    [SerializeField] private Animation animation;

    [SerializeField] private AnimationClip clip;

    public AnimationClip Clip { get => clip; set => clip = value; }
    public Animation Animation { get => animation; set => animation = value; }

    void Start()
    {
 
    }
    void Update()
    {
        animation.clip = clip;
        if (Input.GetMouseButtonDown(0))
        {
            animation.Play();
        }
    }
}
