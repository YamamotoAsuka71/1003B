using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Controller : MonoBehaviour
{
    [SerializeField] private GameObject Enemy02;
    private float interval;
    private float time = 0f;
    // ���g��Transform
    [SerializeField] private Transform _self;
    // �^�[�Q�b�g��Transform
    [SerializeField] private Transform _target;
    // �O���̊�ƂȂ郍�[�J����ԃx�N�g��
    [SerializeField] private Vector3 _forward = Vector3.forward;

    // Start is called before the first frame update
    void Start()
    {
        interval = 5f;
    }

    private void Update()
    {
        // �^�[�Q�b�g�ւ̌����x�N�g���v�Z
        var dir = _target.position - _self.position;

        // �^�[�Q�b�g�̕����ւ̉�]
        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
        // ��]�␳
        var offsetRotation = Quaternion.FromToRotation(_forward, Vector3.forward);

        // ��]�␳���^�[�Q�b�g�����ւ̉�]�̏��ɁA���g�̌����𑀍삷��
        _self.rotation = lookAtRotation * offsetRotation;
    }
    //private void CreateEnemy()
    //{
    //    time += Time.deltaTime;

    //    if (time > interval)
    //    {
    //        //enemy���C���X�^���X������(��������)
    //        GameObject enemy = Instantiate(Enemy02);
    //        //���������G�̍��W�����肷��(����X=0,Y=10,Z=20�̈ʒu�ɏo��)
    //        enemy.transform.position = new Vector3(0, 10, 20);
    //        //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
    //        time = 0f;
    //        Debug.Log("���܂ꂽ");
    //    }
    //}
}
