using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [HideInInspector] private PlayerController pController;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;

    void Start()
    {
        pController = this.GetComponent<PlayerController>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (pController.pState.GetGrounded() != grounded)
            pController.pState.SetGrounded(grounded);
    }

    public void Jump()
    {
        if (pController.pState.GetGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}