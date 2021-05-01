using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Config Params
    [SerializeField] float moveSpeed = 2f;

    //State
    Vector2 movement;

    //Cached Component References

    [SerializeField] Rigidbody2D rb;

    private void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }


    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
