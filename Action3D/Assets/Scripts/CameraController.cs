using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;   //  プレイヤー格納用
    float mouse_move_x; //  カメラの移動量

    void Start()
    {

    }

    void Update()
    {
        //  カメラの操作関数
        CameraMove();
    }

    void CameraMove()
    {
        Vector3 mousePosition = Input.mousePosition;    //  マウスカーソルのスクリーン座標を取得
        //  スクリーン座標のX座標の500より小さい位置にカーソルがあれば
        if (mousePosition.x < 500)
        {
            mouse_move_x = -100;    //  カメラの移動量を-100に設定
            transform.RotateAround(player.transform.position, Vector3.up, mouse_move_x * Time.deltaTime);   //  プレイヤーを軸に左回転回転させる
        }
        //  スクリーン座標のX座標の1200より大きい位置にカーソルがあれば
        else if (mousePosition.x > 1200)
        {
            mouse_move_x = 100; //  カメラの移動量を100に設定
            transform.RotateAround(player.transform.position, Vector3.up, mouse_move_x * Time.deltaTime);   //  プレイヤーを軸に右回転させる
        }
        //  スクリーン座標の真ん中らへんにカーソルがあれば
        else
        {
            mouse_move_x = 0;   //  カメラの移動量をリセットする
        }
    }
}
