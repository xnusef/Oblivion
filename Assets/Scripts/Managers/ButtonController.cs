using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using TMPro;

public class ButtonController : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private TextMeshProUGUI text;
    private Animator animator;
    private MenuManager menuManager;

    private void Start()
    {
        text = transform.GetComponentInChildren<TextMeshProUGUI>();
        animator = transform.GetComponent<Animator>();
        menuManager = transform.GetComponentInParent<MenuManager>();
        Debug.Log(menuManager.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("Selected");
        Debug.Log("Pointer Entering: " + this.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("Normal");
        Debug.Log("Pointer Leaving: " + this.name);
    }

    private void OnAnimatorMove()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Normal")) menuManager.Focus(this.gameObject, false);
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Selected")) menuManager.Focus(this.gameObject, true);
    }

}
