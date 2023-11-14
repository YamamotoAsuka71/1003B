using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    const float QUICK_TIME = 0.25f; //  クイックダッシュの判定時間
    const float RECOVERY_TIME = 1.0f;   //  スタミナ回復開始時間
    float quickTimer = 0.0f;    //  ダッシュ時間計測用
    bool quickFlag = false;     //  クイックダッシュからダッシュへの切り替えフラグ
    float timer = 0.0f; //  ダッシュボタン即離しの状態でクイックダッシュの時間を判定するタイマー
    bool dashFlag = false;  //  ダッシュ判定用フラグ
    float recoveryTimer = 0.0f; //  スタミナ回復開始時間計測用
    //最大HPと現在のHP。
    int maxStamina = 10000; //  スタミナゲージの最大値
    int currentStamina;    //  現在のスタミナ
    //Slider
    Slider slider;
    private bool notDecrease = false;   //  スタミナが減少しているかを判別するフラグ
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
        //スタミナを最大のスタミナと同じ値に。
        currentStamina = maxStamina;
    }

    private void Update()
    {
        DashMove();
    }
    void DashMove()
    {
        //  ダッシュボタンを押している間はスタミナを減少させ、スタミナが減らなくなってしまったら最低値を維持させる
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
                currentStamina = currentStamina - 5;
                slider.value = (float)currentStamina / (float)maxStamina;
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
                    currentStamina = currentStamina + 10;
                    slider.value = (float)currentStamina / (float)maxStamina;
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
                if (currentStamina < maxStamina)
                {
                    currentStamina = currentStamina + 10;
                    slider.value = (float)currentStamina / (float)maxStamina;
                }
                if (currentStamina >= maxStamina)
                {
                    currentStamina = maxStamina;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            quickTimer = 0.0f;
        }
        if (quickFlag == true)
        {
            currentStamina = currentStamina - 10;
            slider.value = (float)currentStamina / (float)maxStamina;
            timer += Time.deltaTime;
        }
        if (timer > QUICK_TIME)
        {
            quickFlag = false;
            timer = 0.0f;
        }
        if (dashFlag == true)
        {
            currentStamina = currentStamina - 1;
            slider.value = (float)currentStamina / (float)maxStamina;
        }
    }
}
