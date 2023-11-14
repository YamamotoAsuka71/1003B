using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidleBossController : MonoBehaviour
{
    const float FLY_SPEED = 2.0f;

    Animator animator;

    float speed = 0;
    bool is_attack = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speed += 1.0f * (Time.deltaTime);
        }
        else
        {
            speed -= 1.0f* (Time.deltaTime);
        }

        speed = Mathf.Clamp(speed, 0, 1);

        animator.SetFloat("Speed", speed);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("isAttack");
        }
    }
}
