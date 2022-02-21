using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public int speed;
    public float distance;
    private bool isClimbing;
    public LayerMask whatIsLadder;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ControlThePlayer();
    }
    private void ControlThePlayer()
    {
        float xInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(xInput * speed, playerRb.velocity.y);

        RaycastHit2D UphitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        RaycastHit2D DownhitInfo = Physics2D.Raycast(transform.position, Vector2.down, distance, whatIsLadder);

        if (UphitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                isClimbing = false;
            }
        }

        if (isClimbing == true && UphitInfo.collider != null)
        {
            float upInput = Input.GetAxis("Vertical");
            playerRb.velocity = new Vector2(playerRb.velocity.x, upInput * speed);
            playerRb.gravityScale = 0;
        }
        else
        {
            playerRb.gravityScale = 5;
        }
    }
}
