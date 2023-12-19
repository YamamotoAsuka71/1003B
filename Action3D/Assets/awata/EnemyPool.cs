using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    GameObject short_renge_enemy;
    [SerializeField]
    GameObject long_renge_enemy;

    [SerializeField]
    const int MAX_ENEMY = 20;
    [SerializeField]
    const int POOL_LIMIT_NUM = 40;

    List<GameObject> enemy_pool = null;

    int wave1_enemy_value = 10;

    void Awake()
    {
        enemy_pool = new List<GameObject>(POOL_LIMIT_NUM);

        for (int i = 0; i < POOL_LIMIT_NUM; i++)
        {
            GameObject enemy = null;

            int pos_x = Random.Range(50, 100);
            int pos_y = Random.Range(50, 100);
            int pos_z = Random.Range(50, 100);

            Vector3 dif = new Vector3(pos_x, pos_y, pos_z);

            if (i < POOL_LIMIT_NUM / 2)
            {
                enemy = Instantiate(short_renge_enemy, player.position + dif, Quaternion.identity);
                enemy.name = short_renge_enemy.name;
            }
            else
            {
                enemy = Instantiate(long_renge_enemy);
                enemy.name = long_renge_enemy.name;
            }

            if (enemy != null)
            {
                enemy.transform.parent = transform;

                enemy.SetActive(false);

                enemy_pool.Add(enemy);
            }
            else
            {
                Debug.Log("Enemy = null");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < wave1_enemy_value; i++)
        {
            CreateEnemy(true, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateEnemy(bool is_short,bool is_long)
    {
        GameObject enemy = null;

        if (enemy_pool.Count == 0)
        {
            return  null;
        }
        else
        {
            if(is_short)
            {
                enemy = enemy_pool[0];

                enemy.transform.parent = null;

                enemy.SetActive(true);

                enemy_pool.Remove(enemy);
            }
            else if(is_long)
            {
                //”z—ñ‚ÌŒã‚ë‚©‚ç
                enemy = enemy_pool[POOL_LIMIT_NUM - 1];

                enemy.transform.parent = null;

                enemy.SetActive(true);

                enemy_pool.Remove(enemy);
            }

            return enemy;
        }
    }

    public void Store(GameObject obj)
    {
        if(obj.name != short_renge_enemy.name
            ||obj.name != long_renge_enemy.name)
        {
            return;
        }

        obj.transform.parent = transform;

        obj.SetActive(false);

        enemy_pool.Add(obj);
    }
}
