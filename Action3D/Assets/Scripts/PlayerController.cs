using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    GameObject child;   //  子のオブジェクトを格納用
    void Start()
    {
        child = transform.GetChild(0).gameObject; //  子のオブジェクトを取得
    }

    void Update()
    {
        //  プレイヤーの移動関数
        PlayerMove();
    }

    void PlayerMove()
    {
        //  Aが押されたら
        if (Input.GetKey(KeyCode.A))
        {
            //  子のオブジェクトから見て右に移動
            transform.position -= child.transform.right * Time.deltaTime;
        }
        //  Dが押されたら
        if (Input.GetKey(KeyCode.D))
        {
            //  子のオブジェクトから見て左に移動
            transform.position += child.transform.right * Time.deltaTime;
        }
        //  Wが押されたら
        if (Input.GetKey(KeyCode.W))
        {
            //  子のオブジェクトから見て奥に移動
            transform.position += child.transform.forward * Time.deltaTime;
        }
        //  Sが押されたら
        if (Input.GetKey(KeyCode.S))
        {
            //  子のオブジェクトから見て手前に移動
            transform.position -= child.transform.forward * Time.deltaTime;
        }
        //  左のシフトキーが押されたら
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //  子のオブジェクトから見て下に移動
            transform.position -= child.transform.up * Time.deltaTime;
        }
        //  スペースキーが押されたら
        if (Input.GetKey(KeyCode.Space))
        {
            //  子のオブジェクトから見て上に移動
            transform.position += child.transform.up * Time.deltaTime;
        }
    }
}
