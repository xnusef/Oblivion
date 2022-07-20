using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private GameObject defaultMenu = null;
    public OptionsManager OptionManager;
    private List<GameObject> menus = new List<GameObject>();
    private GameObject activeMenu;
    private UINavigationManager uiNavigationManager;

    private void Start()
    {
        uiNavigationManager = GetComponent<UINavigationManager>();
        getListOfMenus();
        SetActiveMenu(defaultMenu);
        OptionManager.LoadSettings();
    }

    public void SetActiveMenu(GameObject newActive)
    {

        bool isMenuOnList = false;

        foreach (GameObject menu in menus)
        {
            Debug.Log(newActive.name + menu.name);
            if (menu.Equals(newActive))
            {
                isMenuOnList = true;
                break;
            }
        }
        if (!isMenuOnList)
        {
            Debug.Log("Menu: " + newActive.name + " couldnt be found!");
            return;
        }

        activeMenu?.SetActive(false);
        newActive.SetActive(true);

        activeMenu = newActive;

        uiNavigationManager.SetupMenu(activeMenu);
    }

    public void GotoScene(int index)
    {
        try
        {
            SceneManager.LoadScene(index);
        }
        catch (UnityException)
        {
            Debug.Log("Scene does not exist");
        }
    }

    public void QuitGame()
    {
        //Application.Quit(1);
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void getListOfMenus()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            if (child.GetComponent<MenuCustomTags>() != null && child.GetComponent<MenuCustomTags>().HasTag("Menu"))
            {
                menus.Add(transform.GetChild(i).gameObject);
                if (defaultMenu == null && child.GetComponent<MenuCustomTags>().HasTag("Default"))
                {
                    defaultMenu = child;
                }
            }

        }

        Debug.Log(defaultMenu.name);
    }

}
