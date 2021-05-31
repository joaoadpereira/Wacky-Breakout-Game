using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager 
{

    #region Methods

    public static void GotoMenu(MenuName menuName)
    {
        
        switch (menuName)
        {
            case MenuName.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;

            case MenuName.DifficultyMenu:
                SceneManager.LoadScene("DifficultyMenu");
                break;

            case MenuName.HelpMenu:
                SceneManager.LoadScene("HelpMenu");
                break;

            case MenuName.GamePlayMenu:
                SceneManager.LoadScene("GamePlay");
                break;

            case MenuName.PauseMenu:
                
                //Instantiate prefab
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;

            case MenuName.GameOverMenu:
                Object.Instantiate(Resources.Load("GameOver"));
                break;
        }
    }

    #endregion
}
