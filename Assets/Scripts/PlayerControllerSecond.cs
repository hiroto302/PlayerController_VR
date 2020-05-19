using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Update と FixedUpdate で記述を分けてPlayerControllerの機能を記述
public class PlayerControllerSecond : MonoBehaviour
{
    Rigidbody rb;
    private float angleSpeed = 30.0f;
    private float moveSpeed = 2.25f;
    [SerializeField] GameObject moveTarget;
    // オキュラスクエストの入力値変数

    float x, y;
    Vector3 move;


    // void Awake()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 右スティック入力・操作 方向
        Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        x = rightStick.x;
        y = rightStick.y;
        // x と z 軸のみの変更
        Vector3 direction = new Vector3( x , 0, y);
        move = direction.z * moveTarget.transform.forward * moveSpeed + direction.x * moveTarget.transform.right * moveSpeed;
        rb.velocity = new Vector3( move.x, rb.velocity.y, move.z);

        // 左スティック操作 角度
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3( 0, leftStick.x, 0);
        transform.Rotate(angle * angleSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
    }
}
