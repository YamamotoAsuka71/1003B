using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    void Start()
    {

    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= camera.transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += camera.transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += camera.transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= camera.transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position -= camera.transform.up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += camera.transform.up * Time.deltaTime;
        }
    }
}
