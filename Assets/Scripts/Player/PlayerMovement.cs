using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] private PlayerController pController;
    [HideInInspector] public float Direction;
    [SerializeField] private float speed;
    [SerializeField] private float minImpulsedTime = 0.5f;
    private Rigidbody2D rb;
    private bool impulsed = false;
    private float timeImpulsed = 0f;
    private Camera cam;

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
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        updateFacingDir();
    }

    private void updateFacingDir()
    {
        Vector2 point = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float distanceX = point.x - transform.position.x;
        if ((distanceX > 0 && !pController.pState.GetValue("facingRight")) || (distanceX < 0 && pController.pState.GetValue("facingRight")))
        {
            this.transform.Rotate(0f, 180f, 0f);
            pController.pState.SetValue("facingRight", distanceX > 0);
        }
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
        else if (!pController.pState.GetValue("charging") && Mathf.Abs(rb.velocity.x) <= 15)
            rb.AddForce(Vector2.right * Direction * speed * 100);
        if (impulsed && Time.time >= timeImpulsed && pController.pState.GetValue("grounded"))
            impulsed = false;
    }
}
