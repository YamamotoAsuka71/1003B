using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class MidleBossController : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    const float FLY_SPEED = 2.0f;
    [SerializeField]
    const float BUTTLE_RENGE = 5.0f;
    [SerializeField]
    const float COOL_TIME = 5.0f;
    Animator animator;
    Material material;

    int Hp = 500;
    int stg = 40;

    float speed = 0;
    float timer = 0;
    bool is_attack = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        material = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        timer += Time.deltaTime;

        Vector3 direction = Player.transform.position - transform.position;

        Vector3 normal_dir = direction.normalized;

        transform.LookAt(Player.transform.position);

        if (direction.magnitude > BUTTLE_RENGE)
        {
            transform.Translate(transform.forward * FLY_SPEED * Time.deltaTime);
        }
        else
        {
            if (timer > COOL_TIME)
            {
                Attack();
                timer = 0;
            }
        }
        if (timer > 1.0f)
        {
            material.color = Color.white;
        }

        //animator.SetFloat("Speed", speed);
    }

    void Attack()
    {
        material.color = Color.yellow;
        //animator.SetTrigger("isAttack");
    }
}
