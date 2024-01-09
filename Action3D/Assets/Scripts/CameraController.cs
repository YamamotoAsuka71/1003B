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
                transform.RotateAround(player.transform.position, transform.right, my);
            }
            float currentXAngle = transform.eulerAngles.x;
            // 現在の角度が180より大きい場合
            if (currentXAngle > 180)
            {
                // デフォルトでは角度は0〜360なので-180〜180となるように補正
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