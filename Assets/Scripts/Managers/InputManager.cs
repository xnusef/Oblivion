using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public PlayerManager PM;
    public static InputManager IM;

    void Awake()
    {
        if (IM != null)
            Destroy(this.gameObject);
        else
            IM = this;
        DontDestroyOnLoad(this);
    }

    void OnHorizontalMovement(InputValue value)
    {
        PM.ReceiveInput("Move", int.Parse(value.Get().ToString()));
    }

    void OnJump()
    {
        PM.ReceiveInput("Jump", 0);
    }

    void OnDrop()
    {
        PM.ReceiveInput("Drop", 0);
    }

    void OnAttack()
    {
        PM.ReceiveInput("Attack", 0);
    }

    void OnParry()
    {
        PM.ReceiveInput("Parry", 0);
    }

    void OnPause()
    {
        PM.ReceiveInput("Pause", 0);
    }

    void OnAltF4()
    {
        PM.ReceiveInput("AltF4", 0);
    }

    void OnPrevious()
    {
        PM.ReceiveInput("Previous", 0);
    }

    void OnNext()
    {
        PM.ReceiveInput("Next", 0);
    }

    void OnEnter()
    {
        PM.ReceiveInput("Enter", 0);
    }
}
