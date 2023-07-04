using Assets.Scripts;
using UnityEngine;

[CreateAssetMenu]
public class healingEffect : Effect {
    [SerializeField] private string description;
    [SerializeField] private int minhealAmount;
    [SerializeField] private int maxhealAmount;
    [SerializeField] private int healAmount;
}

