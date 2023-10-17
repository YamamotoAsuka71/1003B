using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] GameObject childObj;
    private float speed = 300;

    // Start is called before the first frame update
    void Start()
    {
        childObj = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject ball = (GameObject)Instantiate(sphere, childObj.transform.position, Quaternion.identity);
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(transform.forward * speed);
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 2, 0);
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -2, 0);
        }
    }
}
