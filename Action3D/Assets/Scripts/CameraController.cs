using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] const float SENSITIVE = 1.0f;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject staminaGauge;
    StaminaGauge stamina;
    PlayerController playerController;
    int moveCount;
    float maxSpeed;
    float minSpeed;
    const float NOT_SPEED = 0.0f;
    float speed = 0.0f;
    bool isMove = false;
    bool isAttack = false;
    Transform player;

    float InputX;

    // Start is called before the first frame update
    void Start()
    {
        stamina = staminaGauge.GetComponent<StaminaGauge>();
        player = Player.transform;
        playerController=player.GetComponent<PlayerController>();
        minSpeed = playerController.GetMinSpeed();
        maxSpeed = minSpeed * 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveCount = stamina.GetMoveCount();
        if (isMove)
        {
            switch (moveCount)
            {
                case 0:
                    speed = minSpeed;
                    break;
                case 1:
                    speed = maxSpeed;
                    break;
                case 2:
                    speed = maxSpeed;
                    break;
            }
        }
        else
        {
            speed = NOT_SPEED;
        }
        Rotation();
        SetMovedirection(gameObject.transform);
    }

    void Rotation()
    {
        InputX = Input.GetAxis("Mouse X") * SENSITIVE;

        transform.RotateAround(player.position, Vector3.up, InputX);
    }

    public void SetMovedirection(Transform moveObject)
    {
        isAttack = stamina.GetIsAttack();
        Vector3 forward = gameObject.transform.forward;
        Vector3 back = -gameObject.transform.forward;
        Vector3 right = gameObject.transform.right;
        Vector3 left = -gameObject.transform.right;
        Vector3 up = gameObject.transform.up;
        Vector3 down = -gameObject.transform.up;
        if (isAttack == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveObject.position += forward * Time.deltaTime * speed;
                isMove = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveObject.position += back * Time.deltaTime * speed;
                isMove = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveObject.position += left * Time.deltaTime * speed;
                isMove = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveObject.position += right * Time.deltaTime * speed;
                isMove = true;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                moveObject.position += up * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveObject.position += down * Time.deltaTime;
            }
            if (Input.GetMouseButton(1))
            {
                if (moveCount == 1 || moveCount == 2)
                {
                    moveObject.position += player.transform.forward * Time.deltaTime * speed;
                    isMove = true;
                }
            }
        }  
    }
}