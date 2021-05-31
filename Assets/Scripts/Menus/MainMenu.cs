using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void HandlePlayButton()
    {
        MenuManager.GotoMenu(MenuName.DifficultyMenu);
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    public void HandleHelpMenu()
    {
        MenuManager.GotoMenu(MenuName.HelpMenu);
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    public void HandleBackMenu()
    {
        MenuManager.GotoMenu(MenuName.MainMenu);
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    public void HandleGamePlayButton()
    {
        MenuManager.GotoMenu(MenuName.GamePlayMenu);
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    public void HandleQuitButton()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Application.Quit();
    }
}
