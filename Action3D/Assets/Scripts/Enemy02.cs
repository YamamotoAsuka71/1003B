using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour
{
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Speed = 100.0f;
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-Speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Speed* Time.deltaTime, 0.0f, 0.0f);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0.0f,Speed * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0.0f, -Speed * Time.deltaTime, 0.0f);
        }
    }

}
