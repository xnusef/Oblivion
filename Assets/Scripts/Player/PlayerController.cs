using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerMovement pMovement;
    [HideInInspector] public PlayerJump pJump;
    [HideInInspector] public PlayerAttack pAttack;
    [HideInInspector] public PlayerState pState;
    [HideInInspector] public DisplayUpdate dUpdate;
    [SerializeField] private int maxHealth = 3;
    private int health;

    public void Start()
    {
        pMovement = this.GetComponent<PlayerMovement>();
        pJump = this.GetComponent<PlayerJump>();
        pAttack = this.GetComponent<PlayerAttack>();
        pState = this.GetComponent<PlayerState>();
        dUpdate = GameObject.Find("Display")?.GetComponent<DisplayUpdate>();
        setMaxHealth();
    }
    
    private void setMaxHealth()
    {
        health = maxHealth;
        dUpdate.SetMaxHealth();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(health);
        dUpdate.Damaged(health);
        if (health <= 0)
            die();        
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
