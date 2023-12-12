using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float attackRange = 5f;
    public float moveSpeed = 2f;
    public GameObject shellPrefab;
    private int count;


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

       
        
            // プレイヤーの方向に向き続ける
            LookAtPlayer();

            if (distanceToPlayer > attackRange)
            {
                // プレイヤーに近づく
                MoveTowardsPlayer();
            }
            else
            {
                // プレイヤーが攻撃範囲内にいる場合は移動を止め、攻撃を行う
                StopMoving();
                Attack();
            }
        
    }

    void LookAtPlayer()
    {
        // プレイヤーの方向を向く
        transform.LookAt(player);
    }

    void MoveTowardsPlayer()
    {
        // プレイヤーに向かって移動する
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void StopMoving()
    {
        // 移動を止める
        // ここに移動を止める処理を追加
    }

    void Attack()
    {
        // 攻撃を行う
        count += 1;

        // （ポイント）
        // ６０フレームごとに砲弾を発射する
        if (count % 60 == 0)
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // 弾速は自由に設定
            shellRb.AddForce(transform.forward * 500);
            // ５秒後に砲弾を破壊する
            Destroy(shell, 5.0f);
        }
    }
}