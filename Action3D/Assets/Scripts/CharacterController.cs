using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Vector3 cameraVec;
    [SerializeField] GameObject camera;
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
            transform.localEulerAngles = new Vector3(0.0f, cameraVec.y - 45.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(0.0f, cameraVec.y + 45.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0.0f, cameraVec.y - 135.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0.0f, cameraVec.y + 135.0f, 0.0f);
        }
        //  A‚ª‰Ÿ‚³‚ê‚½‚ç
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(0.0f, cameraVec.y - 90.0f, 0.0f);
        }
        //  D‚ª‰Ÿ‚³‚ê‚½‚ç
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(0.0f, cameraVec.y + 90.0f, 0.0f);
        }
        //  W‚ª‰Ÿ‚³‚ê‚½‚ç
        else if (Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(0.0f, cameraVec.y, 0.0f);
        }
        //  S‚ª‰Ÿ‚³‚ê‚½‚ç
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0.0f, cameraVec.y + 180.0f, 0.0f);
        }
        transform.localEulerAngles = transform.localEulerAngles;
    }
}
