using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidleBossController : MonoBehaviour
{
    [SerializeField] 
    GameObject Player;


    const float FLY_SPEED = 2.0f;
    Animator animator;

    int Hp = 500;
    int stg = 40;

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
        Vector3 direction = Player.transform.position - transform.position;

        Vector3 normal_dir = direction.normalized;

        transform.LookAt(Player.transform.position);

        transform.Translate(transform.forward * FLY_SPEED * Time.deltaTime);

        

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
