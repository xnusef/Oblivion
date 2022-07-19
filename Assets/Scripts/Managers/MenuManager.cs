using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    private List<GameObject> menus = new List<GameObject>();
    private GameObject activeMenu;
    private GameObject focusedButton;
    public GameObject DefaultMenu;
    public OptionsManager OptionManager;

    private void Start()
    {
        getListOfMenus();
        setDefaultMenu();
        OptionManager.LoadSettings();

        activeMenu = DefaultMenu;
        focusedButton = null;
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

    public void LeavingFocusedButton(GameObject leaving)
    {

        Debug.Log("Leaving: " + leaving.name);
        focusedButton = null;
        //oldFocused.GetComponentInChildren<Material>().SetFloat(ShaderUtilities.ID_FaceDilate, .07f);
        //focusedButton.GetComponentInChildren<Material>().SetFloat(ShaderUtilities.ID_FaceDilate, .27f);
    }

    public void FocusingButton(GameObject focusing)
    {

        Debug.Log("Focusing: " + focusing.name);
        focusedButton = focusing;

        //oldFocused.GetComponentInChildren<Material>().SetFloat(ShaderUtilities.ID_FaceDilate, .07f);
        //focusedButton.GetComponentInChildren<Material>().SetFloat(ShaderUtilities.ID_FaceDilate, .27f);
    }

}
