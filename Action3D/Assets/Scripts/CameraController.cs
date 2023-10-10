using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;   //  �v���C���[�i�[�p
    float mouse_move_x; //  �J�����̈ړ���

    void Start()
    {

    }

    void Update()
    {
        //  �J�����̑���֐�
        CameraMove();
    }

    void CameraMove()
    {
        Vector3 mousePosition = Input.mousePosition;    //  �}�E�X�J�[�\���̃X�N���[�����W���擾
        //  �X�N���[�����W��X���W��500��菬�����ʒu�ɃJ�[�\���������
        if (mousePosition.x < 500)
        {
            mouse_move_x = -100;    //  �J�����̈ړ��ʂ�-100�ɐݒ�
            transform.RotateAround(player.transform.position, Vector3.up, mouse_move_x * Time.deltaTime);   //  �v���C���[�����ɍ���]��]������
        }
        //  �X�N���[�����W��X���W��1200���傫���ʒu�ɃJ�[�\���������
        else if (mousePosition.x > 1200)
        {
            mouse_move_x = 100; //  �J�����̈ړ��ʂ�100�ɐݒ�
            transform.RotateAround(player.transform.position, Vector3.up, mouse_move_x * Time.deltaTime);   //  �v���C���[�����ɉE��]������
        }
        //  �X�N���[�����W�̐^�񒆂�ւ�ɃJ�[�\���������
        else
        {
            mouse_move_x = 0;   //  �J�����̈ړ��ʂ����Z�b�g����
        }
    }
}
