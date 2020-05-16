using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // public で他のスクリプトで必ずセットで扱うものに関しては、呼び出していいかも. 呼び出すことを強制的にすることが出来るから。
    // ただし、めんどくさい面もある
    public PlayerController playerController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // playerController.Move();
        playerController.DebugController();
    }
}
