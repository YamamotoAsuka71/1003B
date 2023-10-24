using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Controller : MonoBehaviour
{
    [SerializeField] private GameObject Enemy02;
    private float interval;
    private float time = 0f;
    // 自身のTransform
    [SerializeField] private Transform _self;
    // ターゲットのTransform
    [SerializeField] private Transform _target;
    // 前方の基準となるローカル空間ベクトル
    [SerializeField] private Vector3 _forward = Vector3.forward;

    // Start is called before the first frame update
    void Start()
    {
        interval = 5f;
    }

    private void Update()
    {
        // ターゲットへの向きベクトル計算
        var dir = _target.position - _self.position;

        // ターゲットの方向への回転
        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
        // 回転補正
        var offsetRotation = Quaternion.FromToRotation(_forward, Vector3.forward);

        // 回転補正→ターゲット方向への回転の順に、自身の向きを操作する
        _self.rotation = lookAtRotation * offsetRotation;
    }
    //private void CreateEnemy()
    //{
    //    time += Time.deltaTime;

    //    if (time > interval)
    //    {
    //        //enemyをインスタンス化する(生成する)
    //        GameObject enemy = Instantiate(Enemy02);
    //        //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
    //        enemy.transform.position = new Vector3(0, 10, 20);
    //        //経過時間を初期化して再度時間計測を始める
    //        time = 0f;
    //        Debug.Log("生まれた");
    //    }
    //}
}
