using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy02Factory : MonoBehaviour
{

    public GameObject Prefabs;
    private float time;
    private int number;

    void Start()
    {
        time = 1.0f;
    }

    void Update()
    {
         if(Time.frameCount % 120 == 0)
         {
            // プレハブの位置をランダムで設定
            float x = Random.Range(-10.0f, 10.0f);
            float z = Random.Range(-10.0f, 10.0f);
            Vector3 pos = new Vector3(x, 5.0f, z);
 
            // プレハブを生成
            Instantiate(Prefabs, pos, Quaternion.identity);
         }    
    }
}
