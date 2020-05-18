using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オキュラスクエスト用 transform.TranslateによるPlayerの移動方法
public class PlayerControllerForth : MonoBehaviour
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
    void Update()
    {
    // 右スティック入力・操作 方向
        Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        x = rightStick.x;
        y = rightStick.y;
        // x と z 軸のみの変更
        Vector3 direction = new Vector3( x , rb.position.y , y);
        move = moveSpeed * Time.deltaTime * (direction.x * moveTarget.transform.right.normalized + direction.z * moveTarget.transform.forward.normalized);
        transform.Translate(move, Space.World);

        // 左スティック操作 角度
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3( 0, leftStick.x, 0);
        transform.Rotate(angle * angleSpeed * Time.deltaTime);
    }
}
