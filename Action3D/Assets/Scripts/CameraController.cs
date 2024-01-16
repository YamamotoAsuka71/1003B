using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float MinAngleX = -25.0f;
    [SerializeField] float MaxAngleX = 25.0f;
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.position = player.transform.position;

        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(mx) > 0.001f)
        {
            transform.RotateAround(player.transform.position, Vector3.up, mx);
        }

        if (gameObject.tag != "CameraPos")
        {
            if (Mathf.Abs(my) > 0.001f)
            {
                transform.RotateAround(player.transform.position, -transform.right, my);
            }
            float currentXAngle = transform.eulerAngles.x;
            // ���݂̊p�x��180���傫���ꍇ
            if (currentXAngle > 180)
            {
                // �f�t�H���g�ł͊p�x��0�`360�Ȃ̂�-180�`180�ƂȂ�悤�ɕ␳
                currentXAngle = currentXAngle - 360;
            }
            if (currentXAngle > MaxAngleX)
            {
                transform.eulerAngles = new Vector3(MaxAngleX, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            if (currentXAngle < MinAngleX)
            {
                transform.eulerAngles = new Vector3(360.0f + MinAngleX, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
    }
}