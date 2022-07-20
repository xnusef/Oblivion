using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UINavigationManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private void Start() {
        eventSystem = EventSystem.current;
    }

    public void SetupMenu(GameObject menu){
        eventSystem.SetSelectedGameObject(menu.GetComponent<MenuUnitControls>().defaultSelected);
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
