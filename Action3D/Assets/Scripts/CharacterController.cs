using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Vector3 latestPos;  //�O���Position
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - latestPos;   //�O�񂩂�ǂ��ɐi�񂾂����x�N�g���Ŏ擾
        latestPos = transform.position;  //�O���Position�̍X�V

        //�x�N�g���̑傫����0�ȏ�̎��Ɍ�����ς��鏈��������
        if (diff.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(diff); //������ύX����
        }
    }
}
