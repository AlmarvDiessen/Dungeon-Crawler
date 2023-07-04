using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy {
    public class EnemyStateBase {

        private EnemyClass enemyRef;

        public EnemyStateBase(EnemyClass enemyRef) {
            this.enemyRef = enemyRef;
        }
    }
}
