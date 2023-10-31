using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    const float QUICK_TIME = 0.25f;
    const float RECOVERY_TIME = 1.0f;
    float quickTimer = 0.0f;
    bool quickFlag = false;
    bool quickCheck = false;
    float timer = 0.0f;
    float staminaTimer = 0.0f;
    bool dashFlag = false;
    float recoveryTimer = 0.0f;
    //最大HPと現在のHP。
    int maxStamina = 10000;
    int stamina;
    //Slider
    Slider slider;
    private bool notDecrease = false;
    public bool GetNotDecrease()
    {
        return notDecrease;
    }
    public void SetNotDecrease(bool Not)
    {
        notDecrease = Not;
    }

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        //Sliderを最大にする。
        slider.value = 1;
        //HPを最大HPと同じ値に。
        stamina = maxStamina;
    }

    private void Update()
    {
        DashMove();
    }
    void DashMove()
    {
        if (Input.GetMouseButton(1))
        {
            if (notDecrease == false)
            {
                recoveryTimer = 0.0f;
            }
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
                stamina = stamina - 5;
                slider.value = (float)stamina / (float)maxStamina;
            }
            if (quickFlag == false && Input.GetMouseButton(1))
            {
                dashFlag = true;
            }
            else if (quickFlag == false && Input.anyKey)
            {
                dashFlag = false;
            }
            if (slider.value <= 0.0f)
            {
                recoveryTimer += Time.deltaTime;
                notDecrease = true;
            }
            if (notDecrease == true)
            {
                if (recoveryTimer > RECOVERY_TIME)
                {
                    stamina = stamina + 10;
                    slider.value = (float)stamina / (float)maxStamina;
                }
            }
            if (slider.value >= 1.0f)
            {
                notDecrease = false;
                recoveryTimer = 0.0f;
            }
        }
        else
        {
            notDecrease = false;
            dashFlag = false;
            recoveryTimer += Time.deltaTime;
            if (recoveryTimer > RECOVERY_TIME && notDecrease == false)
            {
                if (stamina < maxStamina)
                {
                    stamina = stamina + 10;
                    slider.value = (float)stamina / (float)maxStamina;
                }
                if (stamina >= maxStamina)
                {
                    stamina = maxStamina;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            quickTimer = 0.0f;
        }
        if (quickFlag == true)
        {
            stamina = stamina - 10;
            slider.value = (float)stamina / (float)maxStamina;
            timer += Time.deltaTime;
        }
        if (timer > QUICK_TIME)
        {
            quickFlag = false;
            timer = 0.0f;
        }
        if (dashFlag == true)
        {
            stamina = stamina - 1;
            slider.value = (float)stamina / (float)maxStamina;
        }
    }
}
