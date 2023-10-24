using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Vector3 latestPos;  //前回のPosition
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;  //前回のPositionの更新

        //ベクトルの大きさが0以上の時に向きを変える処理をする
        if (diff.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }
    }
}
