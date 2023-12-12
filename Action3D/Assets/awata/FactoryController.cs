using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    GameObject short_renge_enemy;
    [SerializeField]
    GameObject long_renge_enemy;

    [SerializeField]
    const int MAX_ENEMY = 20;
    [SerializeField]
    const int POOL_LIMIT_NUM = 40;

    List<GameObject> enemies = null;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>(POOL_LIMIT_NUM);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
