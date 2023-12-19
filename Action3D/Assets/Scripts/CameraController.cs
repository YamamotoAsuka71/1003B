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
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // マウスの移動量
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        // X方向に一定量移動していれば横回転
        //0.0000001fは滑らかさ
        if (Mathf.Abs(mouseInputX) > 0.0000001f)
        {
            mouseInputX = mouseInputX * 5;

            // 回転軸はワールド座標のY軸
            transform.RotateAround(targetObj.transform.position, Vector3.up, mouseInputX);

        }

        // Y方向に一定量移動していれば縦回転
        if (Mathf.Abs(mouseInputY) > 0.0000001f)
        {
            //高さの制限
            if ((height - mouseInputY) < -2 || (height - mouseInputY) > 4)
            {
                mouseInputY = 0;
            }
            height -= mouseInputY / 10;
        }
        // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
        transform.RotateAround(targetPos, transform.right, mouseInputY);
    }
}