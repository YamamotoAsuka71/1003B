using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awata_Movement : MonoBehaviour
{
    public void SetMovedirection(Transform moveObject)
    {
        Vector3 forward = moveObject.transform.forward;
        Vector3 back = -moveObject.transform.forward;
        Vector3 right = moveObject.transform.right;
        Vector3 left = -moveObject.transform.right;
        Vector3 up = moveObject.transform.up;
        Vector3 down = -moveObject.transform.up;

        if (Input.GetKey(KeyCode.W))
        {
            moveObject.position += forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveObject.position += back * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveObject.position += left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveObject.position += right * Time.deltaTime;
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
}
