using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
        [SerializeField] private float timeBeforeRestore = 0.5f;
    [Header("Other Settings")]
        [SerializeField] private float knockback = 20f; // * 10
        [SerializeField] private Slider slider;
    private int knifes;
    private float chargeTime = 0;
    private float power;
    private bool clickReleased = true;
    private float timeFirstShoot;
    private Camera cam;

    public void RestoreKnifes()
    {
        if (Time.time >= (timeFirstShoot + timeBeforeRestore))
        {
            knifes = maxKnifes;
            pController.dUpdate.RestoreKnifes();
        }
    }

    void Start()
    {
        pController = this.GetComponent<PlayerController>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        slider.maxValue = maxPower;
        slider.minValue = defaultPower;
    }

    void Update()
    {
        if (!clickReleased && power <= maxPower)
        {
            power = Mathf.Clamp(power + Time.deltaTime, 0f, maxPower);
            slider.value = power;
        }
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
            slider.gameObject.SetActive(true);
        }
    }

    private void released()
    {
        if (!clickReleased && knifes > 0)
        {
            knifes -= 1;
            pController.dUpdate.Shoot(knifes);
            pController.pState.SetValue("charging", false);
            clickReleased = true;
            shoot(getNearestEnemy());
            slider.gameObject.SetActive(false);
        }
    }

    private Vector3 getNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
            return cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        GameObject nearestEnemy = enemies[0];
        foreach (GameObject enemy in enemies)
            if (Vector2.Distance(enemy.transform.position, this.transform.position) < Vector2.Distance(nearestEnemy.transform.position, this.transform.position))
                nearestEnemy = enemy;
        return nearestEnemy.transform.position;
    }

    public void KnifeToMouse()
    {
        if (clickReleased && knifes > 0)
        {
            knifes -= 1;
            pController.dUpdate.Shoot(knifes);
            power = defaultPower;
            shoot(cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        }
    }

    private void shoot(Vector3 point)
    {
        knockBack(point);
        GameObject knife = GameObject.Instantiate(knifePrefab, shootPoint.position, Quaternion.identity, GameObject.Find("PlayerBullets")?.transform);
        knife.GetComponent<Knife>().SetDirection(point, power, this);
        if (knifes == (maxKnifes - 1))
        {
            timeFirstShoot = Time.time;
        }
    }

    private void knockBack(Vector3 point)
    {
        Vector3 knockbackDir = (this.transform.position - point).normalized;
        float multiplier = Mathf.Clamp(power, 0, 2.5f);
        pController.pMovement.Impulse(knockbackDir * knockback * 10 * multiplier);
    }
}
