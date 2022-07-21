using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [HideInInspector] private PlayerController pController;
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private Transform shootPoint;
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

    public void RestoreKnife(int amount)
    {
        knifes += amount;
    }

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
            released();
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
        if (knifes > 0)
        {
            
            power = defaultPower;
            clickReleased = false;
            pController.pState.SetValue("charging", true);
            chargeTime = Time.time + maxChargeTime;
        }
    }

    private void released()
    {
        if (!clickReleased && knifes > 0)
        {
            knifes -= 1;
            pController.pState.SetValue("charging", false);
            clickReleased = true;
            Vector2 point = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            shoot(point);
        }
    }

    public void KnifeToMouse()
    {
        if (clickReleased && knifes > 0)
        {
            knifes -= 1;
            power = defaultPower;
            Vector2 point = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            shoot(point);
        }
    }

    private void shoot(Vector3 point)
    {
        knockBack(point);
        GameObject knife = GameObject.Instantiate(knifePrefab, shootPoint.position, Quaternion.identity, GameObject.Find("PlayerBullets")?.transform);
        knife.GetComponent<Knife>().SetDirection(point, power, this);
    }

    private void knockBack(Vector3 point)
    {
        Vector3 knockbackDir = (this.transform.position - point).normalized;
        float multiplier = Mathf.Clamp(power, 0, 2f);
        pController.pMovement.Impulse(knockbackDir * knockback * 10 * multiplier);
    }
}
