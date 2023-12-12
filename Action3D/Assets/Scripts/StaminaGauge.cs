using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    bool isDash = false;
    bool isRecovery = false;
    private bool isAttack = false;
    public bool GetIsAttack()
    {
        return isAttack;
    }

    float dashTimer = 0.0f;
    float attackTimer = 0.0f;
    const float ATTACK_TIME = 1.12f; 
    private int moveCount = 0;

    public int GetMoveCount()
    {
        return moveCount;
    }
    //最大HPと現在のHP。
    int maxStamina = 10000; //  スタミナゲージの最大値
    int currentStamina;    //  現在のスタミナ
    //Slider
    Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        //Sliderを最大にする。
        slider.value = 1;
        //スタミナを最大のスタミナと同じ値に。
        currentStamina = maxStamina;
    }

    private void Update()
    {
        DashMove();
    }
    void DashMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDash = false;
            isAttack = true;
            moveCount = 3;
        }
        if (isAttack == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                isDash = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                if (moveCount == 2)
                {
                    isDash = false;
                    dashTimer = 0.0f;
                }
            }
            if (Input.GetMouseButton(1) != true)
            {
                if (dashTimer >= 1.0f)
                {
                    isDash = false;
                    moveCount = 0;
                    dashTimer = 0.0f;
                }
            }
            else
            {
                isRecovery = false;
            }
            if (isDash)
            {
                dashTimer += Time.deltaTime;
                currentStamina -= 15;
                slider.value = (float)currentStamina / (float)maxStamina;
            }
            if (dashTimer < 1.0f)
            {
                moveCount = 1;
            }
            else if (dashTimer >= 1.0f)
            {
                moveCount = 2;
            }
            if (isRecovery)
            {
                currentStamina += 10;
                slider.value = (float)currentStamina / (float)maxStamina;
            }
            if (dashTimer <= 0.0f)
            {
                moveCount = 0;
                isRecovery = true;
            }
            if (slider.value <= 0.1f)
            {
                moveCount = 0;
            }
            if (currentStamina <= 0)
            {
                currentStamina = 0;
            }
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
        }
        if (isAttack)
        {
            attackTimer += Time.deltaTime;
        }
        if (attackTimer > ATTACK_TIME)
        {
            isAttack = false;
            moveCount = 0;
        }
        if (isAttack == false)
        {
            attackTimer = 0.0f;
        }
    }
}
