using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject camera;
    const float MAX_SPEED = 2.5f;
    const float MIN_SPEED = 1.0f;
    const float QUICK_TIME = 0.25f;
    float speed = MIN_SPEED;
    float quickTimer = 0.0f;
    bool quickFlag = false;
    float timer = 0.0f;
    bool dashFlag = false;
    void Start()
    {
        
    }

    void Update()
    {
        //  �v���C���[�̈ړ��֐�
        PlayerMove();
        DashMove();
    }

    void PlayerMove()
    {
        //  A�������ꂽ��
        if (Input.GetKey(KeyCode.A))
        {
            //  �q�̃I�u�W�F�N�g���猩�ĉE�Ɉړ�
            transform.position -= camera.transform.right * Time.deltaTime * speed;
        }
        //  D�������ꂽ��
        if (Input.GetKey(KeyCode.D))
        {
            //  �q�̃I�u�W�F�N�g���猩�č��Ɉړ�
            transform.position += camera.transform.right * Time.deltaTime * speed;
        }
        //  W�������ꂽ��
        if (Input.GetKey(KeyCode.W))
        {
            //  �q�̃I�u�W�F�N�g���猩�ĉ��Ɉړ�
            transform.position += camera.transform.forward * Time.deltaTime * speed;
        }
        //  S�������ꂽ��
        if (Input.GetKey(KeyCode.S))
        {
            //  �q�̃I�u�W�F�N�g���猩�Ď�O�Ɉړ�
            transform.position -= camera.transform.forward * Time.deltaTime * speed;
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
    }
    void DashMove()
    {
        if (Input.GetMouseButton(1))
        {
            quickTimer += Time.deltaTime;
            if (quickTimer < QUICK_TIME)
            {
                if (quickFlag == false)
                {
                    quickFlag = true;
                }

            }
            else
            {
                quickFlag = false;
                speed = MAX_SPEED;
            }
            if (quickFlag == false && Input.GetMouseButton(1))
            {
                dashFlag = true;
            }
            else if (quickFlag == false && Input.anyKey)
            {
                dashFlag = false;
            }
        }
        else
        {
            dashFlag = false;
            speed = MIN_SPEED;
        }
        if (Input.GetMouseButtonDown(1))
        {
            quickTimer = 0.0f;
        }
        if (quickFlag == true)
        {
            transform.position += transform.forward * Time.deltaTime * MAX_SPEED;
            timer += Time.deltaTime;
        }
        if (timer > QUICK_TIME)
        {
            quickFlag = false;
            timer = 0.0f;
        }
        if (dashFlag == true)
        {
            transform.position += transform.forward * Time.deltaTime * MAX_SPEED;
        }
    }
}
