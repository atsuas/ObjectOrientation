using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f; // プラスする重力値

    private Vector3 moveDirection;

    public CharacterController charController;

    private Camera theCam;

    void Start()
    {
        theCam = Camera.main;
    }

    void Update()
    {
        // 移動させる
        float yStore = moveDirection.y;
        // moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        // オブジェクトの向きをforwardで決める
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;

        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        // transform.position = transform.position + (moveDirection * Time.deltaTime * moveSpeed);

        // キャラクターコントローラーのMove関数で動かす
        charController.Move(moveDirection * Time.deltaTime);

        // 左右と上下が０ではない場合、Y角をカメラの角度にする
        if (Input.GetAxisRaw("Horizontal") != 0  || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
        }
    }
}
