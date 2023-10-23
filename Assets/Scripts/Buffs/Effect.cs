using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Effect : ScriptableObject {
    [SerializeField] ScriptableObject m_Effect;
    List<IEffects> effects = new List<IEffects>();
}
