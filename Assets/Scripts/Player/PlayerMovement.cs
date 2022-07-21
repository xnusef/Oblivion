using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] private PlayerController pController;
    [HideInInspector] public float Direction;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private bool impulsed = false;

    public void Impulse(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
        impulsed = true;
    }

    void Start()
    {
        pController = this.GetComponent<PlayerController>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        setVelocity();
    }

    private void setVelocity()
    {
        if (!impulsed)
            rb.velocity = new Vector2(Direction * speed, rb.velocity.y);
        else if (impulsed && (Mathf.Abs(rb.velocity.x) <= 1 || Time.time <= pController.pState.GetTimeGrounded() + 0.2f))
            impulsed = false;
    }
}
