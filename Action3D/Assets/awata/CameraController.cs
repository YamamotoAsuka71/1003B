using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    const float MOUSE_SENCITIVE = 10;
    float angleX = 0.0f;
    float angleY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angleX = Input.GetAxis("mouseY") * MOUSE_SENCITIVE;
        angleY = Input.GetAxis("mouseX") * MOUSE_SENCITIVE;

        transform.rotation*=Quaternion.Euler(angleX,angleY,0);
    }
}
