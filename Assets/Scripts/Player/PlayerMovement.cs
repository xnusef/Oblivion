using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public float Direction;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetVelocity();
    }

    private void SetVelocity()
    {
        rb.velocity = new Vector2(Direction * speed, rb.velocity.y);
    }
}
