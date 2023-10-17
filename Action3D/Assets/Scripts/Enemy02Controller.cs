using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Controller : MonoBehaviour
{
    [SerializeField] private GameObject Enemy02;
    private float interval;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        interval = 5f;
    }

    private void Update()
    {
        CreateEnemy();
    }
    private void CreateEnemy()
    {
        time += Time.deltaTime;

        if (time > interval)
        {
            //enemy���C���X�^���X������(��������)
            GameObject enemy = Instantiate(Enemy02);
            //���������G�̍��W�����肷��(����X=0,Y=10,Z=20�̈ʒu�ɏo��)
            enemy.transform.position = new Vector3(0, 10, 20);
            //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
            time = 0f;
            Debug.Log("���܂ꂽ");
        }
    }
}
