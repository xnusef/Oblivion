using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    private List<GameObject> menus = new List<GameObject>();
    public List<GameObject> currentMenuControls = new List<GameObject>();
    private GameObject activeMenu, activeButton;
    public EventSystem EventSystem;
    public GameObject DefaultMenu;
    public OptionsManager OptionManager;

    private void Start()
    {
        getListOfMenus();
        setDefaultMenu();
        getListOfControlsFromMenu(DefaultMenu);
        OptionManager.LoadSettings();
        activeMenu = DefaultMenu;
        activeButton = activeMenu.GetComponent<MenuUnitControls>().defaultSelected;
        EventSystem = EventSystem.current;
    }

    private void getListOfControlsFromMenu(GameObject menu)
    {
        for (int i = 0; i < menu.transform.childCount; i++) {
            if (menu.transform.GetChild(i).TryGetComponent(out Button btn) || menu.transform.GetChild(i).TryGetComponent(out Slider slider)) {
                Debug.Log("Found" + menu.transform.GetChild(i).gameObject.name);
                currentMenuControls.Add(menu.transform.GetChild(i).gameObject);
            }
        }
    }

    private void getListOfMenus() {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "Menu")
            {
                menus.Add(transform.GetChild(i).gameObject);
                //Debug.Log(transform.GetChild(i).name);
            }
        }
    }

    public List<GameObject> GetNotSelected(GameObject selected) {
        List<GameObject> notSelected = new List<GameObject>();
        foreach(GameObject obj in currentMenuControls)
        {
            if (!obj.Equals(selected)) notSelected.Add(obj);
        }
        return notSelected;
    }

    private void setDefaultMenu()
    {
        foreach (GameObject menu in menus)
        {
            if (menu.Equals(DefaultMenu)) { 
                menu.SetActive(true);
            }
            else menu.SetActive(false);
        }

    }

    public void SetActiveMenu(GameObject newActive) {
        GameObject oldActive = activeMenu;
        activeMenu = newActive;

        oldActive.SetActive(false);
        activeMenu.SetActive(true);

        getListOfControlsFromMenu(activeMenu);

        EventSystem.SetSelectedGameObject(activeMenu.GetComponent<MenuUnitControls>().defaultSelected);
    }

    public void GotoScene(int index){
        try{
            SceneManager.LoadScene(index);
        } catch (UnityException){
            Debug.Log("Scene does not exist");
        }
    }

    public void QuitGame()
    {
        //Application.Quit(1);
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Focus(GameObject toChangeState, bool focus)
    {
        if (focus) {
            activeButton = toChangeState;
            activeButton.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, .27f);
        }
        else { toChangeState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, .07f); }

    }

}
