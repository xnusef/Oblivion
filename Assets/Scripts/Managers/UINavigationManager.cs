using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UINavigationManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private void Awake() {
        eventSystem = EventSystem.current;
    }

    public void CleanEventSystem()
    {
        SetDeselected(eventSystem.currentSelectedGameObject);
        eventSystem.SetSelectedGameObject(null);
    }

    public void SetupMenu(GameObject menu){
        SetSelected(menu.GetComponent<MenuUnitControls>().defaultSelected);
    }

    public void SetSelected(GameObject selectable) {
        try
        {
            if (!selectable.Equals(eventSystem.currentSelectedGameObject)) eventSystem.SetSelectedGameObject(selectable);
            selectable.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0.27f);
        } catch (UnityException)
        {
            Debug.Log("GameObject null or not selectable");
        }
    }

    public void SetDeselected(GameObject selectable)
    {
        try
        {
            selectable.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0.07f);
        }
        catch (UnityException)
        {
            Debug.Log("GameObject null or not selectable");
        }
    }

    public void OnSelectedChange(GameObject selected)
    {
        Debug.Log("Current selected: " + selected.name);
    }

}
