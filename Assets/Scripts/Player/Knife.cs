using UnityEditor.Callbacks;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float damage = 5f;
    [SerializeField] private float speed = 40f;
    private PlayerAttack pAttack;
    private float power = 0;
    bool colisioned = false;

    public void SetDirection(Vector3 point, float power, PlayerAttack playerAttack)
    {
        pAttack = playerAttack;
        this.power = power;

        Vector3 direction = (point - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        if (!colisioned)
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);  
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.tag.Equals("Enemy"))
            //col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage * power);
        colisioned = true;
        Destroy(this.gameObject);
    }
}
