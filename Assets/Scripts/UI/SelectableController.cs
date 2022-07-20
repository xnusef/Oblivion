using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{

    private UINavigationManager navigationManager;

    private void Awake()
    {
        navigationManager = transform.GetComponentInParent<UINavigationManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        navigationManager.SetSelected(this.gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnDeselect(eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        navigationManager.SetSelected(this.gameObject);
        navigationManager.OnSelectedChange(this.gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        navigationManager.SetDeselected(this.gameObject);
    }

    private void OnDisable()
    {
        navigationManager.SetDeselected(this.gameObject);
    }
}
