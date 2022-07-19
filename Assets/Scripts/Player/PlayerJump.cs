using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool grounded = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    public void Jump()
    {
        if (grounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}