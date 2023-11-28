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
            // �v���n�u�̈ʒu�������_���Őݒ�
            float x = Random.Range(-10.0f, 10.0f);
            float z = Random.Range(-10.0f, 10.0f);
            Vector3 pos = new Vector3(x, 5.0f, z);
 
            // �v���n�u�𐶐�
            Instantiate(Prefabs, pos, Quaternion.identity);
         }    
    }
}
