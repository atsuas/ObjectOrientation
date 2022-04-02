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

    void Start()
    {
        
    }

    void Update()
    {
        // 移動させる
        float yStore = moveDirection.y;
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
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
    }
}
