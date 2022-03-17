using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MtScriptable/Create StageData")]
public class StageData : ScriptableObject
{
    // インスペクターから設定可能なデータ
    [Header("FieldData"), SerializeField] private float stageLength;
    [SerializeField] private string enemyName;
    [SerializeField] private int hp;
    [SerializeField] private int attack;
    [SerializeField] private int defend;
    [SerializeField] private int experience;
    [SerializeField] private int gold;

    // getter
    public string EnemyName => enemyName;
    public int HP => hp;
    public int Attack => attack;
    public int Defend => defend;
    public int Experience => experience;
    public int Gold => gold;

}
