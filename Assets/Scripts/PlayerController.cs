using UnityEngine;

// オキュラスクエスト用のPlayer操作スクリプト
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    private float angelSpeed = 0.4f;
    private float moveSpeed = 2.5f;

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
        rb.velocity = direction.z * transform.forward * moveSpeed + direction.x * transform.right * moveSpeed;

        // 左スティック操作 角度
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3( 0, leftStick.x, 0);
        transform.Rotate(angle * angelSpeed);
    }
    void Start()
    {
        // Player の RigidBody取得
        rb = GetComponent<Rigidbody>();
    }

    // Debug用
    // キー入力によるPlayer操作
    public void DebugController()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1.0f, 0) * angelSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1.0f, 0) * angelSpeed);
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
        rb.velocity = z * transform.forward * moveSpeed + x * transform.right * moveSpeed;
    }
}
