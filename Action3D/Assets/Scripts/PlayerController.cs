using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject staminaGauge;
    Animator animator = null;
    StaminaGauge stamina;
    const float MAX_SPEED = 2.5f;
    const float MIN_SPEED = 1.0f;
    const float QUICK_TIME = 1.0f;
    float speed = MIN_SPEED;
    float quickTimer = 0.0f;
    bool quickFlag = false;
    float timer = 0.0f;
    bool dashFlag = false;
    bool notDash = false;
    void Start()
    {
        animator = character.GetComponent<Animator>();
        stamina=staminaGauge.GetComponent<StaminaGauge>();
    }

    void Update()
    {
        if (speed >= MAX_SPEED)
        {
            animator.SetBool("isRun", true);
            animator.SetBool("isWalk", false);
            animator.SetBool("isIdle", false);

        }
        if (speed <= MIN_SPEED)
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isWalk", true);
            animator.SetBool("isIdle", false);
        }
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
                    animator.SetTrigger("isDash");
                    quickFlag = true;
                }

            }
            else
            {
                quickFlag = false;
                notDash = stamina.GetNotDecrease();
                if(notDash==false)
                {
                    speed = MAX_SPEED;
                }
                else
                {
                    speed = MIN_SPEED;
                }
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
            if (Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.D) != true && Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true)
            {
                animator.SetBool("isIdle", true);
                animator.SetBool("isRun", false);
                animator.SetBool("isWalk", false);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            quickTimer = 0.0f;
        }
        if (quickFlag == true)
        {
            notDash = stamina.GetNotDecrease();
            if (notDash == false)
            {
                transform.position += transform.forward * Time.deltaTime * MAX_SPEED;
            }
            else
            {
                transform.position += transform.forward * Time.deltaTime * MIN_SPEED;
            }
            timer += Time.deltaTime;
        }
        if (timer > QUICK_TIME)
        {
            quickFlag = false;
            timer = 0.0f;
        }
        if (dashFlag == true)
        {
            notDash = stamina.GetNotDecrease();
            if (notDash == false)
            {
                transform.position += transform.forward * Time.deltaTime * MAX_SPEED;
            }
            else
            {
                transform.position += transform.forward * Time.deltaTime * MIN_SPEED;
            }
        }
    }
}
