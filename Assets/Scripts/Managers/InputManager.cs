using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
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
        Debug.Log(value.Get());
    }

    void OnJump()
    {
        Debug.Log("Jump");
    }

    void OnDrop()
    {
        Debug.Log("Drop");
    }

    void OnAttack()
    {
        Debug.Log("Attack");
    }

    void OnParry()
    {
        Debug.Log("Parry");
    }

    void OnPause()
    {
        Debug.Log("Pause");
    }

    void OnAltF4()
    {
        Debug.Log("AltF4");
    }

    void OnPrevious()
    {
        Debug.Log("Previous");
    }

    void OnNext()
    {
        Debug.Log("Next");
    }

    void OnEnter()
    {
        Debug.Log("Enter");
    }
}
