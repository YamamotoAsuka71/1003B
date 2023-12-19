using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject targetObj;
    Vector3 targetPos;

    float height = 1.0f;

    void Start()
    {
        targetPos = targetObj.transform.position;
    }

    void Update()
    {
        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // �}�E�X�̈ړ���
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        // X�����Ɉ��ʈړ����Ă���Ή���]
        //0.0000001f�͊��炩��
        if (Mathf.Abs(mouseInputX) > 0.0000001f)
        {
            mouseInputX = mouseInputX * 5;

            // ��]���̓��[���h���W��Y��
            transform.RotateAround(targetObj.transform.position, Vector3.up, mouseInputX);

        }

        // Y�����Ɉ��ʈړ����Ă���Ώc��]
        if (Mathf.Abs(mouseInputY) > 0.0000001f)
        {
            //�����̐���
            if ((height - mouseInputY) < -2 || (height - mouseInputY) > 4)
            {
                mouseInputY = 0;
            }
            height -= mouseInputY / 10;
        }
        // �J�����̐����ړ��i���p�x�����Ȃ��A�K�v��������΃R�����g�A�E�g�j
        transform.RotateAround(targetPos, transform.right, mouseInputY);
    }
}