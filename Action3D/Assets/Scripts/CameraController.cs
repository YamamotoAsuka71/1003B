using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.position = player.transform.position;

        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(mx) > 0.001f)
        {
            transform.RotateAround(player.transform.position, Vector3.up, mx);
        }

        if (gameObject.tag != "CameraPos")
        {
            if (Mathf.Abs(my) > 0.001f)
            {
                transform.RotateAround(player.transform.position, transform.right, my);
            }
        }
    }
}