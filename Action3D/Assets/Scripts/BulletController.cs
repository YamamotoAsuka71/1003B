using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] GameObject shellPrefab;
    private int count;

    // Update is called once per frame
    void Update()
    {
        count += 1;
        float Speed = 180.0f;
        // �i�|�C���g�j
        // �U�O�t���[�����ƂɖC�e�𔭎˂���
        if (count % 60 == 0)
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // �e���͎��R�ɐݒ�
            shellRb.AddForce(transform.forward * 500);

            // �T�b��ɖC�e��j�󂷂�
            Destroy(shell, 5.0f);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -Speed*Time.deltaTime, 0.0f);
        }
    }
}
