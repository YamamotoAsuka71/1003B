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
        float speed = 10.0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0.0f, 0.1f, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0.0f, -0.1f, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0.0f, 0.0f);
        }
    }
}
