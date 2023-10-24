using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Controller : MonoBehaviour
{
    [SerializeField] private GameObject Enemy02;
    private float interval;
    private float time = 0f;
    // �^�[�Q�b�g�I�u�W�F�N�g�� Transform�R���|�[�l���g���i�[����ϐ�
    public Transform target;
    // �I�u�W�F�N�g�̈ړ����x���i�[����ϐ�
    public float moveSpeed;
    // �I�u�W�F�N�g����~����^�[�Q�b�g�I�u�W�F�N�g�Ƃ̋������i�[����ϐ�
    public float stopDistance;
    // �I�u�W�F�N�g���^�[�Q�b�g�Ɍ������Ĉړ����J�n���鋗�����i�[����ϐ�
    public float moveDistance;
    // Start is called before the first frame update
    void Start()
    {
        interval = 5f;
    }

    private void Update()
    {
        //CreateEnemy();
        // �ϐ� targetPos ���쐬���ă^�[�Q�b�g�I�u�W�F�N�g�̍��W���i�[
        Vector3 targetPos = target.position;
        // �������g��Y���W��ϐ� target ��Y���W�Ɋi�[
        //�i�^�[�Q�b�g�I�u�W�F�N�g��X�AZ���W�̂ݎQ�Ɓj
        targetPos.y = transform.position.y;
        // �I�u�W�F�N�g��ϐ� targetPos �̍��W�����Ɍ�������
        transform.LookAt(targetPos);

        // �ϐ� distance ���쐬���ăI�u�W�F�N�g�̈ʒu�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋������i�[
        float distance = Vector3.Distance(transform.position, target.position);
        // �I�u�W�F�N�g�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋�������
        // �ϐ� distance�i�^�[�Q�b�g�I�u�W�F�N�g�ƃI�u�W�F�N�g�̋����j���ϐ� moveDistance �̒l��菬�������
        // ����ɕϐ� distance ���ϐ� stopDistance �̒l�����傫���ꍇ
        if (distance < moveDistance && distance > stopDistance)
        {
            // �ϐ� moveSpeed ����Z�������x�ŃI�u�W�F�N�g��O�����Ɉړ�����
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }
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
