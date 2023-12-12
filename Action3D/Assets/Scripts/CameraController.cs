using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] const float SENSITIVE = 1.0f;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject staminaGauge;
    StaminaGauge stamina;
    int moveCount;
    const float MAX_SPEED = 2.5f;
    const float MIN_SPEED = 1.0f;
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
                    speed = MIN_SPEED;
                    break;
                case 1:
                    speed = MAX_SPEED;
                    break;
                case 2:
                    speed = MAX_SPEED;
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