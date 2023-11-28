using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy02Controller : MonoBehaviour
{
    [SerializeField] private GameObject Enemy02;
    [SerializeField] GameObject shellPrefab;
    private float interval;
    private float time = 0f;
    // ���g��Transform
    [SerializeField] private Transform _self;
    // �^�[�Q�b�g��Transform
    [SerializeField] private Transform _target;
    // �O���̊�ƂȂ郍�[�J����ԃx�N�g��
    [SerializeField] private Vector3 _forward = Vector3.forward;
    // �I�u�W�F�N�g�̈ړ����x���i�[����ϐ�
    public float moveSpeed;
    // �I�u�W�F�N�g����~����^�[�Q�b�g�I�u�W�F�N�g�Ƃ̋������i�[����ϐ�
    public float stopDistance;
    // �I�u�W�F�N�g���^�[�Q�b�g�Ɍ������Ĉړ����J�n���鋗�����i�[����ϐ�
    public float moveDistance;
    private int count;
    float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        interval = 5f;
    }

    private void Update()
    {
        enemyMove();
    }

    private void enemyMove()
    {
        // �ϐ� distance ���쐬���ăI�u�W�F�N�g�̈ʒu�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋������i�[
        float distance = Vector3.Distance(transform.position, _target.position);
        // �I�u�W�F�N�g�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋�������
        // �ϐ� distance�i�^�[�Q�b�g�I�u�W�F�N�g�ƃI�u�W�F�N�g�̋����j���ϐ� moveDistance �̒l��菬�������
        // ����ɕϐ� distance ���ϐ� stopDistance �̒l�����傫���ꍇ
        if (distance < moveDistance && distance > stopDistance)
        {
            //GetComponent<Animator>().SetFloat("Speed", 1.0f);
            // �ϐ� moveSpeed ����Z�������x�ŃI�u�W�F�N�g��O�����Ɉړ�����
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            // �^�[�Q�b�g�ւ̌����x�N�g���v�Z
            var dir = _target.position - _self.position;

            // �^�[�Q�b�g�̕����ւ̉�]
            var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
            // ��]�␳
            var offsetRotation = Quaternion.FromToRotation(_forward, Vector3.forward);

            // ��]�␳���^�[�Q�b�g�����ւ̉�]�̏��ɁA���g�̌����𑀍삷��
            _self.rotation = lookAtRotation * offsetRotation;
            count += 1;

            // 120�t���[�����ƂɖC�e�𔭎˂���
            if (count % 240 == 0)
            {
                GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();

                // �e���͎��R�ɐݒ�
                shellRb.AddForce(transform.forward * 300);

                // 4�b��ɖC�e��j�󂷂�
                Destroy(shell, 4.0f);
            }

        }

    }
}
