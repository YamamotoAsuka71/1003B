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
            // �v���C���[�����o�͈͓��ɂ���ꍇ

            if (distanceToPlayer > attackRange)
            {
                // �v���C���[�ɋ߂Â�
                MoveTowardsPlayer();
                ShootBullet();

            }
            else
            {
                // �v���C���[���U���͈͓��ɂ���ꍇ�͈ړ����~�߁A�U�����s��
                StopMoving();
                ShootBullet();
            }
        }
        else
        {
            // �v���C���[�����o�͈͊O�ɂ���ꍇ�͈ړ����ĊJ
            ResumeMoving();
        }
    }

    private void MoveTowardsPlayer()
    {
        // �v���C���[�Ɍ������Ĉړ�
        transform.LookAt(player);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void StopMoving()
    {
        // �ړ����~�߂�
        // �����Ɉړ����~�߂鏈����ǉ�
    }

    private void ResumeMoving()
    {
        // �ړ����ĊJ
        // �����Ɉړ����ĊJ���鏈����ǉ�
    }

   
        // �U�����s��
    void ShootBullet()
    {
        count += 1;

        // �i�|�C���g�j
        // 60�t���[�����ƂɖC�e�𔭎˂���
        if (count % 240 == 0)
        {
            GameObject shell = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // �e���͎��R�ɐݒ�
            shellRb.AddForce(transform.forward * 500);

            // �T�b��ɖC�e��j�󂷂�
            Destroy(shell, 5.0f);
        }
    }
    
}