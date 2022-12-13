using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Config Params
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float maxSpeed = 3f;
    [SerializeField] float moveLimiter = 0.7f;
    [SerializeField] float playerSize = 1;
    [SerializeField] float deathShrinkSpeed = 0.5f;
    [SerializeField] float deadTime = 2f;

    [SerializeField] Transform spawnPoint;

    [SerializeField] [Range(0,1)] public float baseSlipperyness = 0.85f;

    [Header("Layers")]
    [SerializeField] float iceSlipperyness = 0.995f; 

    //State
    public Vector2 movement;
    float slipperyness;
    bool movementEnabled = true;
    bool dead;

    //Cached Component References
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        slipperyness = baseSlipperyness;
        bool dead = false;
    }

    private void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (dead)
        {
            transform.localScale =new Vector3 (Mathf.Lerp(transform.localScale.x, 0, deathShrinkSpeed), Mathf.Lerp(transform.localScale.x, 0, deathShrinkSpeed), Mathf.Lerp(transform.localScale.x, 0, deathShrinkSpeed));
        }
    }

    void FixedUpdate()
    {
        if (movementEnabled)
        {
            PlayerMovement();
        }
    }
    void PlayerMovement()
    {
        //PlayerMovement();
        if (movement.x != 0 && movement.y != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }
        if (movement.x == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * slipperyness, rb.velocity.y);
        }
        if (movement.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * slipperyness);
        }

        rb.velocity += new Vector2(Mathf.Clamp(movement.x * moveSpeed * Time.fixedDeltaTime, -maxSpeed, maxSpeed), Mathf.Clamp(movement.y * moveSpeed * Time.fixedDeltaTime, -maxSpeed, maxSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("Entered Ice");
            slipperyness = iceSlipperyness;
        }

        //Hit hole
        if (collision.gameObject.layer == 10)
        {
            StartCoroutine(Death());
        }

        //Hit Goal
        if (collision.gameObject.layer == 11)
        {
            FindObjectOfType<Timer>().StopTimer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("Exit Ice");
            slipperyness = baseSlipperyness;
        }
    }

    private IEnumerator Death()
    {
        rb.velocity = new Vector2(0, 0);
        movementEnabled = false;
        dead = true;
        yield return new WaitForSeconds(deadTime);
        dead = false;
        movementEnabled = true;
        rb.velocity = new Vector2(0, 0);
        transform.position = spawnPoint.position;
        transform.localScale = new Vector3(playerSize, playerSize, playerSize);
    }

    public void TimerEnd()
    {
        StartCoroutine(Death());
        Debug.Log("Timer End");
    }
}
