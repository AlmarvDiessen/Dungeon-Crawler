using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject {

    public string enemyName;
    public GameObject enemyModel;
    public int health = 20;
    public float speed = 2f;
    public float detectRange = 10f;
    public int damage = 1;

}
