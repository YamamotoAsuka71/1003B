using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    GameObject short_renge_enemy;
    [SerializeField]
    GameObject long_renge_enemy;

    [SerializeField]
    const int MAX_ENEMY = 20;
    [SerializeField]
    const int POOL_LIMIT_NUM = 40;

    List<GameObject> enemy_pool = null;

    // Start is called before the first frame update
    void Start()
    {
        enemy_pool = new List<GameObject>(POOL_LIMIT_NUM);

        for (int i = 0; i < POOL_LIMIT_NUM; i++) 
        {
            GameObject enemy = null;

            if (i < POOL_LIMIT_NUM / 2)
            {
                enemy = Instantiate(short_renge_enemy);
                enemy.name = short_renge_enemy.name;
            }
            else
            {
                enemy = Instantiate(long_renge_enemy);
                enemy.name = long_renge_enemy.name;
            }

            enemy.transform.parent = transform;

            enemy.SetActive(false);

            enemy_pool.Add(enemy);
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
