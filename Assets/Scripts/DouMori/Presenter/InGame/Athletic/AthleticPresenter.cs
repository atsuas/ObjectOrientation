using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthleticPresenter : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform hammerPos;
    
    [SerializeField] private float angularVelocity;
    [SerializeField] private float angularAcceleration;
    [SerializeField] private float angularAccelerationValue;

    void Start()
    {
        // 現在の速度を取得
        GetCurrentVelocity();
    }

    void FixedUpdate()
    {
        // 振り子ハンマー
        HammerPendulum();
    }

    // 現在の速度を取得
    public Vector3 GetCurrentVelocity()
    {
        float distance = Vector2.Distance(pivot.position, hammerPos.position); // 距離
        Vector2 actualDistance = hammerPos.position - pivot.position; // 実際の距離
        Vector2 velocityDir = new Vector2(-actualDistance.y, actualDistance.x);
        velocityDir.Normalize(); // ベクトルの正規化(元のベクトルを変更する)
        return (distance * angularVelocity * velocityDir);
    }

    // 振り子ハンマー
    public void HammerPendulum()
    {
        angularVelocity += angularAcceleration * Time.deltaTime;
        hammerPos.RotateAround(pivot.position, Vector3.forward, angularVelocity);

        if (hammerPos.position.x > pivot.position.x) angularAcceleration = -angularAccelerationValue;  // ハンマーX角がピボットX角より大きかったら下げていく
        else angularAcceleration = angularAccelerationValue; // 違ったらその角度まで
    }
}
