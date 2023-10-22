using UnityEngine;

// SCRIPT BY ALMAR

public class AnimationComponent : MonoBehaviour {
    private static readonly int idle = Animator.StringToHash("WeaponIdle");

    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip clip;

    private float lockAnimation;
    private float attackAnimationTime = 0.5f;

    private int attack;
    private int currentState;
    public AnimationClip Clip { get => clip; set => clip = value; }

    void Start() {


    }
    void Update() {

        var state = GetState();

        if (state == currentState) return;
        animator.CrossFade(state, 0, 0);
        currentState = state;
    }

    //public int GetHash(string input) {
    //    using (HashAlgorithm algo = SHA256.Create())
    //        return BitConverter.ToInt32(algo.ComputeHash(Encoding.UTF8.GetBytes(input)));
    //}

    private int GetState() {
        if (Time.time < lockAnimation) return currentState;


        if (clip != null && Input.GetMouseButtonDown(0)) {
            Debug.Log(clip.name);
            attack = Animator.StringToHash(clip.name);
            return LockState(attack, attackAnimationTime);

        }


        return idle;

        int LockState(int s, float t) {
            lockAnimation = Time.time + t;
            return s;
        }
    }
}
