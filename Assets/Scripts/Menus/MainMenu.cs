using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void HandlePlayButton()
    {
        MenuManager.GotoMenu(MenuName.DifficultyMenu);
    }

    public void HandleHelpMenu()
    {
        MenuManager.GotoMenu(MenuName.HelpMenu);
    }

    public void HandleBackMenu()
    {
        MenuManager.GotoMenu(MenuName.MainMenu);
    }

    public void HandleGamePlayButton()
    {
        MenuManager.GotoMenu(MenuName.GamePlayMenu);
    }

    public void HandleQuitButton()
    {
        Application.Quit();
    }
}
