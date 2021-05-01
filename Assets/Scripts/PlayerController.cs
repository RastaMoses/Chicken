using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Config Params
    [SerializeField] float moveSpeed = 2f;

    //State
    float velocityX;
    float velocityY;

    //Cached Component References

    [SerializeField] Rigidbody2D rigidbody;

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

    }
}
