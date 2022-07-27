using UnityEngine;
using UnityEngine.UI;

public class DisplayUpdate : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite heart;
    [SerializeField] private Sprite heartSlot;
    [SerializeField] private Image[] knifes;
    [SerializeField] private Sprite knife;
    [SerializeField] private Sprite knifeSlot;


    public void SetMaxHealth()
    {
        foreach (Image image in hearts)
            image.sprite = heart;
    }
    
    public void Damaged(int health)
    {
        hearts[health].sprite = heartSlot;
    }

    public void RestoreKnifes()
    {
        foreach (Image image in knifes)
            image.sprite = knife;
    }
    
    public void Shoot(int amount)
    {
        knifes[amount].sprite = knifeSlot;
    }
}
