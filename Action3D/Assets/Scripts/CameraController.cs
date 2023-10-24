using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] const float SENSITIVE = 1.0f;
    [SerializeField] GameObject Player;
    const float MAX_SPEED = 2.5f;
    const float MIN_SPEED = 1.0f;
    const float QUICK_TIME = 0.25f;
    float speed = MIN_SPEED;
    float quickTimer = 0.0f;
    bool quickFlag = false;
    float timer = 0.0f;
    bool dashFlag = false;
    Transform player;

    float InputX;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        SetMovedirection(gameObject.transform);
        DashMove();
    }

    void Rotation()
    {
        InputX = Input.GetAxis("Mouse X") * SENSITIVE;

        transform.RotateAround(player.position, Vector3.up, InputX);
    }

    public void SetMovedirection(Transform moveObject)
    {
        Vector3 forward = gameObject.transform.forward;
        Vector3 back = -gameObject.transform.forward;
        Vector3 right = gameObject.transform.right;
        Vector3 left = -gameObject.transform.right;
        Vector3 up = gameObject.transform.up;
        Vector3 down = -gameObject.transform.up;

        if (Input.GetKey(KeyCode.W))
        {
            moveObject.position += forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveObject.position += back * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveObject.position += left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveObject.position += right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            moveObject.position += up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveObject.position += down * Time.deltaTime;
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
            transform.position += Player.transform.forward * Time.deltaTime * MAX_SPEED;
            timer += Time.deltaTime;
        }
        if (timer > QUICK_TIME)
        {
            quickFlag = false;
            timer = 0.0f;
        }
        if (dashFlag == true)
        {
            transform.position += Player.transform.forward * Time.deltaTime * MAX_SPEED;
        }
    }
}
