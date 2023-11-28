using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy02Controller : MonoBehaviour
{
    [SerializeField] private GameObject Enemy02;
    [SerializeField] GameObject shellPrefab;
    private float interval;
    private float time = 0f;
    // 自身のTransform
    [SerializeField] private Transform _self;
    // ターゲットのTransform
    [SerializeField] private Transform _target;
    // 前方の基準となるローカル空間ベクトル
    [SerializeField] private Vector3 _forward = Vector3.forward;
    // オブジェクトの移動速度を格納する変数
    public float moveSpeed;
    // オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
    public float stopDistance;
    // オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    public float moveDistance;
    private int count;
    float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        interval = 5f;
    }

    private void Update()
    {
        enemyMove();
    }

    private void enemyMove()
    {
        // 変数 distance を作成してオブジェクトの位置とターゲットオブジェクトの距離を格納
        float distance = Vector3.Distance(transform.position, _target.position);
        // オブジェクトとターゲットオブジェクトの距離判定
        // 変数 distance（ターゲットオブジェクトとオブジェクトの距離）が変数 moveDistance の値より小さければ
        // さらに変数 distance が変数 stopDistance の値よりも大きい場合
        if (distance < moveDistance && distance > stopDistance)
        {
            //GetComponent<Animator>().SetFloat("Speed", 1.0f);
            // 変数 moveSpeed を乗算した速度でオブジェクトを前方向に移動する
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            // ターゲットへの向きベクトル計算
            var dir = _target.position - _self.position;

            // ターゲットの方向への回転
            var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
            // 回転補正
            var offsetRotation = Quaternion.FromToRotation(_forward, Vector3.forward);

            // 回転補正→ターゲット方向への回転の順に、自身の向きを操作する
            _self.rotation = lookAtRotation * offsetRotation;
            count += 1;

            // 120フレームごとに砲弾を発射する
            if (count % 240 == 0)
            {
                GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();

                // 弾速は自由に設定
                shellRb.AddForce(transform.forward * 300);

                // 4秒後に砲弾を破壊する
                Destroy(shell, 4.0f);
            }

        }

    }
}
