using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Controller : MonoBehaviour
{
    [SerializeField] private GameObject Enemy02;
    private float interval;
    private float time = 0f;
    // ターゲットオブジェクトの Transformコンポーネントを格納する変数
    public Transform target;
    // オブジェクトの移動速度を格納する変数
    public float moveSpeed;
    // オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
    public float stopDistance;
    // オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    public float moveDistance;
    // Start is called before the first frame update
    void Start()
    {
        interval = 5f;
    }

    private void Update()
    {
        //CreateEnemy();
        // 変数 targetPos を作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = target.position;
        // 自分自身のY座標を変数 target のY座標に格納
        //（ターゲットオブジェクトのX、Z座標のみ参照）
        targetPos.y = transform.position.y;
        // オブジェクトを変数 targetPos の座標方向に向かせる
        transform.LookAt(targetPos);

        // 変数 distance を作成してオブジェクトの位置とターゲットオブジェクトの距離を格納
        float distance = Vector3.Distance(transform.position, target.position);
        // オブジェクトとターゲットオブジェクトの距離判定
        // 変数 distance（ターゲットオブジェクトとオブジェクトの距離）が変数 moveDistance の値より小さければ
        // さらに変数 distance が変数 stopDistance の値よりも大きい場合
        if (distance < moveDistance && distance > stopDistance)
        {
            // 変数 moveSpeed を乗算した速度でオブジェクトを前方向に移動する
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }
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
