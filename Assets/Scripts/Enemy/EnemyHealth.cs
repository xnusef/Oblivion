using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 150;
    private int health;

    public void Start()
    {
        setMaxHealth();
    }

    private void setMaxHealth()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        
        health -= (int) amount;
        if (health <= 0)
            die();        
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
