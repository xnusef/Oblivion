using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] private PlayerController pController;
    [HideInInspector] public float Direction;
    [SerializeField] private float speed;
    [SerializeField] private float minImpulsedTime = 0.5f;
    private Rigidbody2D rb;
    private bool impulsed = false;
    private float timeImpulsed = 0f;

    public void Impulse(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
        impulsed = true;
        timeImpulsed = Time.time + minImpulsedTime;
    }

    void Start()
    {
        pController = this.GetComponent<PlayerController>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (pController.pState != null && !pController.pState.GetValue("charging"))
            setVelocity(new Vector2(Direction * speed, rb.velocity.y));
        else
            rb.velocity = Vector2.zero;
    }

    private void setVelocity(Vector2 velocity)
    {
        if (!impulsed)
            rb.velocity = velocity;
        else if (!pController.pState.GetValue("charging"))
            rb.AddForce(Vector2.right * Direction * speed * 100);
        if (impulsed && Time.time >= timeImpulsed && pController.pState.GetValue("grounded"))
            impulsed = false;
    }
}
