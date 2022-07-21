using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class PlayerAttack : MonoBehaviour
{
    [HideInInspector] private PlayerController pController;
    [Header("Knife Settings")]
        [SerializeField] private int maxKnifes = 2;
        [SerializeField] private float maxChargeTime = 1f;
        [SerializeField] private float defaultPower = 1f;
        [SerializeField] private float maxPower = 3f;
    [Header("Other Settings")]
        [SerializeField] private float knockback = 20f; // * 10
    private int knifes;
    private float chargeTime = 0;
    private float power;
    private bool clickReleased = true;
    private Camera cam;

    void Start()
    {
        pController = this.GetComponent<PlayerController>();
        knifes = maxKnifes;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (!clickReleased && power <= maxPower)
            power = Mathf.Clamp(power + Time.deltaTime, 0f, maxPower);
        if (!clickReleased && Time.time >= chargeTime)
        {
            clickReleased = true;
            shoot(Vector2.zero);
        }
    }

    public void KnifeToEnemy(int value)
    {
        if (value == 1)
            pressed();
        if (value == 0)
            released();
    }

    private void pressed()
    {
        power = defaultPower;
        clickReleased = false;
        chargeTime = Time.time + maxChargeTime;
    }

    private void released()
    {
        if (!clickReleased)
        {
            clickReleased = true;
            shoot(Vector2.zero);
        }
    }

    public void KnifeToMouse()
    {
        power = defaultPower;
        Vector2 point = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        shoot(point);
    }

    private void shoot(Vector3 point)
    {
        if (knifes > 0)
        {
            knifes -= 1;
            Vector3 knockbackDir = (this.transform.position - point).normalized;
            pController.pMovement.Impulse(knockbackDir * knockback * 10);
        }
    }
}
