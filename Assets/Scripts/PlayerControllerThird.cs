using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オキュラスクエスト  AddForceを利用したPlayerの移動方法
public class PlayerControllerThird : MonoBehaviour
{
    Rigidbody rb;
    private float angleSpeed = 30.0f;
    private float moveSpeed = 2.25f;
    float moveForceMultiplier = 500;
    [SerializeField] GameObject moveTarget;
    // オキュラスクエストの入力値変数

    float x, y;
    Vector3 move;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Stop()
    {
        rb.velocity = Vector3.zero;
    }
    void Update()
    {
        // 右スティック入力・操作 方向
        Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        x = rightStick.x;
        y = rightStick.y;
        // x と z 軸のみの変更
        Vector3 direction = new Vector3( x , 0, y);
        move = moveSpeed * (direction.x * moveTarget.transform.right.normalized + direction.z * moveTarget.transform.forward.normalized);
        move.y = 0;

        // 左スティック操作 角度
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3( 0, leftStick.x, 0);
        transform.Rotate(angle * angleSpeed * Time.deltaTime);

    }

    void FixedUpdate()
    {
        // if(move.x == 0 && move.z == 0)
        // {
        //     Stop();
        // }
        rb.AddForce(moveForceMultiplier * (move.x - rb.velocity.x), rb.velocity.y, moveForceMultiplier * (move.z - rb.velocity.z));
    }
}

