using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceSecond : MonoBehaviour
{
    Rigidbody _rb;
    public bool isUseCameraDirection = true;    // カメラの向きに合わせて移動させたい場合はtrue
    public float moveSpeed = 1.0f;              // 移動速度
    public float moveForceMultiplier = 0;    // 移動速度の入力に対する追従度
    public GameObject mainCamera;
    float _horizontalInput;
    float _verticalInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        if(mainCamera == null)
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;    // 移動速度の入力

        if(isUseCameraDirection)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;
            // cameraForward.y = 0.0f;    // 水平方向に移動させたい場合はy方向成分を0にする
            // cameraRight.y = 0.0f;
            // 移動したい方向
            moveVector = moveSpeed * (cameraRight.normalized * _horizontalInput + cameraForward.normalized * _verticalInput);
        } else
        {
            moveVector.x = moveSpeed * _horizontalInput;
            moveVector.z = moveSpeed * _verticalInput;
        }

        // 入力移動速度と現在の移動速度の差に応じて力を加える、
        // 入力がなくなったときには入力移動速度は0になるので、減速する方向に力が加わる
        _rb.AddForce(moveForceMultiplier * (moveVector - _rb.velocity));
    }
}
