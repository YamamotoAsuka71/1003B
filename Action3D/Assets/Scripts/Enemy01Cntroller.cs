using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy01Cntroller : MonoBehaviour
{
    public GameObject target;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lookRotation 
            = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

    }
}
