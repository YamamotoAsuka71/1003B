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
        //  プレイヤーの移動関数
        PlayerMove();
        DashMove();
    }

    void PlayerMove()
    {
        //  Aが押されたら
        if (Input.GetKey(KeyCode.A))
        {
            //  子のオブジェクトから見て右に移動
            transform.position -= camera.transform.right * Time.deltaTime * speed;
        }
        //  Dが押されたら
        if (Input.GetKey(KeyCode.D))
        {
            //  子のオブジェクトから見て左に移動
            transform.position += camera.transform.right * Time.deltaTime * speed;
        }
        //  Wが押されたら
        if (Input.GetKey(KeyCode.W))
        {
            //  子のオブジェクトから見て奥に移動
            transform.position += camera.transform.forward * Time.deltaTime * speed;
        }
        //  Sが押されたら
        if (Input.GetKey(KeyCode.S))
        {
            //  子のオブジェクトから見て手前に移動
            transform.position -= camera.transform.forward * Time.deltaTime * speed;
        }
        //  左のシフトキーが押されたら
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //  子のオブジェクトから見て下に移動
            transform.position -= camera.transform.up * Time.deltaTime;
        }
        //  スペースキーが押されたら
        if (Input.GetKey(KeyCode.Space))
        {
            //  子のオブジェクトから見て上に移動
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
