using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerMovement pMovement;
    [HideInInspector] public PlayerJump pJump;
    [HideInInspector] public PlayerAttack pAttack;
    [HideInInspector] public PlayerState pState;

    public void Start()
    {
        pMovement = this.GetComponent<PlayerMovement>();
        pJump = this.GetComponent<PlayerJump>();
        pAttack = this.GetComponent<PlayerAttack>();
        pState = this.GetComponent<PlayerState>();
    }
}
