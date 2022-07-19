using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using TMPro;

public class MenuManager : MonoBehaviour
{

    private List<GameObject> menus = new List<GameObject>();
    private GameObject activeMenu;
    private EventSystem eventSystem;
    public GameObject DefaultMenu;
    public OptionsManager OptionManager;

    private void Start()
    {
        getListOfMenus();
        setDefaultMenu();
        OptionManager.LoadSettings();
        activeMenu = DefaultMenu;

        eventSystem = EventSystem.current;
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

        eventSystem.SetSelectedGameObject(activeMenu.GetComponent<MenuUnitControls>().defaultSelected);
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
        if (focus) toChangeState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, .27f);
        else toChangeState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, .07f);
    }

}
