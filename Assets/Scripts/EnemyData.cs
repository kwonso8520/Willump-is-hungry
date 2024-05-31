using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/Enemy Data", order = int.MaxValue)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private string enemyType;
    public string EnemyType { get { return enemyType; } }

    [SerializeField]
    private int level;
    public int Level { get { return level; } }

    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
    [SerializeField]
    private float exp;
    public float Exp { get { return exp; } }
    [SerializeField]
    private int scroe;
    public int Score { get { return scroe; } }
}