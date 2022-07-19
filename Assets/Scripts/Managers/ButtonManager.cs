using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using TMPro;

public class ButtonManager : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = transform.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Focus(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Focus(false);
    }

    public void Focus(bool focus)
    {
        if (focus) text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, .27f);
        else text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, .07f);
    }
}
