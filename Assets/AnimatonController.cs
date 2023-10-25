using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatonController : MonoBehaviour {
    private Animator animator;
    [SerializeField] private EnemyStateMachine esm;
    [SerializeField] private EnemyClass enemy;
    [SerializeField] private int currentState;
    [SerializeField] private int state;
    private float lockAnimation;
    private float attackAnimationTime = 1.1f;
    private bool attackingRight = true;
    public bool isHit = false;


    private static readonly int idle = Animator.StringToHash("Idle");
    private static readonly int roar = Animator.StringToHash("Roar");
    private static readonly int rollForward = Animator.StringToHash("RollForward");
    private static readonly int rollTodle = Animator.StringToHash("RollTolde");
    private static readonly int crawlForward = Animator.StringToHash("CrawlForward");
    private static readonly int rightAttack = Animator.StringToHash("RightClawAttackForward");
    private static readonly int leftAttack = Animator.StringToHash("LeftClawAttackForward");
    private static readonly int doubleAttack = Animator.StringToHash("DoubleClawsAttack");
    private static readonly int getHit = Animator.StringToHash("GetHitFront");
    private static readonly int death = Animator.StringToHash("Death");
    private static readonly int jumpAttack = Animator.StringToHash("JumpDoubleClawsAttack");


    private void Start() {
        animator = GetComponent<Animator>();
        enemy = GetComponentInParent<EnemyClass>();
        enemy.Health.onHealthChange += OnHealthChange;
    }
    // Update is called once per frame
    void Update() {
        state = GetState();

        if (state == currentState) return;
        animator.CrossFade(state, 0.3f, 0);
        currentState = state;
    }

    private int GetState() {
        if (Time.time < lockAnimation) return currentState;
        Vector3 currentVelocity = esm.Rb.velocity;

        if (isHit) {
            isHit = false;
            return LockState(getHit, 0.9f);
        }

        if (enemy.Health.getHealth <= 0)
            return LockState(death, 2.2f);

        if (currentVelocity.magnitude > 10) {
            return LockState(jumpAttack, attackAnimationTime - 0.25f);
        }

        if (esm.CurrentState.inAttackRange) {
            int currentAttack = attackingRight ? rightAttack : leftAttack;
            enemy.EnemyAttack.Attack();
            attackingRight = !attackingRight;
            // Toggle the attack direction for the next invocation
            //if (esm.CurrentState.Attacked) return esm.CurrentState.Attacked ? (currentState == rightAttack ? leftAttack : rightAttack) : currentState;

            return LockState(currentAttack, attackAnimationTime);
        }

        return crawlForward;

        int LockState(int s, float t) {
            lockAnimation = Time.time + t;
            return s;
        }

    }

    private void OnHealthChange(int currentHealth, int maxHealth) {
        isHit = true;
    }

    private void OnDestroy() {
        if (enemy.Health != null)
            enemy.Health.onHealthChange -= OnHealthChange;

    }

}