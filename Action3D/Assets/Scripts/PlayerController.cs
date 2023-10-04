using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    const float upperSpeed = 5.0f, downSpeed = -5.0f, zeroSpeed = 0.0f;
    float speedX, speedY, speedZ;
    void Start()
    {

    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        Transform myTransform = this.transform;
        // åªç›ÇÃç¿ïWÇ©ÇÁÇÃxyz Ç1Ç∏Ç¬â¡éZÇµÇƒà⁄ìÆ
        speedX = zeroSpeed;
        speedY = zeroSpeed;
        speedZ = zeroSpeed;
        if (Input.GetKey(KeyCode.A))
        {
            speedX = downSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speedX = upperSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            speedZ = upperSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speedZ = downSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedY = downSpeed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            speedY = upperSpeed;
        }
        myTransform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);
    }
}
