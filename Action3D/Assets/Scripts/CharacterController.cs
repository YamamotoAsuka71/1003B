using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Vector3 cameraVec;
    [SerializeField] GameObject camera;
    const float TOP_ANGLE = -45.0f;
    const float BOTTOM_ANGLE = 45.0f;
    float angleX = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraVec.y = camera.transform.localEulerAngles.y;
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(angleX, cameraVec.y - 45.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(angleX, cameraVec.y + 45.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(angleX, cameraVec.y - 135.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(angleX, cameraVec.y + 135.0f, 0.0f);
        }
        //  A�������ꂽ��
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(angleX, cameraVec.y - 90.0f, 0.0f);
        }
        //  D�������ꂽ��
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(angleX, cameraVec.y + 90.0f, 0.0f);
        }
        //  W�������ꂽ��
        else if (Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(angleX, cameraVec.y, 0.0f);
        }
        //  S�������ꂽ��
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(angleX, cameraVec.y + 180.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            angleX = TOP_ANGLE;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            angleX = BOTTOM_ANGLE;
        }
        else
        {
            angleX = 0.0f;
        }
        transform.localEulerAngles = new Vector3(angleX, transform.localEulerAngles.y, 0.0f);
    }
}
