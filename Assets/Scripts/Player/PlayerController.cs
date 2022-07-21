using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerMovement pMovement;
    [HideInInspector] public PlayerJump pJump;
    [HideInInspector] public PlayerAttack pAttack;
    [HideInInspector] public PlayerState pState;
    [SerializeField] private int maxHealth = 3;
    private float health;

    public void Start()
    {
        pMovement = this.GetComponent<PlayerMovement>();
        pJump = this.GetComponent<PlayerJump>();
        pAttack = this.GetComponent<PlayerAttack>();
        pState = this.GetComponent<PlayerState>();
        setMaxHealth();
    }
    
    private void setMaxHealth()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
            die();        
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
