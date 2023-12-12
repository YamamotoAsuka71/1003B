using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Animator animator;

    delegate void Function();

    Function func;
    Material material;
    int hp = 1000;
    int bind_damage = 48;
    int push_damage = 52;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        timer += Time.deltaTime;
        transform.LookAt(player.transform.position);

        if (timer > 5.0f)
        {
            Attack();
            timer = 0.0f;
        }

        if (timer > 1.0f)
        {
            material.color = Color.white;
        }
    }

    void Attack()
    {
        int kind = 0;
        kind = Random.Range(0, 2);

        switch (kind)
        {
            case 0:
                BindAttack();
                break;
            case 1:
                PushAttack();
                break;
            default:
                Attack();
                break;
        }
    }


    public void BindAttack()
    {
        material.color = Color.red;
    }

    public void PushAttack()
    {
        material.color= Color.green;
    }
}
