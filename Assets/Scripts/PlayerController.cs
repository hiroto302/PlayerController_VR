using UnityEngine;
using System.Collections;

// オキュラスクエスト用のPlayer操作スクリプト
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    private float angelSpeed = 30.0f;
    private float moveSpeed = 2.25f;
    // private float moveSpeed = 5.0f;
    // 移動方向の基準オブジェクト moveTargetには、子オブジェクトのCenterEyeAnchorをアタッチ
    [SerializeField] GameObject moveTarget;

    public float MoveSpeed
    {
        set{moveSpeed = value;}
        get{return moveSpeed;}
    }

    // プレイヤーの視点と移動のメソッド
    // MoveメソッドとDebugControllerメソッドを同時に使わないこと
    public void Move()
    {
        // 右スティック操作 方向
        Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float x = rightStick.x;
        float y = rightStick.y;
        // 進行方向 yをz方向へ変換
        Vector3 direction = new Vector3( x , 0, y);
        var move = direction.z * moveTarget.transform.forward * moveSpeed + direction.x * moveTarget.transform.right * moveSpeed;
        // rb.velocity = direction.z * moveTarget.transform.forward * moveSpeed * Time.deltaTime + direction.x * moveTarget.transform.right * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3( move.x, rb.velocity.y, move.z);

        // 左スティック操作 角度
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3( 0, leftStick.x, 0);
        transform.Rotate(angle * angelSpeed * Time.deltaTime);
    }

    public void AddForceMove()
    {
        // 右スティック操作 方向
        Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float x = rightStick.x;
        float y = rightStick.y;
        // 進行方向 yをz方向へ変換
        Vector3 direction = new Vector3( x , 0, y);
        rb.AddForce(direction.z * moveTarget.transform.forward * moveSpeed + direction.x * moveTarget.transform.right * moveSpeed);
        // rb.velocity = direction.z * moveTarget.transform.forward * moveSpeed  + direction.x * moveTarget.transform.right * moveSpeed;

        // 左スティック操作 角度
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3( 0, leftStick.x, 0);
        transform.Rotate(angle * angelSpeed * Time.deltaTime);
    }

    void Awake()
    {
        // Player の RigidBody取得
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
    }

    void Update()
    {
        // Move();
        // AddForceMove();
        DebugController();
    }
    void FixedUpdate()
    {

    }

    // Debug用
    // キー入力によるPlayer操作
    public void DebugController()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1.0f, 0) * angelSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1.0f, 0) * angelSpeed * Time.deltaTime);
        }

        float x = 0;
        float z = 0;
        if (Input.GetKey(KeyCode.D))
        {
            x += 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            z += 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z -= 1.0f;
        }

        var move = z * moveTarget.transform.forward * moveSpeed  + x * moveTarget.transform.right * moveSpeed;
        Debug.Log(move + " : move");

        rb.velocity = new Vector3( move.x, rb.velocity.y, move.z);
        // rb.AddForce(z * moveTarget.transform.forward * moveSpeed  + x * moveTarget.transform.right * moveSpeed);
    }
}
