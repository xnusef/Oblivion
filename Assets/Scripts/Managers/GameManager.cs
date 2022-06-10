using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    void Awake()
    {
        if (GM != null)
            Destroy(this.gameObject);
        else
            GM = this;
        DontDestroyOnLoad(this);
    }
}
