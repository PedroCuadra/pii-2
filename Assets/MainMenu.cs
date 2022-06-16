using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [System.Serializable]
    public struct MenuItem {
        public GameObject menuObject;
        public GameObject selectableObject;
    }
    public MenuItem mainMenu;
    public MenuItem levelsMenu;
    public MenuItem settingsMenu;
    
    private MenuItem[] menus;

    void Awake(){
        menus = new MenuItem[]{
            mainMenu,
            levelsMenu,
            settingsMenu
        };

        GoToMainMenu();  
    }

    void HideAll(){
        foreach(MenuItem menu in menus){
            menu.menuObject.SetActive(false);
        }
    }

    private void GoTo(MenuItem menu){
        HideAll();
        menu.menuObject.SetActive(true);
        if(menu.selectableObject != null){
            EventSystem.current.SetSelectedGameObject(menu.selectableObject);
        }
    }

    public void GoToMainMenu(){
        GoTo(mainMenu);
    }

    public void GoToLevelsMenu(){
        GoTo(levelsMenu);
    }

    public void GoToSettingsMenu(){
        GoTo(settingsMenu);
    }

    public void OnClickExit(){
        Application.Quit();
    }
}
