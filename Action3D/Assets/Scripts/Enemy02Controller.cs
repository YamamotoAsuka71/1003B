using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10.0f;
    public float attackRange = 5.0f;
    public float moveSpeed = 2.0f;
    public GameObject shellPrefab;
    private int count;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            // �v���C���[�̕����Ɍ���������
            LookAtPlayer();

            if (distanceToPlayer > attackRange)
            {
                // �v���C���[�ɋ߂Â�
                MoveTowardsPlayer();           
            }
            else
            {
                // �v���C���[���U���͈͓��ɂ���ꍇ�͈ړ����~�߁A�U�����s��
                Attack();
            }
    }

    void OnTriggerStay(Collider col)
    {
        Attack();
    }

    void LookAtPlayer()
    {
        // �v���C���[�̕���������
        transform.LookAt(player);
    }

    void MoveTowardsPlayer()
    {
        // �v���C���[�Ɍ������Ĉړ�����
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        // �U�����s��
        count += 1;

        // �i�|�C���g�j
        // �U�O�t���[�����ƂɖC�e�𔭎˂���
        if (count % 60 == 0)
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // �e���͎��R�ɐݒ�
            shellRb.AddForce(transform.forward * 500);
            // �T�b��ɖC�e��j�󂷂�
            Destroy(shell, 5.0f);
        }
    }
}