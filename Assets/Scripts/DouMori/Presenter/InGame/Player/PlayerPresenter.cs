using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Vector3 moveDirection;

    void Start()
    {
        
    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        transform.position = transform.position + (moveDirection * Time.deltaTime * moveSpeed);
    }
}
