using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject camera;
    void Start()
    {
        
    }

    void Update()
    {
        //  �v���C���[�̈ړ��֐�
        PlayerMove();
    }

    void PlayerMove()
    {
        //  A�������ꂽ��
        if (Input.GetKey(KeyCode.A))
        {
            //  �q�̃I�u�W�F�N�g���猩�ĉE�Ɉړ�
            transform.position -= camera.transform.right * Time.deltaTime;
        }
        //  D�������ꂽ��
        if (Input.GetKey(KeyCode.D))
        {
            //  �q�̃I�u�W�F�N�g���猩�č��Ɉړ�
            transform.position += camera.transform.right * Time.deltaTime;
        }
        //  W�������ꂽ��
        if (Input.GetKey(KeyCode.W))
        {
            //  �q�̃I�u�W�F�N�g���猩�ĉ��Ɉړ�
            transform.position += camera.transform.forward * Time.deltaTime;
        }
        //  S�������ꂽ��
        if (Input.GetKey(KeyCode.S))
        {
            //  �q�̃I�u�W�F�N�g���猩�Ď�O�Ɉړ�
            transform.position -= camera.transform.forward * Time.deltaTime;
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
}
