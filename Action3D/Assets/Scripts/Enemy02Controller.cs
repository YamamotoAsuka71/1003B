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
    public GameObject bulletPrefab;
    public AudioClip sound;
    private int count;
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // プレイヤーが検出範囲内にいる場合

            if (distanceToPlayer > attackRange)
            {
                // プレイヤーに近づく
                MoveTowardsPlayer();
                ShootBullet();

            }
            else
            {
                // プレイヤーが攻撃範囲内にいる場合は移動を止め、攻撃を行う
                StopMoving();
                ShootBullet();
            }
        }
        else
        {
            // プレイヤーが検出範囲外にいる場合は移動を再開
            ResumeMoving();
        }
    }

    private void MoveTowardsPlayer()
    {
        // プレイヤーに向かって移動
        transform.LookAt(player);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void StopMoving()
    {
        // 移動を止める
        // ここに移動を止める処理を追加
    }

    private void ResumeMoving()
    {
        // 移動を再開
        // ここに移動を再開する処理を追加
    }

   
        // 攻撃を行う
    void ShootBullet()
    {
        count += 1;

        // （ポイント）
        // 60フレームごとに砲弾を発射する
        if (count % 240 == 0)
        {
            GameObject shell = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // 弾速は自由に設定
            shellRb.AddForce(transform.forward * 500);

            // ５秒後に砲弾を破壊する
            Destroy(shell, 5.0f);
        }
    }
    
}