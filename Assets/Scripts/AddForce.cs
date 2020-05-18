using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    Rigidbody rb;
    float moveSpeed = 2.25f;
    float angleSpeed = 30.0f;
    float moveForceMultiplier = 500;    // 移動速度の入力に対する追従度
    [SerializeField] GameObject moveTarget;
    // xとz方向の入力値
    float x = 0;
    float z = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 移動方向の入力
        if (Input.GetKey(KeyCode.D))
        {
            x = 1.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            x = -1.0f;
        }
        else
        {
            x = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            z = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            z = -1.0f;
        }
        else
        {
            z = 0;
        }
        // プレイヤーの回転
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1.0f, 0) * angleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1.0f, 0) * angleSpeed * Time.deltaTime);
        }
    }
    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;
        Vector3 playerForward = moveTarget.transform.forward;
        playerForward.y = 0;
        Vector3 playerRight = moveTarget.transform.right;
        playerRight.y = 0;

        // 移動したい方向
        moveVector = moveSpeed * (x * playerRight.normalized + z * playerForward.normalized);

        // rb.velocity = new Vector3( move.x * 2, rb.velocity.y, move.z * 2);
        // rb.AddForce(moveForceMultiplier * (moveVector - rb.velocity));
        rb.AddForce(moveForceMultiplier * (moveVector.x - rb.velocity.x), rb.velocity.y, moveForceMultiplier * (moveVector.z - rb.velocity.z));
    }
}
