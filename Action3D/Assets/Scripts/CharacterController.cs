using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // �ő�̉�]�p���x[deg/s]
    [SerializeField] private float _maxAngularSpeed = Mathf.Infinity;

    // �i�s�����Ɍ����̂ɂ����邨���悻�̎���[s]
    [SerializeField] private float _smoothTime = 0.3f;

    private Transform _transform;

    // �O�t���[���̃��[���h�ʒu
    private Vector3 _prevPosition;

    private float _currentAngularVelocity;

    private void Start()
    {
        _transform = transform;

        _prevPosition = _transform.position;
    }

    private void Update()
    {
        // ���݃t���[���̃��[���h�ʒu
        var position = _transform.position;

        // �ړ��ʂ��v�Z
        var delta = position - _prevPosition;

        // ����Update�Ŏg�����߂̑O�t���[���ʒu�X�V
        _prevPosition = position;

        // �Î~���Ă����Ԃ��ƁA�i�s���������ł��Ȃ����߉�]���Ȃ�
        if (delta == Vector3.zero)
            return;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space))
        {
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.x = 0.0f;
            localAngle.z = 0.0f;

            transform.localEulerAngles = localAngle;
        }

        // �i�s�����i�ړ��ʃx�N�g���j�Ɍ����悤�ȃN�H�[�^�j�I�����擾
        var targetRot = Quaternion.LookRotation(delta, Vector3.up);

        // ���݂̌����Ɛi�s�����Ƃ̊p�x�����v�Z
        var diffAngle = Vector3.Angle(_transform.forward, delta);
        // ���݃t���[���ŉ�]����p�x�̌v�Z
        var rotAngle = Mathf.SmoothDampAngle(
            0,
            diffAngle,
            ref _currentAngularVelocity,
            _smoothTime,
            _maxAngularSpeed
        );
        // ���݃t���[���ɂ������]���v�Z
        var nextRot = Quaternion.RotateTowards(
            _transform.rotation,
            targetRot,
            rotAngle
        );

        // �I�u�W�F�N�g�̉�]�ɔ��f
        _transform.rotation = nextRot;
    }
}
