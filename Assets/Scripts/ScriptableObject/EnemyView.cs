using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public GameObject enemys;
    [SerializeField] private GameObject enemyPrefab;

    // スクリプタブルオブジェクトを取得
    public StageData stageData;

    // getter
    public GameObject EnemyPrefab => enemyPrefab;

    private void Start()
    {
        CroneEnemy();
        ShowScriptableStageData();
    }

    // 敵のクローンを作成
    public void CroneEnemy()
    {
        enemys = GameObject.Find("Enemys");
        enemyPrefab = Instantiate(EnemyPrefab, enemys.transform.position, Quaternion.identity);
        enemys.transform.parent = enemyPrefab.transform;
        
    }

    // ステージデータを表示する
    void ShowScriptableStageData()
    {
        Debug.Log
        (
            "name = " + stageData.EnemyName +
            "HP = " + stageData.HP +
            "Attack = " + stageData.Attack +
            "Defend = " + stageData.Defend +
            "Experience = " + stageData.Experience +
            "Gold = " + stageData.Gold
        );
    }
}
