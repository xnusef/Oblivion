using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerState : MonoBehaviour
{
    private bool grounded;
    private float timeGrounded;

    public bool GetGrounded()
    {
        return grounded;
    }
    public void SetGrounded(bool value)
    {
        grounded = value;
        if (value)
            timeGrounded = Time.time;
    }

    public float GetTimeGrounded()
    {
        return timeGrounded;
    }
}
