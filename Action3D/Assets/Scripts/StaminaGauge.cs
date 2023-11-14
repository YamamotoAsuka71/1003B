using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    const float QUICK_TIME = 0.25f; //  �N�C�b�N�_�b�V���̔��莞��
    const float RECOVERY_TIME = 1.0f;   //  �X�^�~�i�񕜊J�n����
    float quickTimer = 0.0f;    //  �_�b�V�����Ԍv���p
    bool quickFlag = false;     //  �N�C�b�N�_�b�V������_�b�V���ւ̐؂�ւ��t���O
    float timer = 0.0f; //  �_�b�V���{�^���������̏�ԂŃN�C�b�N�_�b�V���̎��Ԃ𔻒肷��^�C�}�[
    bool dashFlag = false;  //  �_�b�V������p�t���O
    float recoveryTimer = 0.0f; //  �X�^�~�i�񕜊J�n���Ԍv���p
    //�ő�HP�ƌ��݂�HP�B
    int maxStamina = 10000; //  �X�^�~�i�Q�[�W�̍ő�l
    int currentStamina;    //  ���݂̃X�^�~�i
    //Slider
    Slider slider;
    private bool notDecrease = false;   //  �X�^�~�i���������Ă��邩�𔻕ʂ���t���O
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
        //Slider���ő�ɂ���B
        slider.value = 1;
        //�X�^�~�i���ő�̃X�^�~�i�Ɠ����l�ɁB
        currentStamina = maxStamina;
    }

    private void Update()
    {
        DashMove();
    }
    void DashMove()
    {
        //  �_�b�V���{�^���������Ă���Ԃ̓X�^�~�i�����������A�X�^�~�i������Ȃ��Ȃ��Ă��܂�����Œ�l���ێ�������
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
