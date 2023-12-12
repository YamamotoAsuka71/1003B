using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject gauge;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject character;
    [SerializeField] GameObject collision;
    StaminaGauge stamina;
    CameraController controller;
    Animator animator = null;
    int moveCount = 0;
    float speed = 0.0f;
    const float NOT_SPEED = 0.0f;
    const float MIN_SPEED = 1.0f;
    const float MAX_SPEED = 2.5f;
    bool isMove = false;
    bool isAttack = false;

    void Start()
    {
        stamina=gauge.GetComponent<StaminaGauge>();
        controller=camera.GetComponent<CameraController>();
        animator = character.GetComponent<Animator>();
    }
    void Update()
    {
        moveCount = stamina.GetMoveCount();
        if (isMove)
        {
            switch (moveCount)
            {
                case 0:
                    speed = MIN_SPEED;
                    animator.SetInteger("Moving", 1);
                    break;
                case 1:
                    speed = MAX_SPEED;
                    animator.SetInteger("Moving", 2);
                    break;
                case 2:
                    speed = MAX_SPEED;
                    animator.SetInteger("Moving", 3);
                    break;
            }
        }
        else
        {
            animator.SetInteger("Moving", 0);
            speed = NOT_SPEED;
        }
        
        PlayerMove();
    }
    void PlayerMove()
    {
        isMove = false;
        isAttack = stamina.GetIsAttack();
        if (isAttack == true)
        {
            collision.SetActive(true);
            animator.SetBool("isAttack", true);
        }
        else
        {
            collision.SetActive(false);
            animator.SetBool("isAttack", false);
            //  A�������ꂽ��
            if (Input.GetKey(KeyCode.A))
            {
                //  �q�̃I�u�W�F�N�g���猩�ĉE�Ɉړ�
                transform.position -= camera.transform.right * Time.deltaTime * speed;
                isMove = true;
            }
            //  D�������ꂽ��
            if (Input.GetKey(KeyCode.D))
            {
                //  �q�̃I�u�W�F�N�g���猩�č��Ɉړ�
                transform.position += camera.transform.right * Time.deltaTime * speed;
                isMove = true;
            }
            //  W�������ꂽ��
            if (Input.GetKey(KeyCode.W))
            {
                //  �q�̃I�u�W�F�N�g���猩�ĉ��Ɉړ�
                transform.position += camera.transform.forward * Time.deltaTime * speed;
                isMove = true;
            }
            //  S�������ꂽ��
            if (Input.GetKey(KeyCode.S))
            {
                //  �q�̃I�u�W�F�N�g���猩�Ď�O�Ɉړ�
                transform.position -= camera.transform.forward * Time.deltaTime * speed;
                isMove = true;
            }
            //  ���̃V�t�g�L�[�������ꂽ��
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //  �q�̃I�u�W�F�N�g���猩�ĉ��Ɉړ�
                transform.position -= camera.transform.up * Time.deltaTime;
            }
            //  �X�y�[�X�L�[�������ꂽ��
            if (Input.GetKey(KeyCode.Space))
            {
                //  �q�̃I�u�W�F�N�g���猩�ď�Ɉړ�
                transform.position += camera.transform.up * Time.deltaTime;
            }

            if (Input.GetMouseButton(1))
            {
                if (moveCount == 1 || moveCount == 2)
                {
                    transform.position += gameObject.transform.forward * Time.deltaTime * speed;
                    isMove = true;
                }
            }
        }
    }
}